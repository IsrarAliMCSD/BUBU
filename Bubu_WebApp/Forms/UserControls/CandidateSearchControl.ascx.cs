using AppController;
using Bubu_WebApp.App_Class;
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
    public partial class CandidateSearchControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public List<User> users;
        public string returnMessage;
        public MiscellaneousOperation misop;
        public UserInbox userInbox;
        public int vacancyId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }
        private void FormLoad(int userId)
        {
            FillGender();
            GetQualification();
            GetWorkExperience();
            GetDomiciles();
            FillJobType();
            //lblVacancyID
            // FillUserList();
            if (vacancyId != null && vacancyId > 0)
            {
                lblVacancyID.Text = vacancyId.ToString();
            }
            FillAge();

        }
        public void FillAge()
        {
            misop = new MiscellaneousOperation();
            misop.FillAge(ref ddlAge);
        }

        private void FillJobType()
        {
            misop = new MiscellaneousOperation();
          //  misop.FillJobType(ref ddlJobType);
        }
        private void GetDomiciles()
        {
            misop = new MiscellaneousOperation();
            misop.GetDomiciles(ref ddlDomicile);
        }
        public void GetQualification()
        {
            misop = new MiscellaneousOperation();
            misop.fillQualification(ref ddlEducation, ref returnMessage);
        }
        private void GetWorkExperience()
        {
            misop = new MiscellaneousOperation();
            misop.GetWorkExperience(ref ddlWorkExperience);
        }
        private void FillGender()
        {
            misop = new MiscellaneousOperation();
            misop.FillGender(ref ddlGender);
        }
        public void FillUserList()
        {
            appmanager = new AppManager();

            // users = appmanager.GetUserListSearch(null,ref returnMessage); 
            users = appmanager.GetUserListSearch(
                (ddlGender.SelectedIndex > 0 ? (ddlGender.SelectedValue.ToString() == EnumGender.MALE.ToString() ?
                                            EnumGender.MALE : EnumGender.FEMALE) : EnumGender.NULL),
                                            ((ddlAge.SelectedValue != null & Convert.ToInt32(ddlAge.SelectedValue) > 0) ?
                                            Convert.ToInt32(ddlAge.SelectedValue) : -1),
                                            ref returnMessage);
            if (users != null)
            {
                //===============================
                appmanager = new AppManager();
                if (lblVacancyID.Text == "") { lblVacancyID.Text = "0"; }
                var vacancyObj = appmanager.GetVacancyByVacancyId(Convert.ToInt32(lblVacancyID.Text), ref returnMessage);


                //========================get CV match
                foreach (var item in users)
                {
                    int totalCVMatch = 0;
                    int VacancyQualificationCategoryId = vacancyObj != null ? vacancyObj.QualificationCategoryId.Value : 0;
                    int VacancyQualificationLevel = vacancyObj != null ? vacancyObj.Qualification.QualificationLevel.Value : 0;
                    //=============get all Qualification
                    int userQualificationCategoryId = 0;
                    var isUserQualifactionCateoryExist = item.UserQualifications.Where(a => a.QualificationCategoryId == VacancyQualificationCategoryId
                        && a.IsActive == true).ToList();
                    if (isUserQualifactionCateoryExist.Count > 0)
                    {
                        var IsExactQualificationMatch = item.UserQualifications.Where(a => a.QualificationCategoryId == VacancyQualificationCategoryId
                            && a.Qualification.QualificationLevel >= VacancyQualificationLevel && a.IsActive == true).FirstOrDefault();
                        if (IsExactQualificationMatch != null)
                        {
                            totalCVMatch = 50;
                        }
                        else
                        {
                            var maxQualificationLevel = isUserQualifactionCateoryExist.OrderByDescending(a => a.Qualification.QualificationLevel).FirstOrDefault();
                            if ((VacancyQualificationLevel - maxQualificationLevel.Qualification.QualificationLevel) == 1)
                            { totalCVMatch = 35; }
                            else if ((VacancyQualificationLevel - maxQualificationLevel.Qualification.QualificationLevel) == 2)
                            { totalCVMatch = 35; }
                            else { totalCVMatch = 10; }
                        }
                    }
                    else
                    {
                        totalCVMatch = 0;
                    }
                    //=============End Qualification
                    //=============Start Experience

                    double totalDaysExperience = 0;
                    foreach (var currentexperience in item.UserWorkExperiences.Where(a => a.IsActive == true))
                    {
                        DateTime startDate = currentexperience.JobFrom;
                        DateTime endDate = currentexperience.IsCurrentJob ? DateTime.Now : currentexperience.JobTo.Value;
                        totalDaysExperience = totalDaysExperience + (endDate - startDate).TotalDays;
                    }
                    if (totalDaysExperience > 1800) { totalCVMatch = totalCVMatch + 50; }
                    else if (totalDaysExperience > 1460) { totalCVMatch = totalCVMatch + 40; }
                    else if (totalDaysExperience > 1000) { totalCVMatch = totalCVMatch + 30; }
                    else if (totalDaysExperience > 730) { totalCVMatch = totalCVMatch + 20; }
                    else if (totalDaysExperience > 365) { totalCVMatch = totalCVMatch + 10; }
                    //=============End Experience
                    item.CVMatch = totalCVMatch;
                }

                //==============================

                List<userDetail> userDetail = users.Select(
                x => new userDetail
                {
                    user = x,
                    UserWorkExperienceLatest = x.UserWorkExperiences.Count > 0 && x.UserWorkExperiences.Any(b => b.IsActive == true) ?
                    x.UserWorkExperiences.OrderByDescending(b => b.IsCurrentJob).FirstOrDefault() : new UserWorkExperience(),
                    domicile = x.Domicile,
                    UserQualificationLatest = x.UserQualifications.Count > 0 && x.UserWorkExperiences.Any(b => b.IsActive == true) ?
                    x.UserQualifications.OrderByDescending(b => b.IsCompleted == false).FirstOrDefault() : null,
                    CVMatch = x.CVMatch
                }
                ).ToList();

                FillGrid(userDetail);
            }
            else
            {
                FillGrid(null);
            }

        }
        public void FillGrid(List<userDetail> lstUser)
        {
            gvCandidateSearch.DataSource = lstUser;
            gvCandidateSearch.DataBind();

        }
        public string GetImage(object img, object format)
        {
            if (img == null)
            {
                return "";
            }
            if (!MisOp.GetImageTypeList().Contains(format.ToString().ToUpper()))
            {
                return MisOp.GetImageURL(format.ToString().ToUpper());
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }


        }
        protected void lbtnMoreOption_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillUserList();
        }
        public void ShowHidegrid(GridViewCommandEventArgs e, bool result)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Panel panel = row.FindControl("pnlContact") as Panel;
            panel.Visible = result;
            if (result)
            { }
            //lblError.text="";
        }
        public void InsertVacancyMessageToUser(GridViewCommandEventArgs e, int userid)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Panel panel = row.FindControl("pnlContact") as Panel;
            TextBox txtEmployeeContact = panel.FindControl("txtEmployeeContact") as TextBox;
            Label lblError = panel.FindControl("lblError") as Label;
            if (lblVacancyID.Text != null && lblVacancyID.Text != "")
            {
                userInbox = new UserInbox();
                userInbox.InboxUserId = userid;
                userInbox.Message = txtEmployeeContact.Text;
                userInbox.SenderId = SessionHelper.getUserSession().userid;
                userInbox.VacancyId = Convert.ToInt32(lblVacancyID.Text.ToString());
                userInbox.IsActive = true;
                appmanager = new AppManager();
                appmanager.InsertUserInbox(userInbox, ref returnMessage);
            }
            lblError.Text = returnMessage;
        }
        protected void gvCandidateSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "SENDMESSAGE")
            {
                collapseAllContact();
                lblIsParticularUser.Text = e.CommandArgument.ToString();
                // Response.Redirect("VacancyContactCandidate.aspx");
                ShowHidegrid(e, true);
            }
            else if (e.CommandName.ToUpper() == "SEND")
            {
                InsertVacancyMessageToUser(e, Convert.ToInt32(e.CommandArgument.ToString()));
            }
            else if (e.CommandName.ToUpper() == "SENDCANCEL")
            {
                lblIsParticularUser.Text = "";
                ShowHidegrid(e, false);
            }
            else if (e.CommandName.ToUpper() == "EMPLOYEECANCEL")
            {
                // UpdateVacancyApplyIsCancelEmployeer(Convert.ToInt32(e.CommandArgument.ToString()));
            }
            else if (e.CommandName.ToUpper() == "CVDOWNLOAD")
            {
                MiscellaneousOperation.CVDownload(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }

        public void collapseAllContact()
        {
            for (int i = 0; i < gvCandidateSearch.Rows.Count; i++)
            {
                Panel panel = (Panel)gvCandidateSearch.Rows[i].FindControl("pnlContact");
                if (panel != null)
                {
                    panel.Visible = false;
                }

            }
        }

    }
}