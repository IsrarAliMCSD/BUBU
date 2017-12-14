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
    public partial class BusinessClubControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misOps;
        public BusinessClub businessClub;
        public List<BusinessClub> businessClubs;
        public BusinessClubMember businessClubMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            businessClub = new BusinessClub();
            if (FormToObjet(ref businessClub))
            {
                if (appmanager.SaveBusinessClub(businessClub, ref returnMessage))
                {
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                }
                else
                {
                    lblError.Text = returnMessage;
                }
            }
            else
            {
                lblError.Text = returnMessage;
            }
        }

        private void FormLoad(int userId)
        {
           // FillBusinessClub(userId);
        }
        public void FillBusinessClub(int userId)
        {
            appmanager = new AppManager();
            businessClubs = appmanager.GetBusinessClubs(ref returnMessage);
            foreach (var businessClubObj in businessClubs)
            {
                if (businessClubObj.UserCreatedId != userId)
                {
                    businessClubObj.IsActive = false;
                }
            }
           // gvBusinessClub.DataSource = businessClubs;
          //  gvBusinessClub.DataBind();

        }
        private void FormReset()
        {
            txtAbout.Text = "";
            lblBusinessClubID.Text = "";
            txtBusinessClubName.Text = "";
           // txtPurpose.Text = "";
            // btnBack.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = true;
        }

        private bool FormToObjet(ref BusinessClub businessClub)
        {
            appmanager = new AppManager();
            if (lblBusinessClubID.Text != "")
            {
                businessClub.BusinessClubId = Convert.ToInt32(lblBusinessClubID.Text);
            }
            else if (!fupLogo.HasFile)
            {
                lblError.Text = "Please select file";
                return false;
            }
            if (fupLogo.HasFile)
            {
                string filePath = fupLogo.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filename);
                string contenttype = MisOp.getContentType(extension);
                List<DocumentFormatAllow> lstDocumentFormatAllow = appmanager.getAllDocumentFormatAllowByDocumentType(Convert.ToInt32(Enum_DocumentCategory.LOGOPIC));
                if (lstDocumentFormatAllow.Where(a => a.DocumentFormat.ToUpper() == extension.ToUpper()).FirstOrDefault() == null)
                {
                    lblError.Text = "Please select one of the mentioned format for Logo upload.";
                    lblError.Text += string.Join(",", lstDocumentFormatAllow.Select(a => a.DocumentFormat).ToList());//lst .Aggregate((a, x) => a + "," + x);
                    return false;
                }
                Stream fs = fupLogo.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                businessClub.ContentData = bytes;
                businessClub.ContentType = contenttype;
                businessClub.format = extension;

            }
            businessClub.About = txtAbout.Text;
            businessClub.BusinessClubName = txtBusinessClubName.Text;
            businessClub.IsActive = true;
           // businessClub.Purpose = txtPurpose.Text;
            businessClub.UserCreatedId = SessionHelper.getUserSession().userid;
            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //FormReset();
            Response.Redirect("~/Forms/BusinessClubMgmt.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
        public string GetImage(object img, object format)
        {
            if (img == null)
            {
                return "";
            }
            if (!MisOp.GetImageTypeList().Contains(format.ToString().ToUpper()))
            {
                return MisOp.GetImageURL(format.ToString().ToUpper());
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }


        }

        public BusinessClub GetBusinessClubById(int businessClubId)
        {
            appmanager = new AppManager();
            return appmanager.GetBusinessClub(businessClubId, ref returnMessage);
        }
        protected void gvBusinessClub_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int businessClubId = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.ToUpper() == "GRIDVIEW")
            {
                //  btnBack.Visible = false;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                ObjectToForm(GetBusinessClubById(businessClubId));
            }
            else if (e.CommandName.ToUpper() == "GRIDEDIT")
            {
                // btnBack.Visible = false;
                btnCancel.Visible = true;
                btnSave.Visible = true;
                ObjectToForm(GetBusinessClubById(businessClubId));
            }

            else if (e.CommandName.ToUpper() == "GRIDJOIN")
            {
                this.InsertBusinessClubMember(Convert.ToInt32(e.CommandArgument.ToString()), SessionHelper.getUserSession().userid);
            }
            else if (e.CommandName.ToUpper() == "CLUBDETAIL")
            {
                Response.Redirect("~/Forms/BusinessClubDetail.aspx?idx=" +  HelperFunction.EncryptData(e.CommandArgument.ToString()));

            }
        }

        public void InsertBusinessClubMember(int businessCluId, int UserId)
        {
            appmanager = new AppManager();
            businessClubMember = new BusinessClubMember();
            businessClubMember.MemberId = UserId;
            businessClubMember.BusinessClubId = businessCluId;
            businessClubMember.IsActive = true;
            if (appmanager.InsertBusinessClubMember(businessClubMember, ref returnMessage))
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
            lblError.Text = returnMessage;

        }
        public void ObjectToForm(BusinessClub businessClub)
        {
            misOps = new MiscellaneousOperation();
            lblBusinessClubID.Text = businessClub.BusinessClubId.ToString();
            txtAbout.Text = businessClub.About;
            txtBusinessClubName.Text = businessClub.BusinessClubName;
           // txtPurpose.Text = businessClub.Purpose;
            if (MisOp.IsImageFileFormat(businessClub.format))
            {
                imgLogoUpload.ImageUrl = misOps.GetImage(businessClub.ContentData);
            }
            else
            {
                imgLogoUpload.ImageUrl = MisOp.GetImageURL(businessClub.format);
            }

        }
    }
}