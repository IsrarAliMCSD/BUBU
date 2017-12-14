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
    public partial class EmployeerJobSearch : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public List<Vacancy> vacanciesSearch;
        public int? companyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //  lblError.Text = "";
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
        }

        private void GetDomiciles()
        {
            misop = new MiscellaneousOperation();
            misop.GetDomiciles(ref ddlDomicile);
        }
        private void GetWorkExperience()
        {
            misop = new MiscellaneousOperation();
            misop.GetWorkExperience(ref ddlWorkExperience);
        }

        public void GetQualification()
        {
            misop = new MiscellaneousOperation();
            misop.fillQualification(ref ddlEducation, ref returnMessage);
        }
        private void FillGender()
        {
            misop = new MiscellaneousOperation();
            misop.FillGender(ref ddlGender);
        }
        private void FillJobType()
        {
            misop = new MiscellaneousOperation();
            misop.FillJobType(ref ddlJobType);
        }

        protected void lbtnMoreOption_Click(object sender, EventArgs e)
        {

        }
        public void SearchResult()
        {
            bool isEditAllow = false;
            appmanager = new AppManager();
            if (SessionHelper.getUserSession().AccountTye.ToUpper() == UserAccountType.EMPLOYEE.ToString())
            {
                if (Request.QueryString.Count == 1)
                {
                    int companyId = 0;
                    companyId = int.Parse(HelperFunction.Func_Decrypt(Request.QueryString[0].ToString()));
                    if (companyId > 0)
                    {
                        //vacanciesSearch = appmanager.JobSearch(companyId,DAOClassLib.JobPrivacy.Public,                            "", "", "", ref returnMessage);
                    }
                    isEditAllow = false;
                }
            }
            else if (SessionHelper.getUserSession().AccountTye.ToUpper() == UserAccountType.EMPLOYER.ToString())
            {
                if (Request.QueryString.Count == 1)
                {
                    int companyId = 0;
                    companyId = int.Parse(HelperFunction.Func_Decrypt(Request.QueryString[0].ToString()));
                    if (companyId > 0)
                    {
                        // vacanciesSearch = appmanager.JobSearch(companyId, DAOClassLib.JobPrivacy.Public, ref returnMessage);
                        //FormLoadByCompanyId(companyId);
                    }
                    isEditAllow = false;
                }
                else
                {
                    isEditAllow = true;
                    // vacanciesSearch = appmanager.JobSearch(companyId, DAOClassLib.JobPrivacy.Public, ref returnMessage);
                }
            }
            gvVacancyList.DataSource = vacanciesSearch;
            gvVacancyList.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
    }
}