using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.Employeer
{
    public partial class CVmgmt : BubuBasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0 && Request.QueryString["Idx"] != null)
                {
                    int result=0;
                    int.TryParse( Request.QueryString["Idx"],out result);
                    CurriculamVitaeControl.CVUserId = result;
                }
                CurriculamVitaeControl.editVisible = false;
            }

        }
    }
}