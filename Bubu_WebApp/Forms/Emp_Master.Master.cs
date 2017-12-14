using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class Emp_Master : System.Web.UI.MasterPage
    {
        public string returnMessage = "";
        public AppManager appmanager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionNames.S_User.ToString()] == null)
            {
                Response.Redirect("~/index.aspx", true);
            }
            if (!IsPostBack)
            {
                GetallWorkExperience(SessionHelper.getUserSession().userid);
            }
        }

        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
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
                    clearWorkExperience();
                    UserWorkExperience currentworkexperience = user.UserWorkExperiences.Where(a => a.IsCurrentJob == true).FirstOrDefault();
                    if (currentworkexperience != null && currentworkexperience.UserWorkExperienceid > 0)
                    {
                        fillWorkExperience(currentworkexperience);
                    }
                    if (user.UserQualifications.Count > 0)
                    {
                        UserQualification currentUserQualification = user.UserQualifications.Where(a => a.IsActive).OrderByDescending(a => a.IsCompleted).
                           ThenByDescending(a => a.Qualification.QualificationLevel)
                           .FirstOrDefault();
                        if (currentUserQualification != null && currentUserQualification.UserQualificationId > 0)
                        {
                            fillLatestEducation(currentUserQualification);
                        }
                    }
                }
            }

        }
        public void filluser(User user)
        {
            //lblUserName.Text = user.FirstName + " " + user.LastName + "(" + user.UserName + ")";
            //lblUserName.Text = user.FirstName;
            lblUserName.Text = user.FirstName + " " + user.LastName;
            lblDOB.Text = user.DateOfBirth != null ? HelperFunction.Dateformat((DateTime)user.DateOfBirth) : "";
            //lblDomicile.Text = user.Domicile;
            lblDomicile.Text = user.Domicile != null ? user.Domicile.DomicileName : "";
            imgProfilePicture.ImageUrl = user.ContentData != null ? GetImage(user.ContentData) :
                user.Gender.ToUpper() == Gender.MALE.ToString() ? MisOp.GetDefaultProfileURL(Gender.MALE)
                : MisOp.GetDefaultProfileURL(Gender.FEMALE);
            lblUserAddress.Text = user.UserAddress;
        }
        public void fillWorkExperience(UserWorkExperience userWorkexperience)
        {
            lblCompany.Text = userWorkexperience.Company;
            lblPosition.Text = userWorkexperience.Position;
            lblFunction.Text = userWorkexperience.JobFunction;
            // lblPosition.Text = "";
        }
        public void fillLatestEducation(UserQualification userQualification)
        {
            lblLatestEducation.Text = userQualification.Qualification.QualificationName;
        }
        public void clearWorkExperience()
        {
            lblCompany.Text = "";
            lblPosition.Text = "";
            lblFunction.Text = "";
            //  lblJobLocation.Text = "";
            // lblDomicile.Text = "";
            lblPosition.Text = "";
            lblLatestEducation.Text = "";
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        [WebMethod]
        public static List<string> getEmployeeList()
        {
            return new List<string>() { "jhgf", "hgfds", "qwe" };
        }
    }
}