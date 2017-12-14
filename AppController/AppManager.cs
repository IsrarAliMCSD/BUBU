using BAL;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class AppManager
    {
        public BALUser balObj;
        public AppManager()
        {
            balObj = new BALUser();
        }
        public User UserLogin(string userName, string password, ref string ErrorMessage)
        {
            return balObj.UserLogin(userName, password, ref ErrorMessage);
        }
        public User GetUserByUserName(string userName, ref string ErrorMessage)
        {
            return balObj.GetUserByUserName(userName, ref ErrorMessage);
        }
        public User InsertUser(User userObj, ref string ErrorMessage)
        {
            return balObj.InsertUser(userObj, ref ErrorMessage);
        }
        public List<AccountType> getAllAccountType(bool allRecord)
        {
            return balObj.getAllAccountType(allRecord);
        }
        public bool GetAccountActivation(string guid, ref string ErrorMessage)
        {
            return balObj.GetAccountActivation(guid, ref  ErrorMessage);
        }
        public User getUserByUserId(int userId, ref string returnMessage)
        {
            return balObj.getUserByUserId(userId, ref returnMessage);
        }
        public User GetallWorkExperience(int userid, ref string returnMessage)
        {
            return balObj.GetallWorkExperience(userid, ref  returnMessage);
        }
        public List<DocumentFormatAllow> getAllDocumentFormatAllowByDocumentType(int documentCategoryId)
        {
            return balObj.getAllDocumentFormatAllowByDocumentType(documentCategoryId);

        }
        public bool updateProfilePic(int userid, byte[] contentData, string contentType, string format, ref string returnMessage)
        {
            return balObj.updateProfilePic(userid, contentData, contentType, format, ref  returnMessage);
        }
        public List<DocumentUpload> getAllDocumentsByUserId(int userid, ref string returnMessage)
        {
            return balObj.getAllDocumentsByUserId(userid, ref  returnMessage);
        }
        public List<DocumentCategory> getAllDocumentCategories()
        {
            return balObj.getAllDocumentCategories();
        }
        public bool SaveDocumentUpload(DocumentUpload documentUploadObject, ref string returnMessage)
        {
            return balObj.SaveDocumentUpload(documentUploadObject, ref  returnMessage);
        }
        public bool DeleteDocumentUpload(int documentUploadId, ref string returnMessage)
        {
            return balObj.DeleteDocumentUpload(documentUploadId, ref  returnMessage);
        }
        public DocumentUpload GetdocumentByUploadDocumentId(int UploadDocumentId, ref string returnMessage)
        {
            return balObj.GetdocumentByUploadDocumentId(UploadDocumentId, ref  returnMessage);
        }
        public List<DocumentUpload> GetAllDocumentByUserIdAndDocumentType(int documentTypeId, int userid)
        {
            return balObj.GetAllDocumentByUserIdAndDocumentType(documentTypeId, userid);
        }
        public bool UpdateUserAndworkCurrentExperienceByUserId(User user, ref string ErrorMessage)
        {
            return balObj.UpdateUserAndworkCurrentExperienceByUserId(user, ref ErrorMessage);
        }
        public List<Country> GetCountries(ref string returnMessage)
        {
            return balObj.GetCountries(ref returnMessage);
        }
        public List<UserQualification> GetQualificationByUserId(int userid, ref string returnMessage)
        {
            return balObj.GetQualificationByUserId(userid, ref returnMessage);
        }
        public List<Qualification> GetQualificationList(ref string returnMessage)
        {
            return balObj.GetQualificationList(ref returnMessage).ToList();
        }
      
        public bool SaveUserQualification(UserQualification userqualification, ref string returnMessage)
        {
            return balObj.SaveUserQualification(userqualification, ref returnMessage);
        }
        public bool DeleteUserQualification(int userQualificationId, ref string returnMessage)
        {
            return balObj.DeleteUserQualification(userQualificationId, ref returnMessage);
        }
        public UserQualification GetUserQualificationById(int userqualificationId, ref string returnMessage)
        {
            return balObj.GetUserQualificationById(userqualificationId, ref  returnMessage);
        }
        public List<UserWorkExperience> GetUserWorkExperienceCurrentJob(int userid, ref string returnMessage)
        {
            return balObj.GetUserWorkExperienceCurrentJob(userid, ref  returnMessage);
        }
        public bool SaveUserWorkExperience(UserWorkExperience userWorkexperience, ref string returnMessage)
        {
            return balObj.SaveUserWorkExperience(userWorkexperience, ref  returnMessage);
        }
        public List<UserWorkExperience> GetUserExperienceByUserId(int userid, ref string returnMessage)
        {
            return balObj.GetUserExperienceByUserId(userid, ref  returnMessage);
        }
        public bool DeleteUserExperienceByUserExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return balObj.DeleteUserExperienceByUserExperienceId(userWorkExperienceId, ref  returnMessage);
        }

        public UserWorkExperience GetUserExperienceByUserWorkExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return balObj.GetUserExperienceByUserWorkExperienceId(userWorkExperienceId, ref  returnMessage);
        }
        public List<Language> GetLanguageList()
        {
            return balObj.GetLanguageList();
        }
        public List<Level> GetLevelList()
        {
            return balObj.GetLevelList();
        }
        public List<UserLanguage> GetUserLanguageByUserId(int userid, ref string returnMessage)
        {
            return balObj.GetUserLanguageByUserId(userid, ref  returnMessage);
        }
        public bool DeleteUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            return balObj.DeleteUserLanguageByUserLanguageId(userLanguageid, ref  returnMessage);
        }
        public UserLanguage GetUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            return balObj.GetUserLanguageByUserLanguageId(userLanguageid, ref  returnMessage);
        }
        public bool SaveUserLanguage(UserLanguage userLanguage, ref string returnMessage)
        {
            return balObj.SaveUserLanguage(userLanguage, ref  returnMessage);
        }
        public List<Commencement> GetCommencements()
        {
            return balObj.GetCommencements();
        }
        public bool UpdateCommencement(int commencementId, int userid, ref string returnMessage)
        {
            return balObj.UpdateCommencement(commencementId, userid, ref returnMessage);
        }
        public List<Reference> GetReferences()
        {
            return balObj.GetReferences().ToList();
        }
        public List<UserReference> GetUserReferenceByUserId(int userId, ref string returnMessage)
        {
            return balObj.GetUserReferenceByUserId(userId, ref returnMessage).ToList();
        }
        public bool DeleteUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return balObj.DeleteUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public UserReference GetUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return balObj.GetUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public bool SaveUserReference(UserReference userReference, ref string returnMessage)
        {
            return balObj.SaveUserReference(userReference, ref  returnMessage);
        }
        public List<Hobby> GetHobbies()
        {
            return balObj.GetHobbies();
        }
        public List<UserHobby> GetUserHobbiesByUserId(int userId, ref string returnMessage)
        {
            return balObj.GetUserHobbiesByUserId(userId, ref returnMessage).ToList();
        }
        public UserHobby GetUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return balObj.GetUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }
        public bool DeleteUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return balObj.DeleteUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }
        public bool SaveUserHobby(UserHobby userHobby, ref string returnMessage)
        {
            return balObj.SaveUserHobby(userHobby, ref returnMessage);
        }
        public List<Skill> GetSkills()
        {
            return balObj.GetSkills();
        }
        public List<UserSkill> GetUserSkillsByUserId(int userId, ref string returnMessage)
        {
            return balObj.GetUserSkillsByUserId(userId, ref returnMessage).ToList();
        }
        public UserSkill GetUserSkillByUserSkillyId(int userSkillId, ref string returnMessage)
        {
            return balObj.GetUserSkillByUserSkillyId(userSkillId, ref returnMessage);
        }
        public bool DeleteUserSkillByUserSkillId(int userSkillId, ref string returnMessage)
        {
            return balObj.DeleteUserSkillByUserSkillId(userSkillId, ref returnMessage);
        }
        public bool SaveUserSkill(UserSkill userSkill, ref string returnMessage)
        {
            return balObj.SaveUserSkill(userSkill, ref returnMessage);
        }
        public CompanyInformation GetCompanyInformationByUserId(int userId)
        {
            return balObj.GetCompanyInformationByUserId(userId);
        }
        public bool SaveCompanyInformation(CompanyInformation companyInformation, ref string returnMessage)
        {
            return balObj.SaveCompanyInformation(companyInformation, ref returnMessage);
        }
        public List<CompanyAbout> GetCompanyAboutUsList(int userId)
        {
            return balObj.GetCompanyAboutUsList(userId);
        }
        public bool DeleteCompanyAboutUsByCompanyAboutUsId(int companyAboutUsId)
        {
            return balObj.DeleteCompanyAboutUsByCompanyAboutUsId(companyAboutUsId);
        }
        public CompanyAbout GetCompanyAboutUsByCompanyAboutId(int companyAboutUsId)
        {
            return balObj.GetCompanyAboutUsByCompanyAboutId(companyAboutUsId);
        }
        public bool SaveCompanyAbout(CompanyAbout companyAbout, ref string returnMessage)
        {
            return balObj.SaveCompanyAbout(companyAbout, ref  returnMessage);
        }
        public List<Vacancy> GetVacancyListByUserId(int userId, bool isPrivateInclude, ref string returnMessage)
        {
            return balObj.GetVacancyListByUserId(userId, isPrivateInclude, ref returnMessage);
        }
        public List<JobType> GetJobType()
        {
            return balObj.GetJobType();
        }
        public bool SaveVacancy(Vacancy vacancy, ref string returnMessage)
        {
            return balObj.SaveVacancy(vacancy, ref   returnMessage);
        }
        public bool DeleteVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return balObj.DeleteVacancyByVacancyId(vacancyId, ref   returnMessage);
        }
        public Vacancy GetVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return balObj.GetVacancyByVacancyId(vacancyId, ref   returnMessage);
        }
        public List<WorkExperience> GetWorkExperience()
        {
            return balObj.GetWorkExperience();
        }
        public List<Domicile> GetDomiciles()
        {
            return balObj.GetDomiciles();
        }

        public List<Vacancy> JobSearch(int? companyId, JobPrivacy jobprivacy, string sectorName, string function,
         string region, string jobType, string searchText, ref string returnMessage)
        {
            return balObj.JobSearch(companyId, jobprivacy, sectorName, function, region, jobType, searchText, ref returnMessage);
        }
        public List<Region> GetRegionList()
        {
            return balObj.GetRegionList();
        }
        public List<string> GetDistinctJobFunctionsList()
        {
            return balObj.GetDistinctJobFunctionsList();
        }
        public List<string> GetDistinctSector()
        {
            return balObj.GetDistinctSector();
        }
        public CompanyInformation GetCompanyInformationByCompanyId(int userId)
        {
            return balObj.GetCompanyInformationByCompanyId(userId);
        }
        public bool InsertVacancyApply(VacancyApply vacancyApply, ref string returnMessage)
        {
            return balObj.InsertVacancyApply(vacancyApply, ref returnMessage);
        }
        public List<VacancyApply> GetApplicantListByVacancyId(int vacancyId, ref string returnMessage)
        {
            return balObj.GetApplicantListByVacancyId(vacancyId, ref returnMessage);
        }
        public bool InsertUserInbox(UserInbox userInbox, ref string returnMessage)
        {
            return balObj.InsertUserInbox(userInbox, ref returnMessage);
        }
        public void UpdateVacancyApplyIsCancelEmployeer(int vacancyApplyId, int SenderId, bool IsCancelByEmployee)
        {
            balObj.UpdateVacancyApplyIsCancelEmployeer(vacancyApplyId, SenderId, IsCancelByEmployee);
        }
        public List<Vacancy> GetVacancyListSearch(int userId, bool isPrivateInclude, string textSearch, ref string returnMessage)
        {
            return balObj.GetVacancyListSearch(userId, isPrivateInclude, textSearch, ref   returnMessage);
        }
        public bool SaveBusinessClub(BusinessClub businessClub, ref string returnMessage)
        {
            return balObj.SaveBusinessClub(businessClub, ref  returnMessage);
        }
        public List<BusinessClub> GetBusinessClubs(ref string returnMessage)
        {
            return balObj.GetBusinessClubs(ref  returnMessage);
        }
        public List<BusinessClub> GetBusinessClubs(int userId, ref string returnMessage)
        {
            return balObj.GetBusinessClubs(userId, ref  returnMessage);
        }
        public BusinessClub GetBusinessClub(int businessClubId, ref string returnMessage)
        {
            return balObj.GetBusinessClub(businessClubId, ref  returnMessage);
        }
        public bool InsertBusinessClubMember(BusinessClubMember businessClubMember, ref string returnMessage)
        {
            return balObj.InsertBusinessClubMember(businessClubMember, ref  returnMessage);
        }
        public BusinessClub GetBusinessClubWithMemberList(int businessClubId, ref string returnMessage)
        {
            return balObj.GetBusinessClubWithMemberList(businessClubId, ref  returnMessage);
        }
        public bool InsertBusiensNews(BusienssClubNewsInfo businessClubNewsInfo, ref string returnMessage)
        {
            return balObj.InsertBusiensNews(businessClubNewsInfo, ref  returnMessage);
        }
        public List<BusienssClubNewsInfo> GetBusienssClubNewsInfo(int businessClubId)
        {
            return balObj.GetBusienssClubNewsInfo(businessClubId);
        }
        public bool DeleteBusienssClubNewsInfo(int busienssClubNewsInfoId)
        {
            return balObj.DeleteBusienssClubNewsInfo(busienssClubNewsInfoId);
        }
        public List<BusinessClub> GetBusinessClubByUserId(int userId)
        {
            return balObj.GetBusinessClubByUserId(userId);
        }
        public List<BusienssClubNewsInfo> GetBusinessClubNewsInfo()
        {
            return balObj.GetBusinessClubNewsInfo();
        }
        public List<User> GetUserListSearch(EnumGender? enumGender, int? maximumAge, ref string returnMessage)
        {
            return balObj.GetUserListSearch(enumGender, maximumAge, ref returnMessage);
        }
        public List<BusinessActivityMessageType> GetBusinessActivityMessageTypes()
        {
            return balObj.GetBusinessActivityMessageTypes();
        }
        public bool SaveBusinessActivity(BusinessClubActivity businessClubActivity, ref string returnMessage)
        {
            return balObj.SaveBusinessActivity(businessClubActivity, ref returnMessage);
        }
        public List<BusinessClubActivity> GetBusinessEventWithMessages(int? businessClubId, int userId)
        {
            return balObj.GetBusinessEventWithMessages(businessClubId, userId);
        }
        public void SaveBusinessClubActivityComments(BusinessClubActivityComment businessClubActivityComment)
        {
            balObj.SaveBusinessClubActivityComments(businessClubActivityComment);
        }
        public List<User> getUserList(bool isActive, int businessClubId, ref string ErrorMessage)
        {
            return balObj.getUserList(isActive, businessClubId, ref   ErrorMessage);
        }
        public bool InsertBusinessClubJoinRequest(BusinessClubJoinRequest businessClubJoinRequest, ref string returnMessage)
        {
            return balObj.InsertBusinessClubJoinRequest(businessClubJoinRequest, ref  returnMessage);
        }

        public List<BusinessClubActivityDetail> GetBusinessEventDetail(int? businessClubId, int userId)
        {
            return balObj.GetBusinessEventDetail(businessClubId, userId);
        }

        public List<UserInbox> GetJobNews(int userid)
        {
            return balObj.GetJobNews(userid);
        }
        public List<User> GetListOfUser()
        {
            return balObj.GetListOfUser();
        }

        public bool SaveUserMessage(UserMessageDetail obj, ref string returnMessage)
        {
            return balObj.SaveUserMessage(obj, ref returnMessage);
        }
        public List<UserMessageDetail> GetUserMessage(int userid)
        {
            return balObj.GetUserMessage(userid);
        }


        public User GetuserByEmailAddressFirstNameLastName(string fname, string lname, string email)
        {
            return balObj.GetuserByEmailAddressFirstNameLastName(fname,  lname,  email);
        }
        public List<QualificationCategory> GetAllQualificationCategoriesList()
        {
            return balObj.GetAllQualificationCategoriesList();
        }
        public Vacancy GetVacancyDetailByVacancyId(int vacancyId)
        {
            return balObj.GetVacancyDetailByVacancyId(vacancyId);
        }
    }
}
