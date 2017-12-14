using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.Employeer
{
    public partial class VacancyApplicant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    int querydata = 0;
                    querydata = int.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
                    FormLoad(querydata);
                }
            }
            
        }
        public void FormLoad(int vacancyId)
        {
            VacancyApplicantList1.vacancyId = vacancyId;
        }
    }
}