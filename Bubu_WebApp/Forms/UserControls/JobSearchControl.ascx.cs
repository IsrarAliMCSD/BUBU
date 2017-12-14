using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class JobSearchControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public List<Vacancy> vacanciesSearch;
        public VacancyApply vacancyApply;
        public int? companyId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //  lblError.Text = "";
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }

        }
        private void FormLoad(int userId)
        {
            FillJobType();
            FillRegion();
            FillDistinctJobFunctionsList();
            GetDistinctSector();
            lblMessage.Text = MisOp.MotivationLetter();
            if (companyId != null && companyId > 0)
            {
                SearchResult(); ShowHideControl();
            }
        }

        private void GetDistinctSector()
        {
            misop = new MiscellaneousOperation();
            misop.GetDistinctSector(ref ddlSector);
        }
        private void FillDistinctJobFunctionsList()
        {
            misop = new MiscellaneousOperation();
            misop.GetDistinctJobFunctionsList(ref ddlFunction);
        }

        public void FillRegion()
        {
            misop = new MiscellaneousOperation();
            misop.GetRegionList(ref ddlRegion);
        }
        private void FillJobType()
        {
            misop = new MiscellaneousOperation();
            misop.FillJobType(ref ddlJobType);
        }

        protected void lbtnMoreOption_Click(object sender, EventArgs e)
        {

        }
        public void SearchResult()
        {
            appmanager = new AppManager();
            vacanciesSearch = appmanager.JobSearch(companyId, DAOClassLib.JobPrivacy.Public,
                ddlSector.SelectedIndex != 0 ? ddlSector.SelectedItem.Text : "",
                ddlFunction.SelectedIndex != 0 ? ddlFunction.SelectedItem.Text : "",
                ddlRegion.SelectedIndex != 0 ? ddlRegion.SelectedItem.Text : "",
                ddlJobType.SelectedIndex != 0 ? ddlJobType.SelectedItem.Text : "", txtSearch.Text,
                ref returnMessage);
            gvVacancyList.DataSource = vacanciesSearch;
            gvVacancyList.DataBind();
            
        }
        public void ShowHideControl()
        {
            foreach (GridViewRow row in gvVacancyList.Rows)
            {  
                row.FindControl("lbtnMoreInfos").Visible  = companyId != null && companyId>0 ? false : true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
        public string GetImage(object img, string format)
        {
            if (!MisOp.GetImageTypeList().Contains(format.ToUpper()))
            {
                return MisOp.GetImageURL(format.ToUpper());
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }


        }

        protected void gvVacancyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MOREINFO")
            {
                //============show particular job on click

                MisOp.ShowMessage(this, returnMessage, "Message Sent", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "JScript1",
                    "<script>OpenPageInDialogue('JobDetail.aspx?jobId" + HelperFunction.Encrypt(e.CommandArgument.ToString()) + ";</script>');", false);
                return;


              //  Response.Redirect("CompanyInfo.aspx?Param=" + HelperFunction.Encrypt(e.CommandArgument.ToString()));
            }
            else if (e.CommandName == "APPLY")
            {
                ShowHidegrid(e, true);
            }
            else if (e.CommandName == "NOTNOW")
            {
                ShowHidegrid(e, false);
            }
            else if (e.CommandName == "APPLYYES")
            {
                InsertVacancyApply(e);
            }


        }

        public void InsertVacancyApply(GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Panel panel = row.FindControl("pnlApply") as Panel;
            TextBox txtMotivationLetter = panel.FindControl("txtMotivationLetter") as TextBox;
            Label lblError = panel.FindControl("lblError") as Label;
            vacancyApply = new VacancyApply();
            vacancyApply.MotivationLetter = txtMotivationLetter.Text;
            vacancyApply.VacancyId = Convert.ToInt32(e.CommandArgument.ToString());
            vacancyApply.UserId = SessionHelper.getUserSession().userid;
            vacancyApply.IsActive = true;
            vacancyApply.IsCancelByEmployer = false;
            appmanager = new AppManager();
            appmanager.InsertVacancyApply(vacancyApply, ref returnMessage);
            lblError.Text = returnMessage;
        }

        public void ShowHidegrid(GridViewCommandEventArgs e, bool result)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Panel panel = row.FindControl("pnlApply") as Panel;
            panel.Visible = result;
            //lblError.text="";
        }


    }
}