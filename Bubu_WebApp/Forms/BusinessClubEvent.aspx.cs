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
    public partial class BusinessClubEvent : BubuBasePage
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public BusinessClub businessClub;
        public MiscellaneousOperation misOps;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    int businessClubId = 0;
                    businessClubId = Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
                    if (businessClubId > 0)
                    { 
                        FormLad(businessClubId, SessionHelper.getUserSession().userid); }
                }
                
            }
        }
        public void FormLad(int businessClubId, int UserId)
        {
            appmanager = new AppManager();
            businessClub = appmanager.GetBusinessClubWithMemberList(businessClubId, ref returnMessage);
            if (businessClub != null)
            {
                ObjectToForm(businessClub);
            }
            
        }
        public void ObjectToForm(BusinessClub businessClub)
        {
            misOps = new MiscellaneousOperation();
            lblBusinessClubName.Text = businessClub.BusinessClubName;
            if (MisOp.IsImageFileFormat(businessClub.format))
            {
                imgLogo.ImageUrl = misOps.GetImage(businessClub.ContentData);
            }
            else
            {
                imgLogo.ImageUrl = MisOp.GetImageURL(businessClub.format);
            }
            lblBusinessClubId.Text = businessClub.BusinessClubId.ToString();
        }

    }
}