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
    public partial class VacancyDetailControl : System.Web.UI.UserControl
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
        public Vacancy GetVacancyByVacancyId(int vacancyId)
        {
            appmanager = new AppManager();
            return appmanager.GetVacancyByVacancyId(vacancyId, ref returnMessage);
        }
        private void FormLoad(int vacancyId)
        {
             
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
    }
}