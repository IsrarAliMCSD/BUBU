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
    public partial class BusinessClubActivityListUpdate : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    int businessClubId = 0;
                    businessClubId = Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
                    if (businessClubId > 0)
                    {
                        FormLad(businessClubId, SessionHelper.getUserSession().userid);
                    }
                }
            }
        }
        public void FormLad(int businessClubId, int UserId)
        {
            appmanager = new AppManager();
            GridBind(appmanager.GetBusinessEventWithMessages(businessClubId, UserId));
        }
        public void GridBind(List<BusinessClubActivity> businessClubActivities)
        {
            if (businessClubActivities.Count > 0)
            {
                //foreach (var item in businessClubActivities)
                //{
                //    item.BusinessClubActivityComments = item.BusinessClubActivityComments.Count == 0 ?
                //        new List<BusinessClubActivityComment>() { new BusinessClubActivityComment() { User = MisOp.AddEmptyUser() } } : item.BusinessClubActivityComments;
                //}
            }

            gvBCActivityList.DataSource = businessClubActivities;
            gvBCActivityList.DataBind();
        }
        public static string GetImage(object img, object format)
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

        protected void btnAddBusinessClubActivity_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Forms/AddBusinessClubEvent.aspx?id=" + Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString())));

        }



    }
}