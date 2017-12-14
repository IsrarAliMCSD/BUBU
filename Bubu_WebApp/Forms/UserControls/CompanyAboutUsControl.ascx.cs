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
    public partial class CompanyAboutUsControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public List<CompanyAbout> companyAbouts;
        public CompanyAbout companyAbout;
        public string returnMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
                
            }
        }
        private void FormLoad(int userId)
        {
            FillAboutUs(userId);
        }
        private void FillAboutUs(int userId)
        {
            appmanager = new AppManager();
            companyAbouts = appmanager.GetCompanyAboutUsList(userId);
            if (companyAbouts.Count > 0)
            {
                lblCompanyId.Text = companyAbouts[0].CompanyId.ToString();
            }
            else
            {
                CompanyInformation companyInformation = appmanager.GetCompanyInformationByUserId(userId);
                if (companyInformation != null)
                {
                    lblCompanyId.Text = companyInformation.CompanyId.ToString();
                }
            }
            rptrAboutUs.DataSource = companyAbouts;
            rptrAboutUs.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            if (appmanager.SaveCompanyAbout(FormToObjet(), ref returnMessage))
            {
                FormReset();
                FormLoad(SessionHelper.getUserSession().userid);
            }
            else
            {
                lblError.Text = returnMessage;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeerAboutUs.aspx");
        }

        protected void rptrAboutUs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "ABOUTUSEDIT")
            {
                companyAbout = GetCompanyAboutUsByCompanyAboutId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (companyAbout != null)
                {
                    ObjectToForm(companyAbout);
                    btnCancel.Visible = true;
                    btnBack.Visible = false;
                }
            }
            else if (e.CommandName.ToString() == "ABOUTUSDELETE")
            {
                int companyAboutUsId = Convert.ToInt32(e.CommandArgument.ToString());
                if (DeleteCompanyAboutUs(companyAboutUsId))
                {
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                }
            }
        }

        private void ObjectToForm(CompanyAbout companyAbout)
        {
            lblCompanyAboutUsId.Text = companyAbout.CompanyAboutUsId.ToString();
            txtHeading.Text = companyAbout.Heading;
            txtDetail.Text = companyAbout.Detail;
            btnSave.Visible = true;
            btnBack.Visible = false;
            btnCancel.Visible = true;
        }

        public CompanyAbout GetCompanyAboutUsByCompanyAboutId(int companyAboutUsId)
        {
            appmanager = new AppManager();
            return appmanager.GetCompanyAboutUsByCompanyAboutId(companyAboutUsId);
        }

        private void FormReset()
        {
            lblCompanyAboutUsId.Text = "";
            txtHeading.Text = "";
            txtDetail.Text = "";
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }

        private CompanyAbout FormToObjet()
        {
            companyAbout = new CompanyAbout();
            if (lblCompanyAboutUsId.Text != "")
            {
                companyAbout.CompanyAboutUsId = Convert.ToInt32(lblCompanyAboutUsId.Text);
            }
            companyAbout.CompanyId = Convert.ToInt32(lblCompanyId.Text);
            companyAbout.Heading = txtHeading.Text;
            companyAbout.Detail = txtDetail.Text;
            companyAbout.IsActive = true;
            return companyAbout;
        }
        public bool DeleteCompanyAboutUs(int companyAboutUsId)
        {
            return new AppManager().DeleteCompanyAboutUsByCompanyAboutUsId(companyAboutUsId);
        }

        
    }
}