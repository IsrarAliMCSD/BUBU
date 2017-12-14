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
    public partial class AdditionalSkillControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public List<UserSkill> userSkills;
        public UserSkill userSkill;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillSkill();
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }

        private void FillSkill()
        {
            misop = new MiscellaneousOperation();
            misop.FillSkills(ref ddlSkill);
        }
        private void FormLoad(int userId)
        {
            FillUserSkills(userId);
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }

        private void FillUserSkills(int userId)
        {
            appmanager = new AppManager();
            userSkills = appmanager.GetUserSkillsByUserId(userId, ref returnMessage);
            rptruserSkill.DataSource = userSkills;
            rptruserSkill.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            appmanager = new AppManager();
            if (appmanager.SaveUserSkill(FormToObjet(), ref returnMessage))
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

        private UserSkill FormToObjet()
        {
            userSkill = new UserSkill();
            if (lblUserSkillId.Text != "")
            {
                userSkill.UserSkillId = Convert.ToInt32(lblUserSkillId.Text);
            }
            userSkill.UserId = SessionHelper.getUserSession().userid;
            userSkill.SkillId = Convert.ToInt32(ddlSkill.SelectedValue);
            userSkill.SkillDetail = txtSkillDetail.Text;
            userSkill.IsActive = true;
            return userSkill;
        }
        public void FormReset()
        {
            lblUserSkillId.Text = "";
            ddlSkill.SelectedIndex = 0;
            txtSkillDetail.Text = "";
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }
        public bool DeleteUserSkillByUserSkillId(int userSkillId)
        {
            appmanager = new AppManager();
            return appmanager.DeleteUserSkillByUserSkillId(userSkillId, ref returnMessage);
        }

        protected void rptruserSkill_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "USERSKILLDELETE")
            {
                if (DeleteUserSkillByUserSkillId(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                }
            }
            else if (e.CommandName == "USERSKILLEDIT")
            {
                userSkill = GetUserHobbyByUserHobbyId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (userSkill != null)
                {
                    ObjectToForm(userSkill);
                    btnCancel.Visible = true;
                    btnBack.Visible = false;
                }

            }
        }

        public UserSkill GetUserHobbyByUserHobbyId(int userSkillId)
        {
            appmanager = new AppManager();
            return appmanager.GetUserSkillByUserSkillyId(userSkillId, ref returnMessage);
        }

        public UserSkill ObjectToForm(UserSkill userskill)
        {
            lblUserSkillId.Text = userskill.UserSkillId.ToString();
            ddlSkill.SelectedValue = userskill.SkillId.ToString();
            txtSkillDetail.Text = userskill.SkillDetail;
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
            return userskill;
        }


    }
}