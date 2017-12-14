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
    public partial class AddBusinessClubRequest : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string ErrorMessage = "";
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
                        //fillUserList(businessClubId);
                        btnAdd.Visible = true; btnCancel.Visible = true;
                    }
                    else
                    { btnAdd.Visible = false; btnCancel.Visible = false; }
                }
                else
                {
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                }
            }
        }
        //public void fillUserList(int businessClubId)
        //{
        //    //appmanager = new AppManager();
        //    //List<User> Lusers = appmanager.getUserList(true, businessClubId, ref  ErrorMessage);
        //    //ddlEmployee.DataSource = Lusers;
        //    //ddlEmployee.DataTextField = "UserName";
        //    //ddlEmployee.DataValueField = "UserId";
        //    //ddlEmployee.DataBind();
        //    //new MiscellaneousOperation().addSelectInDropdown(ref ddlEmployee);
        //}
        public User GetuserByEmailAddressFirstNameLastName(string fname, string lname, string email)
        {
            appmanager = new AppManager();
            return appmanager.GetuserByEmailAddressFirstNameLastName(fname, lname, email);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                Response.Redirect("~/Forms/BusinessClubDetail.aspx?id=" + Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString())));
            }
            else
            {
                Response.Redirect("~/Forms/BusinessClubDetail.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            User user = GetuserByEmailAddressFirstNameLastName(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            if (user == null)
            {
                MisOp.ShowMessage(this, "The user with the mentioned email address or first and last name is not exists.", "Invalid User", true);
                return;
            }

            BusinessClubJoinRequest bcjr = new BusinessClubJoinRequest();
            // bcjr.BusinessClubJoinRequestId = Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
            bcjr.RequestedBy = SessionHelper.getUserSession().userid;
            //bcjr.RequestTo = Convert.ToInt32(ddlEmployee.SelectedValue);
            bcjr.fullName = txtFirstName.Text + " " + txtLastName.Text;
            bcjr.RequestedMessage = "There is an invitation for you to join Busines Club(&BCN&) ";
            bcjr.CreatedBy = SessionHelper.getUserSession().userid;
            bcjr.CreatedDate = DateTime.Now;
            bcjr.RequestedBusinessClubId = Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString()));
            bcjr.IsActive = true;
            bcjr.message = txtMessage.Text;

            appmanager = new AppManager();
            appmanager.InsertBusinessClubJoinRequest(bcjr, ref ErrorMessage);
            MisOp.ShowMessage(this, ErrorMessage, "Join Request", true);


        }
    }
}