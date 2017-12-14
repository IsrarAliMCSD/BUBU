using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class BusinessClubDetail : BubuBasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    int businessClubId = 0;
                    businessClubId =Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
                    if (businessClubId > 0)
                    { BusinessClubViewControl.businessClubId = businessClubId; }
                }
            }

        }
    }
}