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
    public partial class BusinessClubUpdatedControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public List<BusinessClub> businessClubs;
        public BusinessClubMember businessClubMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
        }
        private void FormLoad(int userId)
        {
            FillBusinessClub(userId);
        }
        public void FillBusinessClub(int userId)
        {
            appmanager = new AppManager();
            businessClubs = appmanager.GetBusinessClubs(userId, ref returnMessage);
            foreach (var businessClubObj in businessClubs)
            {
                if (businessClubObj.UserCreatedId != userId &&
                    (!businessClubObj.BusinessClubMembers.Any(a => a.MemberId == userId)))
                {
                    businessClubObj.IsActive = true;
                }
                else

                { businessClubObj.IsActive = false; }
            }
            rptrBusinessClub.DataSource = businessClubs;
            rptrBusinessClub.DataBind();

        }
        public string GetImage(object img, object format)
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

        protected void rptrBusinessClub_OnItemCommande(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "GRIDJOIN")
            {
                this.InsertBusinessClubMember(Convert.ToInt32(e.CommandArgument.ToString()), SessionHelper.getUserSession().userid);
            }
        }
        public void InsertBusinessClubMember(int businessCluId, int UserId)
        {
            appmanager = new AppManager();
            businessClubMember = new BusinessClubMember();
            businessClubMember.MemberId = UserId;
            businessClubMember.BusinessClubId = businessCluId;
            businessClubMember.IsActive = true;
            if (appmanager.InsertBusinessClubMember(businessClubMember, ref returnMessage))
            {
                FormLoad(SessionHelper.getUserSession().userid);
            }
            lblError.Text = returnMessage;

        }
        protected void BusinessClubDetail_Click(object sender, EventArgs e)
        {
            LinkButton btnBusinessClubDetail = (LinkButton)sender;
            string businessClubId = btnBusinessClubDetail.ToolTip;
            Response.Redirect("~/Forms/BusinessClubDetail.aspx?idx=" + HelperFunction.EncryptData(businessClubId.ToString()));

        }

        protected void btnAddBusinessCub_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/AddBusinessClub.aspx");
        }

     





    }
}