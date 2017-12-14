using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class CompanyInfo : BubuBasePage
    {
         protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                FormLoad();
            }

        }
         private void FormLoad()
         {
             if (Request.QueryString.Count > 0)
             {
                 int companyId = 0;
                 companyId = int.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
                 if (companyId > 0)
                 {
                     JobSearchControl1.companyId = companyId;
                 }
             }
         }
    }
}