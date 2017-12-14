using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class JobDetail : BubuBasePage
    {
        public AppManager appmanager;
        public string returnMessage = "";
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0 && Request.QueryString["jobId"] != null && Convert.ToInt32(Request.QueryString["jobId"]) > 0)
                {
                    FormLoad(Convert.ToInt32(Request.QueryString["jobId"]));
                }

            }
        }

        public void FormLoad(int jobId)
        {
            GetVacancyByVacancyId(jobId);

        }
        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        public void GetVacancyByVacancyId(int vacancyId)
        {
            appmanager = new AppManager();
            Vacancy vacancyObj = appmanager.GetVacancyDetailByVacancyId(vacancyId);
            if (vacancyObj != null && vacancyObj.VacancyId > 0)
            {
                lblCompanyName.Text = vacancyObj.CompanyInformation != null ? vacancyObj.CompanyInformation.CompanyName : "";
                lblCompanySector.Text = vacancyObj.CompanyInformation != null ? vacancyObj.CompanyInformation.CompanySector : "";
                lblJobFunction.Text = vacancyObj.JobFunction;
                lblRegion.Text = vacancyObj.Region != null ? vacancyObj.Region.RegionName : "";
                lblJobType.Text = vacancyObj.JobType!=null ? vacancyObj.JobType.JobTypeName : "";
                lblJobTitle.Text = vacancyObj.JobTitle;
                lblJobDetail.Text = vacancyObj.JobDetail;
                lblQualificationCategoty.Text = vacancyObj.QualificationCategory != null ? vacancyObj.QualificationCategory.QualificationCategoryName : "";
                lblQualificationName.Text = vacancyObj.Qualification!=null?  vacancyObj.Qualification.QualificationName:"";
                imgCompanyLogo.ImageUrl = vacancyObj.CompanyInformation != null ? GetImage(vacancyObj.CompanyInformation.CompanyContentData) : "";

            }



        }

    }
}