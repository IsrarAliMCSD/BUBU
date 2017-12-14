using AppController;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp
{

    public partial class Login : System.Web.UI.Page
    {
        public AppManager appmanager;
        string ErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionNames.S_User.ToString()] != null)
            {
                
                
                //Response.Redirect("~/Forms/test1.aspx");
            }
            if (!IsPostBack)
            {
                RetreiveCookieValues();
                fillAccountType();
                FillGender();
                if (Request.QueryString.Count > 0)
                {
                    SetUserType(Request.QueryString[0]);
                }
            }
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = UserLogin(txtEmailLogin.Text, txtPassword.Text, ref ErrorMessage);
            if (user != null)
            {

                //if (user.AccountStatus == Convert.ToInt32(AccountStatus.Active))
                //{
                if (chbRememberPassword.Checked)
                {
                    StoreUserCredentialCookie();
                }
                Session[SessionNames.S_User.ToString()] = FillUserForSession(user);
                FormRedirect((Account_Type)user.AccountTypeId);

                //}
                //else
                //{
                //    MisOp.ShowMessage(this, ErrorMessage, "Login", false);
                //}
            }
            else
            {
                MisOp.ShowMessage(this, ErrorMessage, "Login", false);

            }


        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0 && Request.QueryString[0].ToUpper() == "EMPLOYEE")
            {
                Response.Redirect("employeeSignup.aspx?mode=EMPLOYEE");
            }
            else
            {
                divforgotPassword.Visible = false;
                divSignUp.Visible = true;
                divLogin.Visible = false;
            }
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
        public void FormRedirect(Account_Type Actyps)
        {
            switch (Actyps)
            {
                case Account_Type.Administrator:
                    Response.Redirect("~/Forms/EmployeeNewsInfo.aspx");//profileMgmt
                    break;
                case Account_Type.Employee:
                    Response.Redirect("~/Forms/EmployeeNewsInfo.aspx");//profileMgmt
                    break;
                case Account_Type.Employer:
                    Response.Redirect("~/Forms/employeer/HomeEmployeer.aspx");
                    break;

            }
        }

        public User FillUser()
        {
            User us = new User();
            us.UserName = txtEmailSignUp.Text;
            us.EmailAddress = txtEmailSignUp.Text;
            us.UserPassword = txtPasswordSignUp.Text;
            us.AccountTypeId = Convert.ToInt32(ddlAccountType.SelectedValue);
            us.IsActive = true;
            us.AccountStatus = 1;
            us.IsMarried = false;
            us.Gender = "EMPLOYER";// ddlGender.SelectedValue.ToString();
            //========
            if (us.Gender.ToUpper() == Gender.MALE.ToString())
            {
                us.ProfileURL = MisOp.GetDefaultProfileURL(Gender.MALE);
            }
            else
            {
                us.ProfileURL = MisOp.GetDefaultProfileURL(Gender.FEMALE);
            }
            return us;
        }
        public void fillAccountType()
        {
            new MiscellaneousOperation().fillAccountType(ref ddlAccountType);
        }

        public void FillGender()
        {
            //  new MiscellaneousOperation().FillGender(ref ddlGender);

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
        /// <summary>
        /// Reset PAssword Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnfoorgotPassword_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            User user = appmanager.GetUserByUserName(txtEmailForgotPassword.Text, ref ErrorMessage);
            if (user != null)
            {
                new EmailUtility().sendEmail(new string[] { txtEmailForgotPassword.Text }, null, "Password reset request",
                      "<p>Dear " + user.FirstName + " " + user.LastName + "</p><br> your password is " + user.UserPassword.ToString());
                MisOp.ShowMessage(this, "An email has been sent to your email address. Please read your email", "Password Recover ", false);
            }
            else
            {
                MisOp.ShowMessage(this, ErrorMessage, "Login", false);

            }
        }
        /// <summary>
        /// Signup user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            User user = appmanager.InsertUser(FillUser(), ref ErrorMessage);
            if (user != null && user.Userid > 0)
            {
                //string domainURL = System.Configuration.ConfigurationManager.AppSettings["DOMAIN"].ToString();
                //string activationcode = user.AccountActivations.ToList()[0].ActivationCode;
                //new EmailUtility().sendEmail(new string[] { txtEmailSignUp.Text }, null, "Account Activation",
                //@"<p>Dear user </p><br> your account has been created. <br> Please click on below link to activate your account<br><br>" +
                //@"<a href='" + domainURL + "/forms/AccountActivate.aspx?AC=" + activationcode + "'> Click here </a> ");
                MisOp.ShowMessage(this, ErrorMessage, "Account creation", true);
            }
            else
            {
                MisOp.ShowMessage(this, ErrorMessage, "Account creation Failed", true);

            }
            // MisOp.ShowMessage(this, ErrorMessage, "Login", false);

        }

        public UserSession FillUserForSession(User user)
        {
            UserSession usersession = new UserSession();
            usersession.emailAddress = user.EmailAddress;
            usersession.userid = user.Userid;
            usersession.userName = user.UserName;
            usersession.AccountTye = user.AccountType.AccountTitle;
            return usersession;
        }
        public void RedirectUser(int userAccountType)
        {
            if (userAccountType == Convert.ToInt32(Account_Type.Employee))
            {
                Response.Redirect("~/Forms/profileMgmt.aspx");
            }
            else if (userAccountType == Convert.ToInt32(Account_Type.Employer))
            {
                Response.Redirect("~/Forms/employeer/HomeEmployeer.aspx");

            }
        }
        public void SetUserType(string userAccountType)
        {
            ddlAccountType.SelectedValue = (userAccountType.ToUpper() == Account_Type.Employee.ToString().ToUpper()) ?
                Convert.ToInt32(Account_Type.Employee).ToString() : Convert.ToInt32(Account_Type.Employer).ToString();
            ddlAccountType.Enabled = false;


        }

    }
}