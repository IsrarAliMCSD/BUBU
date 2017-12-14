using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp
{
    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DrpLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Culture"] = DrpLanguages.SelectedValue;
            Response.Redirect("WebForm1.aspx");
        }
 
    }
}