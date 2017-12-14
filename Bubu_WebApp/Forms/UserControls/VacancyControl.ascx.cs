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
    public partial class VacancyControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public CompanyInformation companyInformtion;
        public List<Vacancy> vacancies;
        public Vacancy vacancy;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillJobType();
                GetRegionList();
                GetQualification();
                GetAllQualificationCategoriesList();
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }
        public void GetAllQualificationCategoriesList()
        {
            misop = new MiscellaneousOperation();
            misop.GetAllQualificationCategoriesList(ref ddlfQualificationCategory, ref returnMessage);

        }
        public void GetQualification()
        {
            misop = new MiscellaneousOperation();
            misop.fillQualification(ref ddlfQualification, ref returnMessage);
        }
        private void FormLoad(int userId)
        {
            FillVacancy(userId);
            btnSave.Visible = false;
            btnBack.Visible = true;
            btnCancel.Visible = false;
            GetCompanyInformationByUserId(userId);
        }
        private void GetRegionList()
        {
            misop = new MiscellaneousOperation();
            misop.GetRegionList(ref ddlRegion);
        }
        public void FillVacancy(int userId)
        {
            appmanager = new AppManager();
            vacancies = appmanager.GetVacancyListByUserId(userId, true, ref returnMessage);
            gvVacancyList.DataSource = vacancies;
            gvVacancyList.DataBind();
        }
        public void GetCompanyInformationByUserId(int userId)
        {
            appmanager = new AppManager();
            companyInformtion = appmanager.GetCompanyInformationByUserId(userId);
            if (companyInformtion != null && companyInformtion.CompanyId > 0 && companyInformtion.CompanySector != "")
            {
                txtSector.Text = companyInformtion.CompanySector;
                btnSave.Visible = true;
                btnBack.Visible = true;
                btnCancel.Visible = false;
                lblCompanyId.Text = companyInformtion.CompanyId.ToString();
            }
            else
            {
                txtSector.Text = "";
                lblCompanyId.Text = "";
                lblError.Text = "Please enter company along with sector from company edit screen then you will be able to add vacancy";
            }
        }

        private void FillJobType()
        {
            misop = new MiscellaneousOperation();
            misop.FillJobType(ref ddlJobType);
        }
        public void FormReset()
        {
            //lblCompanyId.Text = "";
            lblVacancyId.Text = "";
            rbtnNo.Checked = true;
            txtJobTitle.Text = "";
            //txtSector.Text = "";
            txtFunction.Text = "";
            txtDescription.Text = "";
            ddlJobType.SelectedIndex = 0;
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
            ddlRegion.SelectedIndex = 0;
            ddlfQualification.SelectedIndex = 0;
            ddlfQualificationCategory.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            vacancy = new Vacancy();
            appmanager = new AppManager();
            if (formToObject(ref vacancy))
            {
                if (appmanager.SaveVacancy(vacancy, ref returnMessage))
                {
                    lblError.Text = "Record has been saved successfully";
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                    MisOp.ShowMessage(this, lblError.Text, "Vacancy ", false);
                }
                else
                {
                    lblError.Text = returnMessage;
                }
            }
        }
        public bool formToObject(ref Vacancy vacancy)
        {
            if (lblVacancyId.Text == null || lblVacancyId.Text != "")
            {
                vacancy.VacancyId = Convert.ToInt32(lblVacancyId.Text);
            }
            vacancy.CompanyId = Convert.ToInt32(lblCompanyId.Text);
            vacancy.IsPrivate = rbtnNo.Checked ? true:false;// rbtnNo.Checked : rbtnYes.Checked;
            vacancy.JobTitle = txtJobTitle.Text;
            vacancy.JobFunction = txtFunction.Text;
            vacancy.JobDetail = txtDescription.Text;
            vacancy.JobTypeId = Convert.ToInt32(ddlJobType.SelectedValue);
            vacancy.IsVacancyCompleted = false;
            vacancy.IsActive = true;
            vacancy.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
            vacancy.QualificationId = Convert.ToInt32(ddlfQualification.SelectedValue.ToString());
            vacancy.QualificationCategoryId = Convert.ToInt32(ddlfQualificationCategory.SelectedValue.ToString());
            return true;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeEmployeer.aspx");
        }

        protected void gvVacancyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "VACANCYDELETE")
            {
                if (DeleteVacancyByVacancyId(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                }
            }
            else if (e.CommandName == "VACANCYEDIT")
            {
                vacancy = GetVacancyByVacancyId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (vacancy != null)
                {
                    ObjectToForm(vacancy);
                    btnCancel.Visible = true;
                    btnBack.Visible = false;
                }

            }
            else if (e.CommandName == "VACANTAPPLICANT")
            {
                Response.Redirect("~/Forms/employeer/VacancyApplicant.aspx?VacancyId=" + HelperFunction.EncryptData(e.CommandArgument.ToString()));
            }
            else if (e.CommandName == "VACANCYSEARCHFORCANDIDATE")
            {
                Response.Redirect("~/Forms/employeer/VacancySearchCandidate.aspx?VacancyId=" + HelperFunction.EncryptData(e.CommandArgument.ToString()));
            }
        }

        private void ObjectToForm(Vacancy vacancy)
        {
            if (vacancy.IsPrivate)
            {
                rbtnYes.Checked = true;
            }
            else
            {
                rbtnNo.Checked = true;
            }
            txtJobTitle.Text = vacancy.JobTitle;
            txtFunction.Text = vacancy.JobFunction;
            txtDescription.Text = vacancy.JobDetail;
            ddlJobType.SelectedValue = vacancy.JobTypeId.ToString();
            lblVacancyId.Text = vacancy.VacancyId.ToString();
            if (vacancy.RegionId != null)
            {
                ddlRegion.SelectedValue = vacancy.RegionId.ToString();
            }
            ddlfQualification.SelectedValue = vacancy.QualificationId.ToString();
            ddlfQualificationCategory.SelectedValue = vacancy.QualificationCategoryId.ToString();
        }
        public bool DeleteVacancyByVacancyId(int vacancyId)
        {
            appmanager = new AppManager();
            return appmanager.DeleteVacancyByVacancyId(vacancyId, ref returnMessage);
        }
        public Vacancy GetVacancyByVacancyId(int vacancyId)
        {
            appmanager = new AppManager();
            return appmanager.GetVacancyByVacancyId(vacancyId, ref returnMessage);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            vacancies = appmanager.GetVacancyListSearch(SessionHelper.getUserSession().userid, true, txtSearch.Text, ref returnMessage);
            gvVacancyList.DataSource = vacancies;
            gvVacancyList.DataBind();
        }

    }
}