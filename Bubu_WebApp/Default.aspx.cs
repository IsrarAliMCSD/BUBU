using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        public AppManager appmanager;
        string ErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RetreiveCookieValues();
            }
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = UserLogin(txtEmailLogin.Text, txtPassword.Text, ref ErrorMessage);
            if (user != null)
            {
                
                if (user.AccountStatus == Convert.ToInt32(AccountStatus.Active))
                {
                    if (chbRememberPassword.Checked)
                    {
                        StoreUserCredentialCookie();
                    }
                    Session[SessionNames.S_User.ToString()] = user;
                    FormRedirect((Account_Type)user.AccountTypeId);
                    
                }
            }
            else
            {
                MisOp.ShowMessage(this, ErrorMessage,"Login", false);
            }

           
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            divforgotPassword.Visible = false;
            divSignUp.Visible = true;
            divLogin.Visible = false;
        }

        #region methods
        public void RetreiveCookieValues()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                txtEmailLogin.Text = reqCookies["Email"].ToString();
                txtPassword.Attributes.Add("value", reqCookies["Password"].ToString());
            }

        }
        public void StoreUserCredentialCookie()
        {
            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["Email"] = txtEmailLogin.Text;
            userInfo["Password"] = txtPassword.Text;
            userInfo.Expires.Add(new TimeSpan(168, 0, 0));
            Response.Cookies.Add(userInfo);
        }
        public User UserLogin(string userName, string password, ref string ErrorMessage)
        {
            appmanager = new AppManager();
            return appmanager.UserLogin(userName, password, ref ErrorMessage);
        }



        #endregion

        protected void btnCancelforgotpassword_Click(object sender, EventArgs e)
        {
            divforgotPassword.Visible = false;
            divSignUp.Visible = false;
            divLogin.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divforgotPassword.Visible = false;
            divSignUp.Visible = false;
            divLogin.Visible = true;
        }

        protected void lbtnforgotPassword_Click(object sender, EventArgs e)
        {
            divforgotPassword.Visible = true;
            divSignUp.Visible = false;
            divLogin.Visible = false;
        }

        protected void btnfoorgotPassword_Click(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        public void FormRedirect(Account_Type Actyps)
        {
            switch(Actyps){
                case Account_Type.Administrator:
                    Response.Redirect("~/Forms/WebForm1.aspx");
                    break;
                //case Account_Type.User:
                //    Response.Redirect("~/Forms/WebForm1.aspx");
                //    break;

            }
        }
    }
}