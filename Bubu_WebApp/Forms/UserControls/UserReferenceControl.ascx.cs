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
    public partial class UserReferenceControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public MiscellaneousOperation misop;
        public List<UserReference> userReferences;
        public UserReference userReference;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                FillReference();
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }

        private void FormLoad(int userId)
        {
            FillUserReference(userId);
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }
        public void FillUserReference(int userId)
        {
            appmanager = new AppManager();
            userReferences = appmanager.GetUserReferenceByUserId(userId, ref returnMessage);
            rptruserreference.DataSource = userReferences;
            rptruserreference.DataBind();
        }


        private void FillReference()
        {
            misop = new MiscellaneousOperation();
            misop.FillReference(ref ddlReference);
        }
        //FillReference
        protected void btnSave_Click(object sender, EventArgs e)
        {

            appmanager = new AppManager();
            if (appmanager.SaveUserReference(FormToObjet(), ref returnMessage))
            {
                FormReset();
                FormLoad(SessionHelper.getUserSession().userid);
            }
            else
            {
                lblError.Text = returnMessage;
            }

        }

        private UserReference FormToObjet()
        {
            userReference = new UserReference();
            if (lblUserreferenceId.Text != "")
            {
                userReference.UserReferenceId = Convert.ToInt32(lblUserreferenceId.Text);
            }
            userReference.UserId = SessionHelper.getUserSession().userid;
            userReference.ReferenceId = Convert.ToInt32(ddlReference.SelectedValue);
            userReference.ReferenceName = txtReferenceName.Text;
            userReference.ReferencePosition = txtPosition.Text;
            userReference.ReferenceCompany = txtCompany.Text;
            userReference.ReferenceContactNo = txtContact.Text;
            userReference.IsActive = true;
            return userReference;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset();
        }

        public void FormReset()
        {
            lblUserreferenceId.Text = "";
            ddlReference.SelectedIndex = 0;
            txtReferenceName.Text = "";
            txtPosition.Text = "";
            txtCompany.Text = "";
            txtContact.Text = "";
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumVitae.aspx");
        }
        public bool DeleteUserReference(int userReferenceId)
        {
            appmanager = new AppManager();
            return appmanager.DeleteUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        protected void rptruserreference_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "USERREFERENCEDELETE")
            {
                if (DeleteUserReference(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    FormReset();
                    FormLoad(SessionHelper.getUserSession().userid);
                }
            }
            else if (e.CommandName == "USERREFERENCEEDIT")
            {
                userReference = GetUserReferenceByUserReferenceId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (userReference != null)
                {
                    ObjectToForm(userReference);
                    btnCancel.Visible = true;
                    btnBack.Visible = false;
                }

            }
        }
        public UserReference GetUserReferenceByUserReferenceId(int userReferenceId)
        {
            appmanager = new AppManager();
            return appmanager.GetUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public UserReference ObjectToForm(UserReference userReference)
        {
            lblUserreferenceId.Text = userReference.UserReferenceId.ToString();
            ddlReference.SelectedValue = userReference.ReferenceId.ToString();
            txtReferenceName.Text = userReference.ReferenceName;
            txtPosition.Text = userReference.ReferencePosition;
            txtCompany.Text = userReference.ReferenceCompany;
            txtContact.Text = userReference.ReferenceContactNo;
            btnSave.Visible = true;
            btnBack.Visible = true;
            btnCancel.Visible = false;
            return userReference;
        }

    }
}