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
    public partial class EmployeeSignUp : System.Web.UI.Page
    {
        public AppManager appmanager;
        string ErrorMessage = "";
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCountry();
                GetQualification();
                GetAllQualificationCategoriesList();
                txtfYearCompleted.Attributes["disabled"] = "disabled";
            }
        }
        public void FillCountry()
        {
            misop = new MiscellaneousOperation();
            misop.fillCountries(ref ddlfCountry, ref returnMessage);

        }

        public void GetQualification()
        {
            misop = new MiscellaneousOperation();
            misop.fillQualification(ref ddlfQualification, ref returnMessage);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            User user = appmanager.InsertUser(FillUser(), ref ErrorMessage);
            if (user != null && user.Userid > 0)
            {
                MisOp.ShowMessage(this, ErrorMessage, "Account creation", true);
                btnLogin.Visible = true;
                
            }
            else
            {
                MisOp.ShowMessage(this, ErrorMessage, "Account creation Failed", true);
                btnLogin.Visible = false;
                return;

            }
        }
        public User FillUser()
        {
            User us = new User();
            us.UserName = txtUserName.Text;
            us.FirstName = txtFirstName.Text;
            us.EmailAddress = txtEmail.Text;
            us.UserPassword = txtPassword.Text;
            us.AccountTypeId = Convert.ToInt32(Account_Type.Employee);
            us.IsActive = true;
            us.AccountStatus = 1;
            us.IsMarried = false;
            us.ContactNumber = txtContactNo.Text;
            us.Gender = "MALE";
            if (txtBirthDate.Text != "")
            {
                us.DateOfBirth = Convert.ToDateTime(txtBirthDate.Text);
            }
            //========
            if (rbtnemployeed.Checked)
            {
                UserWorkExperience workexperience = new UserWorkExperience();
                List<UserWorkExperience> lstWorkExperience = new List<UserWorkExperience>();
                //workexperience.UserId = SessionHelper.getUserSession().userid;
                workexperience.Company = txtCompany.Text;
                workexperience.Position = txtPosition.Text;
                workexperience.JobFunction = txtFunction.Text;
                workexperience.JobLocation = txtJoblocation.Text;
                workexperience.IsCurrentJob = true;
                workexperience.IsActive = true;
                // workexperience.JobFrom = Convert.ToDateTime(txtJobFrom.Text);
                // lstWorkExperience.Add(workexperience);
                workexperience.JobFrom = DateTime.Now;

                us.UserWorkExperiences = lstWorkExperience;
                us.UserWorkExperiences.Add(workexperience);
                
            }
            //===========
            UserQualification userQualification = new UserQualification();
            userQualification.QualificationId = Convert.ToInt32(ddlfQualification.SelectedValue.ToString());
            userQualification.QualificationCategoryId = Convert.ToInt32(ddlfQualificationCategory.SelectedValue.ToString());
            userQualification.CountryId = Convert.ToInt32(ddlfCountry.SelectedValue);
            userQualification.IsCompleted = chbfIsCompleted.Checked;
            if (txtfYearCompleted.Value != null && txtfYearCompleted.Value != "")
            { userQualification.CompletedYear = Convert.ToInt32(txtfYearCompleted.Value); }
            userQualification.Institution = txtfInstitute.Text;
            userQualification.Description = txtfDescription.Text;
            if (txtfPercentage.Text != "" && txtfPercentage.Text != null)
            {
                userQualification.Percentage = Convert.ToDecimal(txtfPercentage.Text);
            }
            if (txtfCGPA.Text != "" && txtfCGPA.Text != null)
            {
                userQualification.CGPA = Convert.ToDecimal(txtfCGPA.Text);
            }
            userQualification.IsActive = true;
            us.UserQualifications.Add(userQualification);
            return us;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string url = "Login.aspx";
            if (Request.QueryString.Count > 0)
            {
                url = url + "?mode=" + Request.QueryString[0].ToString();
            }
            Response.Redirect(url);
        }
        public void GetAllQualificationCategoriesList()
        {
            misop = new MiscellaneousOperation();
            misop.GetAllQualificationCategoriesList(ref ddlfQualificationCategory, ref returnMessage);

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string url = "Login.aspx";
            if (Request.QueryString.Count > 0)
            {
                url = url + "?mode=" + Request.QueryString[0].ToString();
            }
            Response.Redirect(url);

        }
    }
}