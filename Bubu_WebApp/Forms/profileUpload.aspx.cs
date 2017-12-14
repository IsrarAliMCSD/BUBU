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

namespace Bubu_WebApp.Forms
{
    public partial class profileUpload : BubuBasePage
    {
        public string returnMessage = "";
        public AppManager appmanager;
        public MiscellaneousOperation msOp;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                fillUserImage(SessionHelper.getUserSession().userid);

            }
        }
        public void fillUserImage(int userid)
        {
            msOp = new MiscellaneousOperation();
            User user = msOp.getUserByUserId(userid, ref returnMessage);
            imgFileUpload.ImageUrl = msOp.GetImage(user.ContentData);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            if (!fuplProfile.HasFile)
            {
                lblMessage.Text = "Please select file";
                return;
            }
            string filePath = fuplProfile.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string extension = Path.GetExtension(filename);
            string contenttype = MisOp.getContentType(extension);
            List<DocumentFormatAllow> lstDocumentFormatAllow = appmanager.getAllDocumentFormatAllowByDocumentType(Convert.ToInt32(Enum_DocumentCategory.PROFILEPIC));

            if (lstDocumentFormatAllow.Where(a => a.DocumentFormat.ToUpper() == extension.ToUpper()).FirstOrDefault() == null)
            {
                lblMessage.Text = "Please select one of the mentioned format for profile pic upload.";
                lblMessage.Text += string.Join(",", lstDocumentFormatAllow.Select(a => a.DocumentFormat).ToList());//lst .Aggregate((a, x) => a + "," + x);
                return;
            }

            Stream fs = fuplProfile.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            if (appmanager.updateProfilePic(SessionHelper.getUserSession().userid, bytes, contenttype, extension, ref returnMessage))
            {
                //  lblMessage.Text = "Profile pic saved successfully"; master .find control and update profile pic
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                lblMessage.Text = returnMessage;
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileMgmt.aspx");
        }

    }
}