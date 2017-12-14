using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class DocumentUploadControl : System.Web.UI.UserControl
    {
        public string returnMessage = "";
        public AppManager appmanager;
        public DocumentUpload documentUploadObject;
        public MiscellaneousOperation misOps;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                fillDocumentType();
                fillDocumentGrid(SessionHelper.getUserSession().userid);
            }
        }

        public void fillDocumentGrid(int userid)
        {
            appmanager = new AppManager();
            List<DocumentUpload> lstUploadDocument = appmanager.getAllDocumentsByUserId(userid, ref  returnMessage);
            gvDocumentList.DataSource = lstUploadDocument;
            gvDocumentList.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            ddldocumentCategory.SelectedIndex = 0;
            txtDescription.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            documentUploadObject = new DocumentUpload();
            appmanager = new AppManager();

            if (formToObject(ref documentUploadObject))
            {

                if (appmanager.SaveDocumentUpload(documentUploadObject, ref returnMessage))
                {
                    lblMessage.Text = "Document has been saved successfully";
                    fillDocumentGrid(SessionHelper.getUserSession().userid);
                    FormReset();
                }
                else
                {
                    lblMessage.Text = returnMessage;
                }
            }
        }

        public void fillDocumentType()
        {
            new MiscellaneousOperation().fillDocumentType(ref ddldocumentCategory);
        }
        public bool formToObject(ref DocumentUpload documentUploadObjectParam)
        {
            appmanager = new AppManager();

            if (btnSave.Text.ToUpper() == "UPDATE")
            {
                documentUploadObjectParam.UploadDocumentId = Convert.ToInt32(lblDocumentUploadId.Text);
            }
            else if (!fuplDocument.HasFile)
            {
                lblMessage.Text = "Please select file";
                return false;
            }
            if (fuplDocument.HasFile)
            {
                string filePath = fuplDocument.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filename);
                string contenttype = MisOp.getContentType(extension);
                List<DocumentFormatAllow> lstDocumentFormatAllow = appmanager.getAllDocumentFormatAllowByDocumentType(Convert.ToInt32(ddldocumentCategory.SelectedValue));
                if (lstDocumentFormatAllow.Where(a => a.DocumentFormat.ToUpper() == extension.ToUpper()).FirstOrDefault() == null)
                {
                    lblMessage.Text = "Please select one of the mentioned format for document upload.";
                    lblMessage.Text += string.Join(",", lstDocumentFormatAllow.Select(a => a.DocumentFormat).ToList());//lst .Aggregate((a, x) => a + "," + x);
                    return false;
                }
                Stream fs = fuplDocument.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                documentUploadObjectParam.ContentData = bytes;
                documentUploadObjectParam.ContentType = contenttype;
                documentUploadObjectParam.format = extension;
                documentUploadObjectParam.fileName = filename;
            }

            documentUploadObjectParam.Userid = SessionHelper.getUserSession().userid;
            documentUploadObjectParam.DocumentCategoryid = Convert.ToInt32(ddldocumentCategory.SelectedValue);

            documentUploadObjectParam.Description = txtDescription.Text;

            documentUploadObjectParam.IsActive = true;

            return true;
        }

        protected void gvDocumentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == GridCommand.GRIDDELETE.ToString())
            {

                DeleteUploadDocument(Convert.ToInt32(e.CommandArgument.ToString()));
                fillDocumentGrid(SessionHelper.getUserSession().userid);
            }
            else if (e.CommandName == GridCommand.GRIDDOWNLOAD.ToString())
            {
                documentUploadObject = GetdocumentByUploadDocumentId(Convert.ToInt32(e.CommandArgument.ToString()));
                MisOp.DownloadFile(documentUploadObject.ContentType,
                    String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now) + documentUploadObject.format
                    , documentUploadObject.ContentData);
                FormReset();
            }
            else if (e.CommandName == GridCommand.GRIDEDIT.ToString())
            {
                lblDocumentUploadId.Text = e.CommandArgument.ToString();
                documentUploadObject = GetdocumentByUploadDocumentId(Convert.ToInt32(e.CommandArgument.ToString()));
                EditUploadDocument(documentUploadObject);
            }
        }

        public void EditUploadDocument(DocumentUpload documentUploadObj)
        {
            misOps = new MiscellaneousOperation();
            ddldocumentCategory.SelectedValue = documentUploadObj.DocumentCategoryid.ToString();
            txtDescription.Text = documentUploadObj.Description.ToString();
            btnSave.Text = "Update";
            if (MisOp.IsImageFileFormat(documentUploadObj.format))
            {
                imgFileUpload.ImageUrl = misOps.GetImage(documentUploadObj.ContentData);
            }
            else
            {
                imgFileUpload.ImageUrl = MisOp.GetImageURL(documentUploadObj.format);
            }

        }


        public bool DeleteUploadDocument(int uploadDocumentId)
        {
            appmanager = new AppManager();
            return appmanager.DeleteDocumentUpload(uploadDocumentId, ref returnMessage);

        }
        public DocumentUpload GetdocumentByUploadDocumentId(int UploadDocumentId)
        {
            appmanager = new AppManager();
            return appmanager.GetdocumentByUploadDocumentId(UploadDocumentId, ref  returnMessage);
        }
        public void FormReset()
        {
            ddldocumentCategory.SelectedIndex = 0;
            txtDescription.Text = "";
            lblDocumentUploadId.Text = "";
            btnSave.Text = "Save";
            imgFileUpload.ImageUrl = "";
        }

        protected void gvDocumentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DocumentUpload docRow = (DocumentUpload)e.Row.DataItem;
                Image imgfile = (Image)e.Row.FindControl("imgfile");
                if (!MisOp.GetImageTypeList().Contains(docRow.format.ToUpper()))
                {
                    imgfile.ImageUrl = MisOp.GetImageURL(docRow.format.ToUpper());
                }
                else
                {
                    imgfile.ImageUrl = new MiscellaneousOperation().GetImage(docRow.ContentData);
                }

            }
        }



    }
}