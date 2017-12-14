using AppController;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class profileMgmt : BubuBasePage
    {
        public string returnMessage = "";
        public AppManager appmanager;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
               
                DLSCertificate.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Certificates);
                DLSDiploma.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Diploma);
                DLSOtherDocument.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Other_Documents);
            }
        }

     

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileUpload.aspx");
        }

        protected void btnUploadDocumentEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentUploadMgmt.aspx");
        }

        protected void btnEditPersonalInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalInformation.aspx");
        }

        protected void btnEditCurriculumVitae_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }

    }
}