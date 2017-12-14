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
    public partial class BusinessClubMessageControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);

            }
        }
        public void FormLoad(int UserId)
        {
            appmanager = new AppManager();
            GridBind(appmanager.GetBusinessEventDetail(-1, UserId));
            //================
            BindJobNews(UserId);
            FillUserMessage(UserId);
        }


        public void FillUserMessage(int UserId)
        {
            appmanager = new AppManager();
            List<UserMessageDetail> lstInboxUser = appmanager.GetUserMessage(UserId);
            gvUserMaeesge.DataSource = lstInboxUser;
            gvUserMaeesge.DataBind();
        }

        public void BindJobNews(int UserId)
        {
            appmanager = new AppManager();
            List<UserInbox> lstInboxUser = appmanager.GetJobNews(UserId);
            gvNEws.DataSource = lstInboxUser;
            gvNEws.DataBind();
 
        }
        public void GridBind(List<BusinessClubActivityDetail> businessClubActivities)
        {
            if (businessClubActivities.Count > 0)
            {
                //foreach (var item in businessClubActivities)
                //{
                //    item.BusinessClubActivityComments = item.BusinessClubActivityComments.Count == 0 ?
                //        new List<BusinessClubActivityComment>() { new BusinessClubActivityComment() { User = MisOp.AddEmptyUser() } } : item.BusinessClubActivityComments;
                //}
            }

            gvAllBusinessClubMessage.DataSource = businessClubActivities;
            gvAllBusinessClubMessage.DataBind();
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

    }
}