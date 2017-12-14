using AppController;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class PersonalInformationControl : System.Web.UI.UserControl
    {
        public string returnMessage = "";
        public AppManager appmanager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetallWorkExperience(SessionHelper.getUserSession().userid);
            }

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
                }
            }
        }

        public void filluser(User user)
        {
            lblUserName.Text = user.UserName;
            lblFirstName.Text = user.FirstName;
            lblMiddleName.Text = user.MiddleName;
            lblLastName.Text = user.LastName;
            lblBirthDate.Text = user.DateOfBirth!=null? HelperFunction.Dateformat((DateTime)user.DateOfBirth):"";
            lblEmail.Text = user.EmailAddress;
            lblContactNo.Text = user.ContactNumber;
            //lblDomicile.Text = user.Domicile;
            lblDomicile.Text = user.Domicile != null ? user.Domicile.DomicileName : "";
            chboxMarried.Checked = user.IsMarried;
            if (user.Country != null)
            {
                lblCountry.Text = user.Country.CountryName;
            }
            lblGender.Text = user.Gender.ToString();

        }
        public void fillWorkExperience(UserWorkExperience userWorkexperience)
        {
            lblCompany.Text = userWorkexperience.Company;
            lblPosition.Text = userWorkexperience.Position;
            lblFunction.Text = userWorkexperience.JobFunction;
            lblJoblocation.Text = userWorkexperience.JobLocation;
            lblJobStart.Text = HelperFunction.Dateformat((DateTime)userWorkexperience.JobFrom);
            rbtnemployeed.Checked = true;
        }
    }
}