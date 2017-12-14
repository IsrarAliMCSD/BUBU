using AppController;
using Bubu_WebApp.App_Class;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class BusinessClubViewControl : System.Web.UI.UserControl
    {
        public int businessClubId { get; set; }
        public AppManager appmanager;
        public string returnMessage = "";
        public BusinessClub businessClub;
        public List<BusinessClubMember> businessClubMembers;
        public MiscellaneousOperation misOps;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (businessClubId != null && businessClubId > 0)
                {
                    FormLad(businessClubId, SessionHelper.getUserSession().userid);
                }
            }
        }
        public void FormLad(int businessClubId, int UserId)
        {
            appmanager = new AppManager();
            businessClub = appmanager.GetBusinessClubWithMemberList(businessClubId, ref returnMessage);
            if (businessClub != null)
            {
                ObjectToForm(businessClub);
                if (businessClub.UserCreatedId == SessionHelper.getUserSession().userid)
                {
                    btnAddNewMember.Visible = true;
                }
                else
                {
                    btnAddNewMember.Visible = false;
                }
            }
            FillClubMember(businessClubId);
        }

        private void FormReset()
        {
        }
        public void ObjectToForm(BusinessClub businessClub)
        {
            misOps = new MiscellaneousOperation();
            lblBusinessClubName.Text = businessClub.BusinessClubName;
            if (MisOp.IsImageFileFormat(businessClub.format))
            {
                imgLogo.ImageUrl = misOps.GetImage(businessClub.ContentData);
            }
            else
            {
                imgLogo.ImageUrl = MisOp.GetImageURL(businessClub.format);
            }
            lblAbout.Text = businessClub.About;
            lblPurpose.Text = businessClub.Purpose;
            lblBusinessClubId.Text = businessClub.BusinessClubId.ToString();
        }
        protected void lbtnAddMember_Click(object sender, EventArgs e)
        {

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

        public void FillClubMember(int businessClubId)
        {
            appmanager = new AppManager();
            businessClub = appmanager.GetBusinessClubWithMemberList(businessClubId, ref returnMessage);
            if (businessClub != null)
            {
                List<userDetail> businessClub_userDetail = businessClub.BusinessClubMembers.Select(
                 x => new userDetail
                 {
                     user = x.User,
                     UserWorkExperienceLatest = x.User.UserWorkExperiences.Count > 0 && x.User.UserWorkExperiences.Any(b => b.IsActive == true) ?
                     x.User.UserWorkExperiences.OrderByDescending(b => b.IsCurrentJob).FirstOrDefault() : new UserWorkExperience(),
                     domicile = x.User.Domicile,
                     UserQualificationLatest = x.User.UserQualifications.Count > 0 && x.User.UserWorkExperiences.Any(b => b.IsActive == true) ?
                     x.User.UserQualifications.OrderByDescending(b => b.IsCompleted == false).FirstOrDefault() : null
                 }
              ).ToList();
                gvBusinessMember.DataSource = businessClub_userDetail;
                gvBusinessMember.DataBind();
                lblMemberCount.Text = businessClub.BusinessClubMembers.Count.ToString();
            }
        }

        protected void btnAddNewMember_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                Response.Redirect("~/Forms/AddBusinessClubDetail.aspx?id=" + Int32.Parse(HelperFunction.DecryptData(Request.QueryString[0].ToString())));
            }
            else
            {
                Response.Redirect("~/Forms/AddBusinessClubDetail.aspx");
            }
                
        }
    }
}