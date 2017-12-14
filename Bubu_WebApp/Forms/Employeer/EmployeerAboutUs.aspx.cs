using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.Employeer
{
    public partial class EmployeerAboutUs : BubuBasePage
    {
        public AppManager appmanager;
        public List<CompanyAbout> companyAbouts;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
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
            rptrAboutUs.DataSource = companyAbouts;
            rptrAboutUs.DataBind();
        }

        protected void btnEditCompanyAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeerAboutUsMgmt.aspx");
        }
    }
}