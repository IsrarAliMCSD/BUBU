using AppController;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class EmployeerHomeController : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public CompanyInformation companyInformtion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormLoadByRoleApply();

            }
        }
        public void FormLoadByUserId(int userId)
        {
            appmanager = new AppManager();
            companyInformtion = appmanager.GetCompanyInformationByUserId(userId);
            if (companyInformtion != null && companyInformtion.CompanyId > 0)
            {
                ObjectToForm(companyInformtion);
            }
            //misop = new MiscellaneousOperation();
        }
        public void ObjectToForm(CompanyInformation companyInformtion)
        {
            MiscellaneousOperation misOps = new MiscellaneousOperation();

            lblCompanyName.Text = companyInformtion.CompanyName;
            lblCompanyAddress.Text = companyInformtion.CompanyAddress;
            lblContactNo.Text = companyInformtion.CompanyContactNumber;
            imgFileUpload.ImageUrl = "";
            if (MisOp.IsImageFileFormat(companyInformtion.Companyformat))
            {
                imgFileUpload.ImageUrl = misOps.GetImage(companyInformtion.CompanyContentData);
            }
            else
            {
                imgFileUpload.ImageUrl = MisOp.GetImageURL(companyInformtion.Companyformat);
            }
           
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyInformationEdit.aspx");
        }

        public void FormLoadByRoleApply()
        {
            if (SessionHelper.getUserSession().AccountTye.ToUpper() == UserAccountType.EMPLOYEE.ToString())
            {
                if (Request.QueryString.Count == 1)
                {
                    int companyId = 0;
                    companyId = int.Parse(HelperFunction.Func_Decrypt(Request.QueryString[0].ToString()));
                    if (companyId > 0)
                    {
                        FormLoadByCompanyId(companyId);
                    }
                }
            }
            else if (SessionHelper.getUserSession().AccountTye.ToUpper() == UserAccountType.EMPLOYER.ToString())
            {
                if (Request.QueryString.Count == 1)
                {
                    int companyId = 0;
                    companyId = int.Parse(HelperFunction.Func_Decrypt(Request.QueryString[0].ToString()));
                    if (companyId > 0)
                    {
                        FormLoadByCompanyId(companyId);
                    }
                }
                else
                {
                    FormLoadByUserId(SessionHelper.getUserSession().userid); btnEdit.Visible = true;
                }
            }
          
               
        }
        public void FormLoadByCompanyId(int companyId)
        {
            appmanager = new AppManager();
            companyInformtion = appmanager.GetCompanyInformationByCompanyId(companyId);
            if (companyInformtion != null && companyInformtion.CompanyId > 0)
            {
                ObjectToForm(companyInformtion);
            }
        }
    }
}