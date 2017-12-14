using AppController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOClassLib.EF;

namespace Bubu_WebApp.Forms
{
    public partial class CreateMessage : BubuBasePage
    {
        public AppManager appmanager;
        public string returnMessage = "";
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            lblError.Text = "";
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }

        }

        public void FormLoad(int userid)
        {
              appmanager = new AppManager();
            
            var lstUser= appmanager.GetListOfUser();
            ddlUserList.DataSource = lstUser;
            ddlUserList.DataTextField = "userName";
            ddlUserList.DataValueField = "userId";
            ddlUserList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserMessageDetail obj = new UserMessageDetail();
            obj.SenderId = SessionHelper.getUserSession().userid;
            obj.ReceiverId = Convert.ToInt32(ddlUserList.SelectedValue);
            obj.MessageText = txtMessage.Text;
            obj.IsActiveFromReceiver = true;
            obj.IsActiveFromSender = true;
            appmanager = new AppManager();
            if (appmanager.SaveUserMessage(obj, ref returnMessage))
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
            else
            {
                lblError.Text = returnMessage;
            }
            MisOp.ShowMessage(this, returnMessage, "Message Sent", true);

            ddlUserList.SelectedIndex = 0;
            txtMessage.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeMessageMgmt.aspx");
        }
    }
}