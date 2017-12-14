using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace Bubu_WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Culture"].ToString());

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}