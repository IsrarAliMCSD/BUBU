using DAOClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.Employeer
{
    public partial class CertificateMgmt : BubuBasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0 && Request.QueryString["Idx"] != null)
                {
                    int result = 0;
                    int.TryParse(Request.QueryString["Idx"], out result);
                    DLSCertificate.documentTypeName = Enum_DocumentTypeId.Certificates.ToString();
                    DLSDiploma.documentTypeName = Enum_DocumentTypeId.Diploma.ToString();
                    DLSOtherDocument.documentTypeName = Enum_DocumentTypeId.Other_Documents.ToString().Replace('_', ' ');
                    DLSCertificate.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Certificates);
                    DLSDiploma.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Diploma);
                    DLSOtherDocument.documentTypeId = Convert.ToInt32(Enum_DocumentTypeId.Other_Documents);
                    DLSCertificate.CVUserId = result;
                    DLSDiploma.CVUserId = result;
                    DLSOtherDocument.CVUserId = result;
                }
            }
        }
    }
}