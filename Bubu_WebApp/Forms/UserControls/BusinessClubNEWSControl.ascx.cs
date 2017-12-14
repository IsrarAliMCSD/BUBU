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
    public partial class BusinessClubNEWSControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public MiscellaneousOperation misOp;
        public BusienssClubNewsInfo busienssClubNewsInfo;
        public string returnMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormLoad();
            }
        }

        public void FormLoad()
        {
            FillBusinessClub();
            txtNewsDetail.Attributes.Add("maxlength", txtNewsDetail.MaxLength.ToString());

        }
        public void FillBusinessClub()
        {
            misOp = new MiscellaneousOperation();
            misOp.FillBusinessClubByUserId(ref ddlClubName, SessionHelper.getUserSession().userid);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            busienssClubNewsInfo=new BusienssClubNewsInfo();
            if (FormToObject(ref busienssClubNewsInfo))
            {
               if(appmanager.InsertBusiensNews(busienssClubNewsInfo,ref returnMessage))
               {
                   lblError.Text = "News has been saved successfully";
            }}
        }
        public bool FormToObject(ref BusienssClubNewsInfo busienssClubNewsInfo)
        {
            busienssClubNewsInfo.NewsTitle = "";
            busienssClubNewsInfo.NewsDetail = txtNewsDetail.Text;
            busienssClubNewsInfo.BusinessClubId = Convert.ToInt32(ddlClubName.SelectedValue);
            busienssClubNewsInfo.UserId = SessionHelper.getUserSession().userid;
            busienssClubNewsInfo.IsActive = true;
            return true;
        }

    }
}