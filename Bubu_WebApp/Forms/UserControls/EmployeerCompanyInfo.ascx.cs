using AppController;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class EmployeerCompanyInfo : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public CompanyInformation companyInformtion;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }

        public void FormLoad(int userId)
        {
            appmanager = new AppManager();
            companyInformtion = appmanager.GetCompanyInformationByUserId(userId);
            if (companyInformtion != null && companyInformtion.CompanyId > 0)
            {
                ObjectToForm(companyInformtion);
            }
            //misop = new MiscellaneousOperation();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            companyInformtion = new CompanyInformation();
            appmanager = new AppManager();
            if (formToObject(ref companyInformtion))
            {
                if (appmanager.SaveCompanyInformation(companyInformtion, ref returnMessage))
                {
                    lblMessage.Text = "Record has been saved successfully";
                    // FormReset();
                }
                else
                {
                    lblMessage.Text = returnMessage;
                }
            }

        }
        public void FormReset()
        {
            lblCompanyId.Text = "";
            txtCompany.Text = "";
            txtCompanyAddress.Text = "";
            txtContactNo.Text = "";
            imgFileUpload.ImageUrl = "";
            txtSector.Text = "";


        }

        public bool formToObject(ref CompanyInformation companyInformtion)
        {
            if (lblCompanyId.Text != null && lblCompanyId.Text != "")
            {
                companyInformtion.CompanyId = Convert.ToInt32(lblCompanyId.Text);
            }
            else if (!fuplLogo.HasFile)
            {
                lblMessage.Text = "Please select Company logo";
                return false;
            }
            if (fuplLogo.HasFile)
            {
                string filePath = fuplLogo.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filename);
                string contenttype = MisOp.getContentType(extension);

                List<DocumentFormatAllow> lstDocumentFormatAllow = appmanager.getAllDocumentFormatAllowByDocumentType(Convert.ToInt32(Enum_DocumentCategory.PROFILEPIC));
                if (lstDocumentFormatAllow.Where(a => a.DocumentFormat.ToUpper() == extension.ToUpper()).FirstOrDefault() == null)
                {
                    lblMessage.Text = "Please select one of the mentioned format for Company logo upload.";
                    lblMessage.Text += string.Join(",", lstDocumentFormatAllow.Select(a => a.DocumentFormat).ToList());//lst .Aggregate((a, x) => a + "," + x);
                    return false;
                }
                Stream fs = fuplLogo.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                companyInformtion.CompanyContentData = bytes;
                companyInformtion.CompanyContentType = contenttype;
                companyInformtion.Companyformat = extension;
                companyInformtion.fileName = filename;
            }
            companyInformtion.CompanyName = txtCompany.Text;
            companyInformtion.CompanyAddress = txtCompanyAddress.Text;
            companyInformtion.CompanyContactNumber = txtContactNo.Text;
            companyInformtion.UserId = SessionHelper.getUserSession().userid;
            companyInformtion.IsActive = true;
            companyInformtion.CompanySector = txtSector.Text;
            return true;
        }
        public void ObjectToForm(CompanyInformation companyInformtion)
        {
            MiscellaneousOperation misOps = new MiscellaneousOperation();
            lblCompanyId.Text = companyInformtion.CompanyId.ToString();
            txtCompany.Text = companyInformtion.CompanyName;
            txtCompanyAddress.Text = companyInformtion.CompanyAddress;
            txtContactNo.Text = companyInformtion.CompanyContactNumber;
            imgFileUpload.ImageUrl = "";
            if (MisOp.IsImageFileFormat(companyInformtion.Companyformat))
            {
                imgFileUpload.ImageUrl = misOps.GetImage(companyInformtion.CompanyContentData);
            }
            else
            {
                imgFileUpload.ImageUrl = MisOp.GetImageURL(companyInformtion.Companyformat);
            }
            txtSector.Text = companyInformtion.CompanySector;
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeEmployeer.aspx");
        }
    }
}