using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class CurriculamVitaeControl : System.Web.UI.UserControl
    {
        public bool editVisible { get; set; }
        public int CVUserId { get; set; }
        public string returnMessage = "";
        public AppManager appmanager;
        public MiscellaneousOperation misop;
        public UserQualification userQualification;
        public List<UserHobby> userHobbies;
        public List<UserSkill> userSkills;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CVUserId != null && CVUserId>0)
                {
                    FormsLoad(CVUserId);
                    PersonalInformationForCVControl1.CVUserId = CVUserId;
                }
                else
                {
                    FormsLoad(SessionHelper.getUserSession().userid);
                }
                ControlVisibility();
            }
        }
        public void ControlVisibility()
        {
            btnEditPersonalDetail.Visible = editVisible;
            btnEditSchoolEducation.Visible = editVisible;
            btnEditWorkExperience.Visible = editVisible;
            btnLanguageEdit.Visible = editVisible;
            btnAdditionalSkill.Visible = editVisible;
            btnEditInterestAndHobby.Visible = editVisible;
            btnReference.Visible = editVisible;
            btnCommencement.Visible = editVisible;
        }
        public void FormsLoad(int userid)
        {
            GetUserQualification(userid);
            GetUserExperienceByUserId(userid);
            GetUserLanguageByUserId(userid);
            GetUserDetail(userid);
            FillUserReference(userid);
            FillUserHobbies(userid);
            FillUserSkills(userid);
        }
        public void FillUserHobbies(int userId)
        {
            appmanager = new AppManager();
            userHobbies = appmanager.GetUserHobbiesByUserId(userId, ref returnMessage);
            rptruserHobbies.DataSource = userHobbies;
            rptruserHobbies.DataBind();
        }

        public void FillUserSkills(int userId)
        {
            appmanager = new AppManager();
            userSkills = appmanager.GetUserSkillsByUserId(userId, ref returnMessage);
            rptruserSkills.DataSource = userSkills;
            rptruserSkills.DataBind();
        }
        private void GetUserDetail(int userId)
        {
            appmanager = new AppManager();
            User user = appmanager.getUserByUserId(userId, ref returnMessage);
            if (user != null && user.CommencementID != null)
            {
                lblCommencement.Text = user.Commencement.CommencementDescription.ToString();
            }
        }
        public void GetUserLanguageByUserId(int userId)
        {
            appmanager = new AppManager();
            List<UserLanguage> lstUserLanguage = appmanager.GetUserLanguageByUserId(userId, ref returnMessage);
            rptLanguage.DataSource = lstUserLanguage;
            rptLanguage.DataBind();
        }
        public void GetUserExperienceByUserId(int userid)
        {
            appmanager = new AppManager();
            List<UserWorkExperience> lstUserWorkExperience = appmanager.GetUserExperienceByUserId(userid, ref returnMessage);
            rptrWorkExperience.DataSource = lstUserWorkExperience;
            rptrWorkExperience.DataBind();
        }
        public void GetUserQualification(int userid)
        {

            appmanager = new AppManager();
            List<UserQualification> lstUserQualification = appmanager.GetQualificationByUserId(userid, ref returnMessage);
            rptrUserQualification.DataSource = lstUserQualification;
            rptrUserQualification.DataBind();

        }

        public void FillUserReference(int userId)
        {
            appmanager = new AppManager();
            List<UserReference> userReferences = appmanager.GetUserReferenceByUserId(userId, ref returnMessage);
            rptruserreference.DataSource = userReferences;
            rptruserreference.DataBind();
        }

        public void FillCountry()
        {
            misop = new MiscellaneousOperation();
            // misop.fillCountries(ref ddlfCountry, ref returnMessage);

        }
        public void GetQualification()
        {
            misop = new MiscellaneousOperation();
            // misop.filltQualification(ref ddlfQualification, ref returnMessage);
        }

        protected void btnEditSchoolEducation_Click(object sender, EventArgs e)
        {
            Response.Redirect("QualificationMgmt.aspx");
        }

        protected void btnEditWorkExperience_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserWorkExperienceMgmt.aspx");
        }

        protected void btnLanguageEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLanguageMgmt.aspx");
        }

        protected void btnEditPersonalDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalInformation.aspx");

        }

        protected void btnCommencement_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserCommencement.aspx");

        }

        protected void btnReference_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserReferenceMgmt.aspx");
        }

        protected void btnEditInterestAndHobby_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHobbyMgmt.aspx");
        }

        protected void btnAdditionalSkill_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSkillMgmt.aspx");
        }
    }
}