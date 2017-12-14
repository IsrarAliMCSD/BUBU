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
    public partial class BusinessClubActivityListControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);

            }
        }
        private void FormLoad(int userId)
        {
            appmanager = new AppManager();
            GridBind(appmanager.GetBusinessEventWithMessages(0, userId));
        }
        public void GridBind(List<BusinessClubActivity> businessClubActivities)
        {
            if (businessClubActivities.Count > 0)
            {
                foreach (var item in businessClubActivities)
                {
                    item.BusinessClubActivityComments = item.BusinessClubActivityComments.Count == 0 ?
                        new List<BusinessClubActivityComment>() { new BusinessClubActivityComment() { User = MisOp.AddEmptyUser() } } : item.BusinessClubActivityComments;
                }
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


        public BusinessClubActivityComment businessClubActivityCommentFormToObject(int businessClubId, string comments)
        {
            BusinessClubActivityComment businessClubActivityComment = new BusinessClubActivityComment();
            businessClubActivityComment.BusinessClubActivityId = businessClubId;
            businessClubActivityComment.Message = comments;
            businessClubActivityComment.IsActive = true;
            return businessClubActivityComment;
        }

        protected void gvBCActivityList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "SAVECOMMENT")
            {
                GridViewRow row = (GridViewRow)(e.CommandSource);
                int businessClubId = 0;
                string txtComments = ((TextBox)row.FindControl("txtComments")).Text;
                Label lblBusinessClubActivityId = row.Parent.Parent.Parent.Parent.FindControl("lblBusinessClubActivityId") as Label;
                if (lblBusinessClubActivityId != null)
                {
                    businessClubId = Convert.ToInt32(lblBusinessClubActivityId.Text);
                    appmanager = new AppManager();
                    appmanager.SaveBusinessClubActivityComments(businessClubActivityCommentFormToObject(businessClubId, txtComments));
                    FormLoad(SessionHelper.getUserSession().userid);
                }

            }
        }


    }
}