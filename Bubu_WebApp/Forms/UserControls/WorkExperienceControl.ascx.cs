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
    public partial class WorkExperienceControl : System.Web.UI.UserControl
    {
        public string returnMessage = "";
        public AppManager appmanager;
        public MiscellaneousOperation misop;
        public UserWorkExperience userworkExperience;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FormsLoad(SessionHelper.getUserSession().userid);
            }
        }
        public void FormsLoad(int userid)
        {
            FormReset();
            GetUserExperienceByUserId(userid);
            //  txtJobTo.Attributes["disabled"] = "disabled";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateWorkExperience())
            {
                appmanager = new AppManager();
                if (appmanager.SaveUserWorkExperience(FormToObjet(), ref returnMessage))
                {
                    FormsLoad(SessionHelper.getUserSession().userid);
                }
                else
                {
                    lblError.Text = returnMessage;
                }
            }

        }
        public UserWorkExperience FormToObjet()
        {
            userworkExperience = new UserWorkExperience();
            userworkExperience.UserId = SessionHelper.getUserSession().userid;
            userworkExperience.Company = txtCompany.Text;
            userworkExperience.JobFunction = txtJobFunction.Text;
            userworkExperience.Position = txtPosition.Text;
            userworkExperience.JobLocation = txtJobLocation.Text;
            userworkExperience.Description = txtDescription.Text;
            userworkExperience.Institution = txtInstitution.Text;
            userworkExperience.JobFrom = Convert.ToDateTime(HelperFunction.Dateformat(txtJobFrom.Text));
            userworkExperience.IsCurrentJob = chbfIscurrentjob.Checked;
            if (!chbfIscurrentjob.Checked)
            {
                userworkExperience.JobTo = Convert.ToDateTime(HelperFunction.Dateformat(txtJobTo.Text));
            }
            if (lblUserWorkExperienceId.Text != "")
            {
                userworkExperience.UserWorkExperienceid = Convert.ToInt32(lblUserWorkExperienceId.Text);
            }
            userworkExperience.IsActive = true;
            return userworkExperience;
        }

        public bool validateWorkExperience()
        {
            bool result = false;
            if (!chbfIscurrentjob.Checked && (txtJobTo.Text == null || txtJobTo.Text == ""))
            {
                lblError.Text = "Please enter job to date";
                return result;
            }
            else if (!chbfIscurrentjob.Checked &&
                Convert.ToDateTime(txtJobFrom.Text) > Convert.ToDateTime(txtJobTo.Text))
            {
                lblError.Text = "From date can not be greater than To date";
                return result;
            }
            result = true;
            return result;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }

        public void GetUserExperienceByUserId(int userid)
        {
            appmanager = new AppManager();
            List<UserWorkExperience> lstUserWorkExperience = appmanager.GetUserExperienceByUserId(userid, ref returnMessage);
            rptrWorkExperience.DataSource = lstUserWorkExperience;
            rptrWorkExperience.DataBind();
        }
        public bool DeleteUserWorkExperience(int userWorkExperience)
        {
            appmanager = new AppManager();
            return appmanager.DeleteUserExperienceByUserExperienceId(userWorkExperience, ref returnMessage);
        }

        public UserWorkExperience GetUserExperienceByUserWorkExperienceId(int userWorkExperience)
        {
            appmanager = new AppManager();
            return appmanager.GetUserExperienceByUserWorkExperienceId(userWorkExperience, ref returnMessage);
        }


        protected void rptrWorkExperience_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "UserWorkExperienceDelete")
            {
                if (DeleteUserWorkExperience(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FormsLoad(SessionHelper.getUserSession().userid);
                }
            }
            else if (e.CommandName == "UserWorkExperienceEdit")
            {
                userworkExperience = GetUserExperienceByUserWorkExperienceId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (userworkExperience != null)
                {
                    ObjectToForm(userworkExperience);
                    btnCancel.Visible = true;
                    btnBack.Visible = false;
                }

            }
        }

        public UserWorkExperience ObjectToForm(UserWorkExperience userworkExperience)
        {

            lblUserWorkExperienceId.Text = userworkExperience.UserWorkExperienceid.ToString();
            txtCompany.Text = userworkExperience.Company;
            txtJobFunction.Text = userworkExperience.JobFunction;
            txtPosition.Text = userworkExperience.Position;
            txtJobLocation.Text = userworkExperience.JobLocation;
            txtDescription.Text = userworkExperience.Description;
            txtInstitution.Text = userworkExperience.Institution;
            txtJobFrom.Text = HelperFunction.Dateformat(userworkExperience.JobFrom).ToString();
            chbfIscurrentjob.Checked = userworkExperience.IsCurrentJob;
            if (!userworkExperience.IsCurrentJob && userworkExperience.JobTo != null)
            {
                txtJobTo.Text = HelperFunction.Dateformat((DateTime)userworkExperience.JobTo);
            }
            else
            {
                txtJobTo.Attributes["disabled"] = "disabled";
            }
            return userworkExperience;
        }

        public void FormReset()
        {
            lblUserWorkExperienceId.Text = "";
            txtCompany.Text = "";
            txtJobFunction.Text = "";
            txtPosition.Text = "";
            txtJobLocation.Text = "";
            txtDescription.Text = "";
            txtInstitution.Text = "";
            txtJobFrom.Text = "";
            chbfIscurrentjob.Checked = false;
            txtJobTo.Text = "";
            txtJobTo.Attributes.Remove("disabled");
            btnAdd.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
        }

    }
}