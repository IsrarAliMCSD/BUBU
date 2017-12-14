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
    public partial class UserCommencementControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCommencement();
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }
        public void FillCommencement()
        {
            misop = new MiscellaneousOperation();
            misop.FillCommencement(ref ddlCommencementOfJob);
        }
        public void FormLoad(int userId)
        {
            appmanager = new AppManager();
            User user = appmanager.getUserByUserId(userId, ref returnMessage);
            if (user != null && user.CommencementID != null)
            {
                ddlCommencementOfJob.SelectedValue = user.CommencementID.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            bool result = appmanager.UpdateCommencement(Convert.ToInt32(ddlCommencementOfJob.SelectedValue), SessionHelper.getUserSession().userid, ref returnMessage);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }
    }
}