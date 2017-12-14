using AppController;
using Bubu_WebApp.App_Class;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class VacancyApplicantList : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public List<VacancyApply> vacanciesApply;
        UserInbox userInbox;
        public int vacancyId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (vacancyId != null && vacancyId > 0)
                {
                    FormLoad(vacancyId);
                }
            }
        }
        public void FillVacancyApplicant(int vacancyId)
        {
            lblVacancyID.Text = vacancyId.ToString();
            appmanager = new AppManager();
            vacanciesApply = appmanager.GetApplicantListByVacancyId(vacancyId, ref returnMessage);
            //========================get CV match
            foreach (var item in vacanciesApply)
            {
                int totalCVMatch = 0;
                int VacancyQualificationCategoryId = item.Vacancy.QualificationCategoryId.Value;
                int VacancyQualificationLevel = item.Vacancy.Qualification.QualificationLevel.Value;
                //=============get all Qualification
                int userQualificationCategoryId = 0;
                var isUserQualifactionCateoryExist = item.User.UserQualifications.Where(a => a.QualificationCategoryId == VacancyQualificationCategoryId
                    && a.IsActive == true).ToList();
                if (isUserQualifactionCateoryExist.Count > 0)
                {
                    var IsExactQualificationMatch = item.User.UserQualifications.Where(a => a.QualificationCategoryId == VacancyQualificationCategoryId
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
                foreach (var currentexperience in item.User.UserWorkExperiences.Where(a=>a.IsActive==true))
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
            List<vacancyDetail> vacanciesApply_vacancyDetail = vacanciesApply.Select(
               x => new vacancyDetail
               {
                   vacancyApply = x,
                   user = x.User,
                   UserWorkExperienceLatest = x.User.UserWorkExperiences.Count > 0 && x.User.UserWorkExperiences.Any(b => b.IsActive == true) ?
                   x.User.UserWorkExperiences.OrderByDescending(b => b.IsCurrentJob).FirstOrDefault() : new UserWorkExperience(),
                   domicile = x.User.Domicile,
                   UserQualificationLatest = x.User.UserQualifications.Count > 0 && x.User.UserWorkExperiences.Any(b => b.IsActive == true) ?
                   x.User.UserQualifications.OrderByDescending(b => b.IsCompleted == false).FirstOrDefault() : null,
                   CVMatch = x.CVMatch
               }
               ).ToList();



            gvApplicant.DataSource = vacanciesApply_vacancyDetail;
            gvApplicant.DataBind();
        }

        public Vacancy GetVacancyByVacancyId(int vacancyId)
        {
            appmanager = new AppManager();
            return appmanager.GetVacancyByVacancyId(vacancyId, ref returnMessage);
        }
        private void FormLoad(int vacancyId)
        {
            FillVacancyApplicant(vacancyId);
            ObjectToForm(GetVacancyByVacancyId(vacancyId));
        }

        private void ObjectToForm(Vacancy vacancy)
        {
            misop = new MiscellaneousOperation();
            if (vacancy == null)
            {
                return;
            }
            lblIsPrivate.Text = vacancy.IsPrivate ? "Private" : "Not Private";
            img_document.ImageUrl = misop.GetImage(vacancy.CompanyInformation.CompanyContentData);
            lblCOMPANYNAME.Text = vacancy.CompanyInformation.CompanyName;
            lblCompanySector.Text = vacancy.CompanyInformation.CompanySector;
            lblJobFunction.Text = vacancy.JobFunction;
            if (vacancy.Region != null)
            {
                lblRegion.Text = vacancy.Region.RegionName;
            }
            if (vacancy.JobType != null)
            {
                lblJobType.Text = vacancy.JobType.JobTypeName;
            }
            lblJobTitle.Text = vacancy.JobTitle;
            lblJobDetail.Text = vacancy.JobDetail;
        }

        public string GetImage(object img, string format)
        {
            if (!MisOp.GetImageTypeList().Contains(format.ToUpper()))
            {
                return MisOp.GetImageURL(format.ToUpper());
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/employeer/EmployeerVacancyMgmt.aspx");
        }

        protected void gvApplicant_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "SENDMESSAGE")
            {
                ShowHidegrid(e, true);
            }
            else if (e.CommandName.ToUpper() == "SEND")
            {
                InsertVacancyMessageToUser(e, Convert.ToInt32(e.CommandArgument.ToString()));
            }
            else if (e.CommandName.ToUpper() == "SENDCANCEL")
            {
                ShowHidegrid(e, false);
            }
            else if (e.CommandName.ToUpper() == "EMPLOYEECANCEL")
            {
                UpdateVacancyApplyIsCancelEmployeer(Convert.ToInt32(e.CommandArgument.ToString()));
            }
            else if (e.CommandName.ToUpper() == "CVDOWNLOAD")
            {
                MiscellaneousOperation.CVDownload(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }
        public void UpdateVacancyApplyIsCancelEmployeer(int vacancyApplyId)
        {
            appmanager = new AppManager();
            appmanager.UpdateVacancyApplyIsCancelEmployeer(vacancyApplyId, SessionHelper.getUserSession().userid, true);
            FormLoad(vacancyId);
        }
        public void InsertVacancyMessageToUser(GridViewCommandEventArgs e, int userid)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Panel panel = row.FindControl("pnlContact") as Panel;
            TextBox txtEmployeeContact = panel.FindControl("txtEmployeeContact") as TextBox;
            Label lblError = panel.FindControl("lblError") as Label;
            userInbox = new UserInbox();
            userInbox.InboxUserId = userid;
            userInbox.Message = txtEmployeeContact.Text;
            userInbox.SenderId = SessionHelper.getUserSession().userid;
            userInbox.VacancyId = Convert.ToInt32(lblVacancyID.Text.ToString());
            userInbox.IsActive = true;
            appmanager = new AppManager();
            appmanager.InsertUserInbox(userInbox, ref returnMessage);
            lblError.Text = returnMessage;
        }
        public void ShowHidegrid(GridViewCommandEventArgs e, bool result)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Panel panel = row.FindControl("pnlContact") as Panel;
            panel.Visible = result;
            //lblError.text="";
        }

    }
}