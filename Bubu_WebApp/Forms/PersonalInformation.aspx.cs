using AppController;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class PersonalInformation : BubuBasePage
    {
        public string returnMessage = "";
        public AppManager appmanager;
        public MiscellaneousOperation misop;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                FillCountry();
                FillDomicile();
                GetallWorkExperience(SessionHelper.getUserSession().userid);
            }

        }
        public void FillDomicile()
        {
            misop = new MiscellaneousOperation();
            misop.GetDomiciles(ref ddlDomicile);
        }

        public void FillCountry()
        {
            misop = new MiscellaneousOperation();
            misop.fillCountries(ref ddlCountry, ref returnMessage);
        }
        public void GetallWorkExperience(int userid)
        {
            appmanager = new AppManager();
            User user = appmanager.GetallWorkExperience(userid, ref returnMessage);
            if (user != null)
            {

                filluser(user);
                if (user.UserWorkExperiences.Count > 0)
                {
                    UserWorkExperience currentworkexperience = user.UserWorkExperiences.Where(a => a.IsCurrentJob == true).FirstOrDefault();
                    if (currentworkexperience != null && currentworkexperience.UserWorkExperienceid > 0)
                    {
                        fillWorkExperience(currentworkexperience);

                    }
                    else
                    {
                        divemployeement.Style["Display"] = "none";
                    }
                }
            }
        }
        public void filluser(User user)
        {
            txtUserName.Text = user.UserName;
            txtFirstName.Text = user.FirstName;
          //  txtMiddleName.Text = user.MiddleName;
            txtLastName.Text = user.LastName;
            txtAddress.Text = user.UserAddress;
            txtBirthDate.Text = user.DateOfBirth != null ? HelperFunction.Dateformat((DateTime)user.DateOfBirth) : "";
            txtEmail.Text = user.EmailAddress;
            txtContactNo.Text = user.ContactNumber;
            if (user.DomicileId != null)
            {
                ddlDomicile.SelectedValue = user.DomicileId.ToString();
            }
            if (user.CountryId != null)
            {
                ddlCountry.SelectedValue = user.CountryId.ToString();
            }
            chboxMarried.Checked = user.IsMarried;
            if (user.Gender == EnumGender.MALE.ToString())
            {
                rbtnMale.Checked = true;
            }
            else
            {
                rbtnFeMale.Checked = true;
            }
        }
        public void fillWorkExperience(UserWorkExperience userWorkexperience)
        {
            txtCompany.Text = userWorkexperience.Company;
            txtPosition.Text = userWorkexperience.Position;
            txtFunction.Text = userWorkexperience.JobFunction;
            txtJoblocation.Text = userWorkexperience.JobLocation;
            txtJobFrom.Text = HelperFunction.Dateformat((DateTime)userWorkexperience.JobFrom);
            rbtnemployeed.Checked = true;
            divemployeement.Visible = true;
        }
        public void formClear()
        {
            txtUserName.Text = "";
            txtFirstName.Text = "";
           // txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtBirthDate.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            txtCompany.Text = "";
            txtPosition.Text = "";
            txtFunction.Text = "";
            txtJoblocation.Text = "";
            txtJobFrom.Text = "";
            // txtDomicile.Text = "";
            ddlDomicile.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            chboxMarried.Checked = false;
            rbtnMale.Checked = true;
            txtAddress.Text = "";
        }
        public User formToObject()
        {
            User user = new User();
            user.Userid = SessionHelper.getUserSession().userid;
            user.UserName = txtUserName.Text;
            user.FirstName = txtFirstName.Text;
           // user.MiddleName = txtMiddleName.Text;
            user.LastName = txtLastName.Text;
            user.DateOfBirth = Convert.ToDateTime(txtBirthDate.Text);
            user.EmailAddress = txtEmail.Text;
            user.ContactNumber = txtContactNo.Text;
            //user.Domicile = txtDomicile.Text;
            user.DomicileId = Convert.ToInt32(ddlDomicile.SelectedValue);
            user.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            user.IsMarried = chboxMarried.Checked;
            user.UserAddress = txtAddress.Text;
            user.Gender = rbtnMale.Checked ? EnumGender.MALE.ToString() : EnumGender.FEMALE.ToString();
            if (rbtnemployeed.Checked)
            {
                UserWorkExperience workexperience = new UserWorkExperience();
                List<UserWorkExperience> lstWorkExperience = new List<UserWorkExperience>();
                workexperience.UserId = SessionHelper.getUserSession().userid;
                workexperience.Company = txtCompany.Text;
                workexperience.Position = txtPosition.Text;
                workexperience.JobFunction = txtFunction.Text;
                workexperience.JobLocation = txtJoblocation.Text;
                workexperience.IsCurrentJob = true;
                workexperience.IsActive = true;
                workexperience.JobFrom = Convert.ToDateTime(txtJobFrom.Text);
                // lstWorkExperience.Add(workexperience);
                user.UserWorkExperiences = lstWorkExperience;
                user.UserWorkExperiences.Add(workexperience);
            }
            else
            {
            }
            return user;


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                appmanager = new AppManager();
                if (appmanager.UpdateUserAndworkCurrentExperienceByUserId(formToObject(), ref returnMessage))
                {
                    //=====save message
                    formClear();
                    GetallWorkExperience(SessionHelper.getUserSession().userid);
                    Response.Redirect(Page.Request.Url.ToString());
                }
                else
                {
                    //===fail message

                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileMgmt.aspx");
        }
    }
}