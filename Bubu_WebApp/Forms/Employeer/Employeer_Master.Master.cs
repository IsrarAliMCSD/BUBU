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
    public partial class Employeer_Master : System.Web.UI.MasterPage
    {
        public AppManager appmanager; 
        public CompanyInformation companyInformtion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionNames.S_User.ToString()] == null)
            {
                Response.Redirect("~/index.aspx", true);
            }
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }
        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        public void FormLoad(int userId)
        {
            appmanager = new AppManager();
            companyInformtion = appmanager.GetCompanyInformationByUserId(userId);
            if (companyInformtion != null && companyInformtion.CompanyId > 0)
            {
                ObjectToForm(companyInformtion);
            }
        }
        public void ObjectToForm(CompanyInformation companyInformtion)
        {
            MiscellaneousOperation misOps = new MiscellaneousOperation();
            lblCompanyName.Text = companyInformtion.CompanyName;
            if (MisOp.IsImageFileFormat(companyInformtion.Companyformat))
            {
                imgCompanyLogo.ImageUrl = misOps.GetImage(companyInformtion.CompanyContentData);
            }
            else
            {
                imgCompanyLogo.ImageUrl = MisOp.GetImageURL(companyInformtion.Companyformat);
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
            //Response.Redirect("~/Login.aspx");
        }
    }
}