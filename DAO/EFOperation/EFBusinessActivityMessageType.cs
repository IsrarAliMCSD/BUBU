using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFBusinessActivityMessageType
    {
        public BubuEntities bubucontext;
        public EFBusinessClub eFBusinessClub;
        bool result = false;
        public EFBusinessActivityMessageType()
        {
            bubucontext = new BubuEntities();
            bubucontext.Configuration.ProxyCreationEnabled = true;
            bubucontext.Configuration.LazyLoadingEnabled = true;
        }
        public List<BusinessActivityMessageType> GetBusinessActivityMessageTypes()
        {
            return bubucontext.BusinessActivityMessageTypes.Where(a => a.IsActive == true).ToList();
        }
        public bool SaveBusinessActivity(BusinessClubActivity businessClubActivity, ref string returnMessage)
        {
            int userid = ((UserSession)System.Web.HttpContext.Current.Session[SessionNames.S_User.ToString()]).userid;
            result = false;
            try
            {


                using (bubucontext)
                {
                    if (businessClubActivity != null && businessClubActivity.BusinesClubActivityId > 0)
                    {
                        BusinessClubActivity businessClubActivityObj = bubucontext.BusinessClubActivities.Where(
                            a => a.BusinesClubActivityId == businessClubActivity.BusinesClubActivityId).FirstOrDefault();
                        businessClubActivityObj.IsActive = true;
                        businessClubActivityObj.BusinessClubMessageTypeId = businessClubActivity.BusinessClubMessageTypeId;
                        businessClubActivityObj.Subject = businessClubActivity.Subject;
                        businessClubActivityObj.BusinessClubId = businessClubActivity.BusinessClubId;
                        businessClubActivityObj.Description = businessClubActivity.Description;
                        businessClubActivityObj.ActivityDate = businessClubActivity.ActivityDate;
                        businessClubActivityObj.LastModifiedDate = DateTime.Now;
                        businessClubActivityObj.LastModifiedBy = userid;
                        businessClubActivityObj.DeadLine = businessClubActivity.DeadLine;
                        businessClubActivityObj.BusinessClubActivityDetails = this.GetBusinessClubActivityDetailList(businessClubActivity.BusinessClubId, userid);
                        returnMessage = "The event has been saved successfully";
                        result = true;
                    }

                    else
                    {
                        businessClubActivity.CreatedDate = DateTime.Now;
                        businessClubActivity.CreatedBy = userid;
                        businessClubActivity.BusinessClubActivityDetails = this.GetBusinessClubActivityDetailList(businessClubActivity.BusinessClubId, userid);
                        bubucontext.BusinessClubActivities.Add(businessClubActivity);
                        returnMessage = "The event has been saved successfully";
                        result = true;
                    }
                    bubucontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public List<BusinessClubActivityDetail> GetBusinessClubActivityDetailList(int businessClubId, int createdy)
        {
            eFBusinessClub = new EFBusinessClub();
            List<BusinessClubActivityDetail> lstBusinessClubActivityDetail = new List<BusinessClubActivityDetail>();
            var businessClubMembers = eFBusinessClub.GetBusinessClubUserByBusinessClubId(businessClubId);
            foreach (var item in businessClubMembers)
            {
                BusinessClubActivityDetail obj = new BusinessClubActivityDetail();
                obj.UserId = item.MemberId;
                obj.CreatedBy = createdy;
                obj.CreatedDate = DateTime.Now;
                obj.IsActive = true;
                lstBusinessClubActivityDetail.Add(obj);
            }
            return lstBusinessClubActivityDetail;
        }

        public List<BusinessClubActivity> GetBusinessEventWithMessages(int? businessClubId, int userId)
        {
            IQueryable<BusinessClubActivity> businessClubActivityList = bubucontext.BusinessClubActivities.Include("User").
              Include("BusinessClub").Include("BusinessActivityMessageType").
              Include("BusinessClubActivityComments");
            //  businessClubActivityList.ToList();

            if (businessClubId != null && businessClubId > 0)
            {
                businessClubActivityList = businessClubActivityList.Where(a => a.BusinessClubId == businessClubId);
            }
            //if (userId != null && userId > 0)
            //{
            //    businessClubActivityList = businessClubActivityList.Where(a => a.BusinessClub.BusinessClubMembers.Any(b => b.MemberId == userId && b.IsActive == true));
            //}

            return businessClubActivityList.ToList();

            //IQueryable<BusinessClubActivity> businessClubActivityList = bubucontext.BusinessClubActivities.Include("User").
            //    Include("BusinessClub").Include("BusinessActivityMessageType").
            //    Include("BusinessClubActivityComments");

            //if (businessClubId != null && businessClubId > 0)
            //{
            //    businessClubActivityList = businessClubActivityList.Where(a => a.BusinessClubId == businessClubId);
            //}
            //if (userId != null && userId > 0)
            //{
            //    businessClubActivityList = businessClubActivityList.Where(a => a.BusinessClub.BusinessClubMembers.Any(b => b.MemberId == userId && b.IsActive==true));
            //}

            //return businessClubActivityList.ToList();
        }
        public void SaveBusinessClubActivityComments(BusinessClubActivityComment businessClubActivityComment)
        {
            int userid = ((UserSession)System.Web.HttpContext.Current.Session[SessionNames.S_User.ToString()]).userid;
            using (bubucontext)
            {
                businessClubActivityComment.CreatedDate = DateTime.Now;
                businessClubActivityComment.CreatedBy = userid;
                bubucontext.BusinessClubActivityComments.Add(businessClubActivityComment);
                bubucontext.SaveChanges();
            }
        }

        public List<BusinessClubActivityDetail> GetBusinessEventDetail(int? businessClubId, int userId)
        {
            IQueryable<BusinessClubActivityDetail> businessClubActivityDetailList = bubucontext.BusinessClubActivityDetails.Include("User").
                Include("BusinessClubActivity").
              Include("BusinessClubActivity.BusinessClub").Include("BusinessClubActivity.BusinessActivityMessageType").
              Where(a => a.IsActive && a.BusinessClubActivity.IsActive);
            //  businessClubActivityList.ToList();
            //if (businessClubId != null && businessClubId > 0)
            //{
            //    businessClubActivityDetailList = businessClubActivityDetailList.Where(a => a.BusinessClubId == businessClubId);
            //}
            if (userId != null && userId > 0)
            {
                businessClubActivityDetailList = businessClubActivityDetailList.Where(a => a.IsActive && a.UserId == userId);
            }

            return businessClubActivityDetailList.ToList();
        }

        //========Job News
        public List<UserInbox> GetJobNews(int userid)
        {
            using (bubucontext)
            {
                return bubucontext.UserInboxes.Include("User").Include("User1").Where(a => a.IsActive &&
                    a.InboxUserId == userid
                    ).ToList();
            }
        }


        public List<User> GetListOfUser()
        {
            return bubucontext.Users.Where(a => a.IsActive && a.AccountTypeId == 2).ToList();
        }
        public bool SaveUserMessage(UserMessageDetail obj, ref string returnMessage)
        {
            using (bubucontext)
            {

                bubucontext.UserMessageDetails.Add(obj);
                returnMessage = "The Message has been saved successfully";
                bubucontext.SaveChanges();
                result = true;
                return result;
            }
        }


        public List<UserMessageDetail> GetUserMessage(int userid)
        {
            return bubucontext.UserMessageDetails.Where(a => a.IsActiveFromReceiver.Value && a.ReceiverId == userid).ToList();
        }


    }

}

