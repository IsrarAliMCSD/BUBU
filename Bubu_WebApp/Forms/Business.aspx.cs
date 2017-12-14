using DAOClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class Business : BubuBasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                DLSCertificate.documentTypeName = Enum_DocumentTypeId.Certificates.ToString();
                DLSDiploma.documentTypeName = Enum_DocumentTypeId.Diploma.ToString();
                DLSOtherDocument.documentTypeName = Enum_DocumentTypeId.Other_Documents.ToString().Replace('_', ' ');
                DLSCertificate.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Certificates);
                DLSDiploma.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Diploma);
                DLSOtherDocument.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Other_Documents);
                CurriculamVitaeControl.editVisible = true;

                //CurriculamVitaeControl
            }
        }
        protected void btnEditDocuments_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentUploadMgmt.aspx");
        }
    }
}