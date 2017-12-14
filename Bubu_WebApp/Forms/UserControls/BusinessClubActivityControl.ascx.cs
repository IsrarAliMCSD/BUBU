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
    public partial class BusinessClubActivityControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misOps;
        public BusinessClubActivity businessClubActivity;
        // public BusinessClub businessClub;
        //public List<BusinessClub> businessClubs;
        //public BusinessClubMember businessClubMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    int businessClubId = 0;
                    businessClubId = Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
                    if (businessClubId > 0)
                    {
                        FormLoad(SessionHelper.getUserSession().userid, businessClubId);
                        btnSave.Visible = true;
                        btnCancel.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnCancel.Visible = false;
                    }
                }


            }

        }
        private void FormLoad(int userId, int businessClubId)
        {
            misOps = new MiscellaneousOperation();
           // FillBusinessClubByUserId(misOps, userId);
            GetBusinessActivityMessageTypes(misOps);
            //==============set business club from query string
          



        }
        public void FillBusinessClubByUserId(MiscellaneousOperation misop, int userId)
        {
            misop.FillBusinessClubByUserId(ref ddlClubName, userId);
        }
        public void GetBusinessActivityMessageTypes(MiscellaneousOperation misop)
        {
            misop.GetBusinessActivityMessageTypes(ref ddlActivityType);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
            Response.Redirect("~/Forms/BusinessClubEvent.aspx?id=" + Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString())));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            if (appmanager.SaveBusinessActivity(FormToObjet(), ref returnMessage))
            {
                MisOp.ShowMessage(this, returnMessage, "Business Event", true);
                FormReset();
                //  FormLoad(SessionHelper.getUserSession().userid);
            }
            else
            {
                lblError.Text = returnMessage;
            }

        }
        public void FormReset()
        {
            ddlActivityType.SelectedIndex = 0;
            //ddlClubName.SelectedIndex = 0;
            txtActivityDate.Text = "";
            txtLocation.Text = "";
            txtSubject.Text = "";
            lblError.Text = "";
            lblBusinessClubActivityId.Text = "";
            txtDeadLine.Text = "";
        }
        private BusinessClubActivity FormToObjet()
        {
            businessClubActivity = new BusinessClubActivity();
            if (lblBusinessClubActivityId.Text != "")
            {
                businessClubActivity.BusinesClubActivityId = Convert.ToInt32(lblBusinessClubActivityId.Text);
            }
            businessClubActivity.BusinessClubId = Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));//Convert.ToInt32(ddlClubName.SelectedValue);
            businessClubActivity.BusinessClubMessageTypeId =  Convert.ToInt32(ddlActivityType.SelectedValue);
            businessClubActivity.Subject = txtSubject.Text;
            businessClubActivity.IsActive = true;
            businessClubActivity.Description = txtLocation.Text;
            if (txtActivityDate.Text != null && txtActivityDate.Text != "")
            {
                businessClubActivity.ActivityDate = Convert.ToDateTime(txtActivityDate.Text);
            }
            if (txtDeadLine.Text != null && txtDeadLine.Text != "")
            {
                businessClubActivity.DeadLine = Convert.ToDateTime(txtDeadLine.Text);
            }
            return businessClubActivity;
        }
    }
}