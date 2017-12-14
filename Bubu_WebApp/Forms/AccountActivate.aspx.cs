using AppController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class AccountActivate : System.Web.UI.Page
    {
        public AppManager appmanager;
        string ErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    ActiveUser(Request.QueryString[0].ToString());
                }
            }
        }

        protected void btnGotoHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
        public void ActiveUser(string activationCode)
        {
            appmanager = new AppManager();
            appmanager.GetAccountActivation(activationCode, ref ErrorMessage);
            lblMessage.Text = ErrorMessage;
            
 
        }
    }
}