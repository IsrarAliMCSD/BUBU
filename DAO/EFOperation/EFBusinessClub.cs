using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFBusinessClub
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFBusinessClub()
        {
            bubucontext = new BubuEntities();
            bubucontext.Configuration.ProxyCreationEnabled = true;
            bubucontext.Configuration.LazyLoadingEnabled = true;
        }

        public BusinessClub GetBusinessClubByClubName(string ClubName)
        {
            return bubucontext.BusinessClubs.Where(a => a.BusinessClubName == ClubName).FirstOrDefault();
        }

        public bool SaveBusinessClub(BusinessClub businessClub, ref string returnMessage)
        {
            BusinessClub businessClubObjOtherObject;
            BusinessClub businessClubObj;
            result = true;
            using (bubucontext = new BubuEntities())
            {
                if (businessClub.BusinessClubId > 0)
                {
                    businessClubObj = bubucontext.BusinessClubs.Where(a => a.BusinessClubId == businessClub.BusinessClubId).FirstOrDefault();
                    if (businessClubObj == null)
                    {
                        returnMessage = Messages.MessageContent(MessageCode.BusinessClubNotExists);
                        return false;
                    }
                    businessClubObjOtherObject = this.GetBusinessClubByClubName(businessClub.BusinessClubName);
                    if (businessClubObjOtherObject != null && businessClubObjOtherObject.BusinessClubId != businessClub.BusinessClubId)
                    {
                        returnMessage = Messages.MessageContent(MessageCode.BusinessClubAlreadyExists);
                        return false;
                    }
                    //=============update Business Club
                    businessClubObj.BusinessClubMembers = businessClub.BusinessClubMembers;
                    businessClubObj.Purpose = businessClub.Purpose;
                    businessClubObj.About = businessClub.About;
                    businessClubObj.IsActive = businessClub.IsActive;
                    if (businessClub.ContentData != null && businessClub.format != "")
                    {
                        businessClubObj.ContentData = businessClub.ContentData;
                        businessClubObj.ContentType = businessClub.ContentType;
                        businessClubObj.format = businessClub.format;
                    }
                    bubucontext.SaveChanges();
                }
                else if (this.GetBusinessClubByClubName(businessClub.BusinessClubName) == null)
                {
                    bubucontext.Entry(businessClub).State = EntityState.Added;
                    bubucontext.BusinessClubs.Add(businessClub);
                    BusinessClubMember businessClubMember = GetBusinessClubInformation(businessClub.UserCreatedId, businessClub.BusinessClubId);
                    bubucontext.Entry(businessClubMember).State = EntityState.Added;
                    bubucontext.BusinessClubMembers.Add(businessClubMember);
                    bubucontext.SaveChanges();

                }

            }
            return result;
        }

        public List<BusinessClub> GetBusinessClubs(ref string returnMessage)
        {
            return bubucontext.BusinessClubs.Where(a => a.IsActive == true).ToList();
        }

        public List<BusinessClub> GetBusinessClubs(int userId, ref string returnMessage)
        {
            return bubucontext.BusinessClubs.Include("BusinessClubMembers").Where(a => a.IsActive == true).ToList();
        }



        public BusinessClub GetBusinessClub(int businessClubId, ref string returnMessage)
        {
            return bubucontext.BusinessClubs.Where(a => a.BusinessClubId == businessClubId).FirstOrDefault();
        }
        public BusinessClubMember GetBusinessClubInformation(int memberId, int businessClubId)
        {
            BusinessClubMember businessClubMember = new BusinessClubMember();
            businessClubMember.MemberId = memberId;
            businessClubMember.BusinessClubId = businessClubId;
            businessClubMember.IsActive = true;
            return businessClubMember;
        }
        public bool InsertBusinessClubMember(BusinessClubMember businessClubMember, ref string returnMessage)
        {
            var businessClubMemberObj = bubucontext.BusinessClubMembers.Where(a => a.MemberId == businessClubMember.MemberId &&
                a.BusinessClubId == businessClubMember.BusinessClubId && a.IsActive == true).FirstOrDefault();
            if (businessClubMemberObj != null && businessClubMemberObj.BusinessClubMemberId > 0)
            {
                returnMessage = Messages.MessageContent(MessageCode.BusinessClubAlreadyMember);
                return false;
            }

            bubucontext.Entry(businessClubMember).State = EntityState.Added;
            bubucontext.BusinessClubMembers.Add(businessClubMember);
            bubucontext.SaveChanges();
          //  returnMessage = Messages.MessageContent(MessageCode.BusinessClubAlreadyMember);
            return true;
        }

        public BusinessClub GetBusinessClubWithMemberList(int businessClubId, ref string returnMessage)
        {
            return bubucontext.BusinessClubs.Include("BusinessClubMembers")
                    .Include("BusinessClubMembers.User")
                    .Include("BusinessClubMembers.User.Domicile")
                    .Include("BusinessClubMembers.User.UserWorkExperiences")
                    .Include("BusinessClubMembers.User.UserQualifications")
                    .Include("BusinessClubMembers.User.UserQualifications.Qualification")
                    .Where(a => a.BusinessClubId == businessClubId && a.IsActive == true).FirstOrDefault();
        }
        public bool InsertBusiensNews(BusienssClubNewsInfo businessClubNewsInfo, ref string returnMessage)
        {
            using (bubucontext)
            {
                businessClubNewsInfo.CreatedDate = DateTime.Now;
                bubucontext.Entry(businessClubNewsInfo).State = EntityState.Added;
                bubucontext.BusienssClubNewsInfoes.Add(businessClubNewsInfo);
                bubucontext.SaveChanges();
            }
            return true;

        }
        public List<BusienssClubNewsInfo> GetBusienssClubNewsInfo(int businessClubId)
        {
            return bubucontext.BusienssClubNewsInfoes.Where(a => a.IsActive == true).OrderByDescending(b => b.BusinessClubNewsInfoId).ToList();
        }
        public bool DeleteBusienssClubNewsInfo(int busienssClubNewsInfoId)
        {
            BusienssClubNewsInfo BusienssClubNewsInfoObj = bubucontext.BusienssClubNewsInfoes.Where(a => a.BusinessClubNewsInfoId == busienssClubNewsInfoId).FirstOrDefault();
            if (BusienssClubNewsInfoObj != null)
            {
                BusienssClubNewsInfoObj.IsActive = false;
                bubucontext.SaveChanges();
            }
            return true;
        }

        public List<BusinessClub> GetBusinessClubByUserId(int userId)
        {
            return bubucontext.BusinessClubs.Where(a => a.UserCreatedId == userId && a.IsActive == true).OrderByDescending(b => b.BusinessClubId).ToList();
        }
        public List<BusienssClubNewsInfo> GetBusinessClubNewsInfo()
        {
            return bubucontext.BusienssClubNewsInfoes.Include("BusinessClub").Where(a => a.IsActive == true).OrderByDescending(b => b.BusinessClubNewsInfoId).ToList();
        }
        public List<BusinessClubMember> GetBusinessClubUserByBusinessClubId(int BusinessClubId)
        {
            return bubucontext.BusinessClubMembers.Where(a => a.BusinessClubId == BusinessClubId && a.IsActive == true).ToList();
        }
    }
}
