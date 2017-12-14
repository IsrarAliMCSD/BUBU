using AppController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class DocumentListDisplayControl : System.Web.UI.UserControl
    {
        public int documentTypeId { get; set; }
        public int CVUserId { get; set; }
        public string  documentTypeName { get; set; } 
        public string returnMessage = "";
        public AppManager appmanager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CVUserId != null && CVUserId > 0)
                {
                    FillDocumentAgainsDocumenttypeId(CVUserId);
                }
                else
                {
                    FillDocumentAgainsDocumenttypeId(SessionHelper.getUserSession().userid);
                }
                lblHeading.Text = documentTypeName;
            }

        }
        public void FillDocumentAgainsDocumenttypeId(int userId)
        {
            appmanager = new AppManager();
            rptDocumentDisplay.DataSource = appmanager.GetAllDocumentByUserIdAndDocumentType(documentTypeId, userId);
            rptDocumentDisplay.DataBind();
        }
        public string GetImage(object img, string  format)
        {
            if (!MisOp.GetImageTypeList().Contains(format.ToUpper()))
            {
               return MisOp.GetImageURL(format.ToUpper());
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }

           
        }

       
        
    }
   
}