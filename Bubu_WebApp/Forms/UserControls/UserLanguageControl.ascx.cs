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
    public partial class UserLanguageControl : System.Web.UI.UserControl
    {
        public MiscellaneousOperation misop;
        public AppManager appmanager;
        public string returnMessage = "";
        public UserLanguage userLanguage;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }

        }
        public void FormReset()
        {
            lblError.Text = "";
            lblUserLanguageId.Text = "";
            btnAdd.Visible = true;
            btnCancel.Visible = false;
            btnBack.Visible = true;
            ddlLanguage.SelectedIndex = 0;
            ddlLevel.SelectedIndex = 0;

        }

        public void FormLoad(int userid)
        {
            misop = new MiscellaneousOperation();
            misop.fillLanguage(ref ddlLanguage);
            misop.FillLevel(ref ddlLevel);
            GetUserLanguageByUserId(userid);
        }

        public void GetUserLanguageByUserId(int userId)
        {
            appmanager = new AppManager();
            List<UserLanguage> lstUserLanguage = appmanager.GetUserLanguageByUserId(userId, ref returnMessage);
            gvUserLanguage.DataSource = lstUserLanguage;
            gvUserLanguage.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            if (appmanager.SaveUserLanguage(FormToObject(), ref returnMessage))
            {
                FormReset();
                GetUserLanguageByUserId(SessionHelper.getUserSession().userid);
            }
            else
            {
                lblError.Text = returnMessage;
            }

        }
        public UserLanguage FormToObject()
        {
            userLanguage = new UserLanguage();
            if (lblUserLanguageId.Text != "")
            {
                userLanguage.UserLanguageId = Convert.ToInt32(lblUserLanguageId.Text);
            }
            userLanguage.LanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
            userLanguage.LevelId = Convert.ToInt32(ddlLevel.SelectedValue);
            userLanguage.UserId = SessionHelper.getUserSession().userid;
            userLanguage.IsActive = true;
            return userLanguage;

        }
        public void ObjectToForm(UserLanguage userlanguage)
        {
            lblUserLanguageId.Text = userlanguage.UserLanguageId.ToString();
            ddlLanguage.SelectedValue = userlanguage.LanguageId.ToString();
            ddlLevel.SelectedValue = userlanguage.LevelId.ToString();
            btnCancel.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }
        public UserLanguage GetUserLanguageById(int userLanguageId)
        {
            appmanager = new AppManager();
            return appmanager.GetUserLanguageByUserLanguageId(userLanguageId, ref  returnMessage);
        }

        protected void gvUserLanguage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == GridCommand.GRIDEDIT.ToString())
            {
                lblUserLanguageId.Text = e.CommandArgument.ToString();
                userLanguage = GetUserLanguageById(Convert.ToInt32(e.CommandArgument.ToString()));
                ObjectToForm(userLanguage);

            }
            else if (e.CommandName == GridCommand.GRIDDELETE.ToString())
            {
                DeleteUserLanguageByUserLanguageId(Convert.ToInt32(e.CommandArgument.ToString()));
                GetUserLanguageByUserId(SessionHelper.getUserSession().userid);
            }
        }
        public bool DeleteUserLanguageByUserLanguageId(int userLanguageid)
        {
            appmanager = new AppManager();
            return appmanager.DeleteUserLanguageByUserLanguageId(userLanguageid, ref returnMessage);

        }
    }
}