using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFJobSearch
    {
        public BubuEntities bubucontext;
        bool result = false;
        int userId = 0;
        public EFJobSearch()
        {
            bubucontext = new BubuEntities();
            bubucontext.Configuration.ProxyCreationEnabled = true;
            bubucontext.Configuration.LazyLoadingEnabled = true;

        }
        public List<Vacancy> JobSearch(int? companyId, JobPrivacy jobprivacy, string sectorName, string function,
            string region, string jobType, string searchText, ref string returnMessage)
        {
            IQueryable<Vacancy> searchResult = bubucontext.Vacancies.Include("CompanyInformation")
                .Include("Region")
                .Include("JobType").Where(a => a.IsActive == true && a.IsVacancyCompleted == false);
            if (companyId != null && companyId > 0)
            {
                searchResult = searchResult.Where(a => a.CompanyId == companyId);
            }
            if (jobprivacy == JobPrivacy.Private)
            {
                searchResult = searchResult.Where(a => a.IsPrivate == true);
            }
            else if (jobprivacy == JobPrivacy.Public)
            {
                searchResult = searchResult.Where(a => a.IsPrivate == false);
            }
            if (sectorName != "")
            {
                searchResult = searchResult.Where(a => a.CompanyInformation.CompanySector == sectorName);
            }
            if (function != "")
            {
                searchResult = searchResult.Where(a => a.JobFunction == function);
            }
            if (region != "")
            {
                searchResult = searchResult.Where(a => a.Region.RegionName == region);
            }
            if (jobType != "")
            {
                searchResult = searchResult.Where(a => a.JobType.JobTypeName == jobType);
            }
            if (searchText.Trim() != "")
            {
                searchResult = searchResult.Where(a => a.CompanyInformation.CompanySector.Contains(searchText) ||
                                a.JobFunction.Contains(searchText) ||
                                a.Region.RegionName.Contains(searchText) ||
                                a.JobType.JobTypeName.Contains(searchText)
                   );
            }


            return searchResult.OrderByDescending(a => a.CreatedDate).ToList();

        }
        public List<Region> GetRegionList()
        {
            return bubucontext.Regions.Where(a => a.IsActive == true).ToList();
        }
        public List<string> GetDistinctJobFunctionsList()
        {
            return (from vacancy in bubucontext.Vacancies select vacancy.JobFunction).Distinct().ToList();
        }
        public List<string> GetDistinctSector()
        {
            return (from ci in bubucontext.CompanyInformations select ci.CompanySector).Distinct().ToList();
        }
        public bool InsertVacancyApply(VacancyApply vacancyApply, ref string returnMessage)
        {
            VacancyApply vacancyApplyObj = bubucontext.VacancyApplies.Where(a => a.VacancyId == vacancyApply.VacancyId && a.UserId == vacancyApply.UserId).FirstOrDefault();
            if (vacancyApplyObj != null)
            {
                returnMessage = Messages.MessageContent(MessageCode.AlreadyAppliedForVacancy);
                return false;
            }
            else
            {
                bubucontext.Entry(vacancyApply).State = EntityState.Added;
                bubucontext.VacancyApplies.Add(vacancyApply);
                bubucontext.SaveChanges();
                returnMessage = Messages.MessageContent(MessageCode.AppliedForVacancySaved);
                return false;
            }
        }
        public List<VacancyApply> GetApplicantListByVacancyId(int vacancyId, ref string returnMessage)
        {
            return bubucontext.VacancyApplies.Include("User")
                .Include("User.Domicile")
                .Include("User.UserWorkExperiences")
                .Include("User.UserQualifications")
                .Include("User.UserQualifications.Qualification")
                .Where(a => a.IsCancelByEmployer != true && a.IsActive == true && a.VacancyId == vacancyId).ToList();
        }
        public bool InsertUserInbox(UserInbox userInbox, ref string returnMessage)
        {
            bubucontext.Entry(userInbox).State = EntityState.Added;
            bubucontext.UserInboxes.Add(userInbox);
            bubucontext.SaveChanges();
            returnMessage = Messages.MessageContent(MessageCode.MessageSentSuccessfully);
            return false;
        }
        public void UpdateVacancyApplyIsCancelEmployeer(int vacancyApplyId, int SenderId, bool IsCancelByEmployee)
        {
            VacancyApply vacancyApplyObj = bubucontext.VacancyApplies.
                Include("Vacancy").Include("Vacancy.CompanyInformation").
                Where(a => a.VacancyApplyId == vacancyApplyId).FirstOrDefault();
            if (vacancyApplyObj != null)
            {
                vacancyApplyObj.IsCancelByEmployer = IsCancelByEmployee;
                //====add UserInbox userInbox
                UserInbox userInbox = new UserInbox();
                userInbox.InboxUserId = vacancyApplyObj.UserId;
                userInbox.SenderId = SenderId;
                userInbox.VacancyId = vacancyApplyObj.VacancyId;
                userInbox.Message = "Your  application for <b>" + vacancyApplyObj.Vacancy.JobTitle + "</b> at " + vacancyApplyObj.Vacancy.CompanyInformation.CompanyName + " has been cancelled by Employer";
                userInbox.IsActive = true;
                bubucontext.UserInboxes.Add(userInbox);
                bubucontext.SaveChanges();
            }
        }


        public List<User> GetUserListSearch(EnumGender? enumGender, int? maximumAge, ref string returnMessage)
        {
            int userid = ((UserSession)System.Web.HttpContext.Current.Session[SessionNames.S_User.ToString()]).userid;
            IQueryable<User> userList = bubucontext.Users
                .Include("Domicile")
                .Include("UserWorkExperiences")
                .Include("UserQualifications")
                .Include("UserQualifications.Qualification")
                .Where(a => a.IsActive == true && a.Userid != userid && a.AccountTypeId ==2);
            if (enumGender != null && enumGender.Value != EnumGender.NULL)
            {
                string gender = enumGender.Value.ToString();
                userList = userList.Where(a => a.Gender.ToUpper() == gender.ToUpper());
            }
            if (maximumAge != null && maximumAge.HasValue && maximumAge.Value > 0)
            {
                DateTime maximumYear = EFJobSearch.GetDateFromAge(maximumAge.Value);
                userList = userList.Where(a => a.DateOfBirth != null && a.DateOfBirth >= maximumYear);
            }
            return userList.ToList();
            //return bubucontext.Users
            //    .Include("Domicile")
            //    .Include("UserWorkExperiences")
            //    .Include("UserQualifications")
            //    .Include("UserQualifications.Qualification")
            //    .Where(a => a.IsActive == true && a.Userid != userid
            //    && a.Gender.ToUpper() == enumGender.ToString()

            //    ).ToList();

        }
        public static DateTime GetDateFromAge(int age)
        {
            return DateTime.Now.AddYears(-age);
        }


    }
}
