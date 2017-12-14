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
    public partial class CurriculumVitae : BubuBasePage
    {
        public string returnMessage = "";
        public AppManager appmanager;
        public MiscellaneousOperation misop;
        public UserQualification userQualification;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                CurriculamVitaeControl.editVisible = true;
            }
        }

      

    }
}