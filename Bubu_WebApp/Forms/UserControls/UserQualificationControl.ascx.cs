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
    public partial class UserQualificationControl : System.Web.UI.UserControl
    {
        public string returnMessage = "";
        public AppManager appmanager;
        public MiscellaneousOperation misop;
        public UserQualification userQualification;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserQualification(SessionHelper.getUserSession().userid);
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

        public void GetAllQualificationCategoriesList()
        {
            misop = new MiscellaneousOperation();
            misop.GetAllQualificationCategoriesList(ref ddlfQualificationCategory, ref returnMessage);

        }

        public void GetQualification()
        {
            misop = new MiscellaneousOperation();
            misop.fillQualification( ref ddlfQualification, ref returnMessage);
        }

        public void GetUserQualification(int userid)
        {
            appmanager = new AppManager();
            List<UserQualification> lstUserQualification = appmanager.GetQualificationByUserId(userid, ref returnMessage);
            rptrUserQualification.DataSource = lstUserQualification;
            rptrUserQualification.DataBind();

        }

        public UserQualification FormToObjectQualification(int? userQualificationId)
        {
            userQualification = new UserQualification();
            userQualification.QualificationId = Convert.ToInt32(ddlfQualification.SelectedValue);
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
            if (userQualification != null && userQualificationId > 0)
            {
                userQualification.UserQualificationId = (int)userQualificationId;
            
            }
            userQualification.UserId = SessionHelper.getUserSession().userid;
            userQualification.IsActive = true;
            userQualification.QualificationCategoryId = Convert.ToInt32(ddlfQualificationCategory.SelectedValue);

            return userQualification;
        }
        protected void rptrUserQualification_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == GridCommand.QUALIFICATIONDELETE.ToString())
            {
                if (DeleteUserQualification(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    GetUserQualification(SessionHelper.getUserSession().userid);
                    FormReset();
                }
            }
            else if (e.CommandName.ToUpper() == GridCommand.QUALIFICATIONEDIT.ToString())
            {
                userQualification = GetUserQualificationById(Convert.ToInt32(e.CommandArgument.ToString()));
                if (userQualification != null)
                {
                    ObjectToFormUserQualification(userQualification);
                }

            }


        }

        public void ObjectToFormUserQualification(UserQualification userQualification)
        {
            ddlfQualification.SelectedValue = userQualification.QualificationId.ToString();
            ddlfCountry.SelectedValue = userQualification.CountryId.ToString();
            chbfIsCompleted.Checked = (bool)userQualification.IsCompleted;
            txtfYearCompleted.Value = userQualification.CompletedYear.ToString();
            txtfInstitute.Text = userQualification.Institution;
            txtfDescription.Text = userQualification.Description;
            txtfPercentage.Text = userQualification.Percentage.ToString();
            txtfCGPA.Text = userQualification.CGPA.ToString();
            if (userQualification != null && userQualification.UserQualificationId > 0)
            {
                lblUserQualificationId.Text = userQualification.UserQualificationId.ToString();
            }
            if (!chbfIsCompleted.Checked)
            {
                txtfYearCompleted.Attributes["disabled"] = "disabled";
            }
            else
            {
                txtfYearCompleted.Attributes.Remove("disabled");
            }
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            ddlfQualificationCategory.SelectedValue = userQualification.QualificationCategoryId.ToString();
        }
        public bool DeleteUserQualification(int userQualificationId)
        {
            appmanager = new AppManager();
            return appmanager.DeleteUserQualification(userQualificationId, ref returnMessage);
        }



        public UserQualification GetUserQualificationById(int userQualificationId)
        {
            appmanager = new AppManager();
            return appmanager.GetUserQualificationById(userQualificationId, ref returnMessage);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            userQualification = FormToObjectQualification(null);
            appmanager.SaveUserQualification(userQualification, ref returnMessage);
            GetUserQualification(SessionHelper.getUserSession().userid);
            FormReset();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            userQualification = FormToObjectQualification(Convert.ToInt32(lblUserQualificationId.Text));
            appmanager.SaveUserQualification(userQualification, ref returnMessage);
            GetUserQualification(SessionHelper.getUserSession().userid);
            FormReset();
            Response.Redirect(this.Page.Request.Url.ToString());
        }
        public void FormReset()
        {
            ddlfQualification.SelectedIndex = 0;
            ddlfQualificationCategory.SelectedIndex = 0;
            ddlfCountry.SelectedIndex = 0;
            chbfIsCompleted.Checked = false;
            txtfYearCompleted.Value = "";
            txtfInstitute.Text = "";
            txtfDescription.Text = "";
            txtfPercentage.Text = null;
            txtfCGPA.Text = null;

            lblUserQualificationId.Text = "";

            txtfYearCompleted.Attributes["disabled"] = "disabled";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            
        }

       
    }
}