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
    public partial class UserHobbyControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public List<UserHobby> userHobbies;
        public UserHobby userHobby;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillHobby();
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }

        private void FormLoad(int userId)
        {
            FillUserHobbies(userId);
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }
        public void FillUserHobbies(int userId)
        {
            appmanager = new AppManager();
            userHobbies = appmanager.GetUserHobbiesByUserId(userId, ref returnMessage);
            rptruserHobbies.DataSource = userHobbies;
            rptruserHobbies.DataBind();
        }

        private void FillHobby()
        {
            misop = new MiscellaneousOperation();
            misop.FillHobbies(ref ddlHobby);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            if (appmanager.SaveUserHobby(FormToObjet(), ref returnMessage))
            {
                FormReset();
                FormLoad(SessionHelper.getUserSession().userid);
            }
            else
            {
                lblError.Text = returnMessage;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }
        private UserHobby FormToObjet()
        {
            userHobby = new UserHobby();
            if (lblUserHobbyId.Text != "")
            {
                userHobby.UserHobbyId = Convert.ToInt32(lblUserHobbyId.Text);
            }
            userHobby.UserId = SessionHelper.getUserSession().userid;
            userHobby.HobbyId = Convert.ToInt32(ddlHobby.SelectedValue);
            userHobby.HobbyDetail = txtHobbyDetail.Text;
            userHobby.IsActive = true;
            return userHobby;
        }
        public void FormReset()
        {
            lblUserHobbyId.Text = "";
            ddlHobby.SelectedIndex = 0;
            txtHobbyDetail.Text = "";
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }
        public bool DeleteUserHobbyByUserHobbyId(int userHobbyId)
        {
            appmanager = new AppManager();
            return appmanager.DeleteUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }
        protected void rptruserHobbies_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "USERHOBBYDELETE")
            {
                if (DeleteUserHobbyByUserHobbyId(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                }
            }
            else if (e.CommandName == "USERHOBBYEDIT")
            {
                userHobby = GetUserHobbyByUserHobbyId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (userHobby != null)
                {
                    ObjectToForm(userHobby);
                    btnCancel.Visible = true;
                    btnBack.Visible = false;
                }

            }
        }

        public UserHobby GetUserHobbyByUserHobbyId(int userHobbyId)
        {
            appmanager = new AppManager();
            return appmanager.GetUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }

        public UserHobby ObjectToForm(UserHobby userHobby)
        {
            lblUserHobbyId.Text = userHobby.UserHobbyId.ToString();
            ddlHobby.SelectedValue = userHobby.HobbyId.ToString();
            txtHobbyDetail.Text = userHobby.HobbyDetail;
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
            return userHobby;
        }


    }
}