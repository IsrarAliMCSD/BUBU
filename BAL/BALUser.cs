using DALDelegate;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALUser
    {
        // public EFUser efUser;
        public DelegateCls delegatecls;
        public BALUser()
        {
            delegatecls = new DelegateCls();
        }
        public User UserLogin(string userName, string password, ref string ErrorMessage)
        {
            return delegatecls.GetUserByUserNamePassword(userName, password, ref ErrorMessage);
        }
        public User GetUserByUserName(string userName, ref string ErrorMessage)
        {
            return delegatecls.GetUserByUserName(userName, ref ErrorMessage);
        }
        public User InsertUser(User userObj, ref string ErrorMessage)
        {
            return delegatecls.InsertUser(userObj, ref ErrorMessage);
        }
        public List<AccountType> getAllAccountType(bool allRecord)
        {
            return delegatecls.getAllAccountType(allRecord);
        }
        public bool GetAccountActivation(string guid, ref string ErrorMessage)
        {
            return delegatecls.GetAccountActivation(guid, ref  ErrorMessage);
        }
        public User getUserByUserId(int userId, ref string returnMessage)
        {
            return delegatecls.getUserByUserId(userId, ref returnMessage);
        }
        public User GetallWorkExperience(int userid, ref string returnMessage)
        {
            return delegatecls.GetallWorkExperience(userid, ref  returnMessage);
        }

        public List<DocumentFormatAllow> getAllDocumentFormatAllowByDocumentType(int documentCategoryId)
        {
            return delegatecls.getAllDocumentFormatAllowByDocumentType(documentCategoryId);

        }

        public bool updateProfilePic(int userid, byte[] contentData, string contentType, string format, ref string returnMessage)
        {
            return delegatecls.updateProfilePic(userid, contentData, contentType, format, ref  returnMessage);
        }
        public List<DocumentUpload> getAllDocumentsByUserId(int userid, ref string returnMessage)
        {
            return delegatecls.getAllDocumentsByUserId(userid, ref  returnMessage);
        }
        public List<DocumentCategory> getAllDocumentCategories()
        {
            return delegatecls.getAllDocumentCategories();
        }
        public bool SaveDocumentUpload(DocumentUpload documentUploadObject, ref string returnMessage)
        {
            return delegatecls.SaveDocumentUpload(documentUploadObject, ref  returnMessage);
        }
        public bool DeleteDocumentUpload(int documentUploadId, ref string returnMessage)
        {
            return delegatecls.DeleteDocumentUpload(documentUploadId, ref  returnMessage);
        }
        public DocumentUpload GetdocumentByUploadDocumentId(int UploadDocumentId, ref string returnMessage)
        {
            return delegatecls.GetdocumentByUploadDocumentId(UploadDocumentId, ref  returnMessage);
        }
        public List<DocumentUpload> GetAllDocumentByUserIdAndDocumentType(int documentTypeId, int userid)
        {
            return delegatecls.GetAllDocumentByUserIdAndDocumentType(documentTypeId, userid);
        }
        public bool UpdateUserAndworkCurrentExperienceByUserId(User user, ref string ErrorMessage)
        {
            return delegatecls.UpdateUserAndworkCurrentExperienceByUserId(user, ref ErrorMessage);
        }
        public List<Country> GetCountries(ref string returnMessage)
        {
            return delegatecls.GetCountries(ref returnMessage);
        }
        public List<UserQualification> GetQualificationByUserId(int userid, ref string returnMessage)
        {
            return delegatecls.GetQualificationByUserId(userid, ref returnMessage);
        }
        public List<Qualification> GetQualificationList(ref string returnMessage)
        {
            return delegatecls.GetQualificationList(ref returnMessage).ToList();
        }
       
        public bool SaveUserQualification(UserQualification userqualification, ref string returnMessage)
        {
            return delegatecls.SaveUserQualification(userqualification, ref returnMessage);
        }
        public bool DeleteUserQualification(int userQualificationId, ref string returnMessage)
        {
            return delegatecls.DeleteUserQualification(userQualificationId, ref returnMessage);
        }
        public UserQualification GetUserQualificationById(int userqualificationId, ref string returnMessage)
        {
            return delegatecls.GetUserQualificationById(userqualificationId, ref  returnMessage);
        }
        public bool IsProfileCompleted(int userid, ref string returnMessage)
        {
            return true;
        }
        public List<UserWorkExperience> GetUserWorkExperienceCurrentJob(int userid, ref string returnMessage)
        {
            return delegatecls.GetUserWorkExperienceCurrentJob(userid, ref  returnMessage);
        }
        public bool SaveUserWorkExperience(UserWorkExperience userWorkexperience, ref string returnMessage)
        {
            return delegatecls.SaveUserWorkExperience(userWorkexperience, ref  returnMessage);
        }
        public List<UserWorkExperience> GetUserExperienceByUserId(int userid, ref string returnMessage)
        {
            return delegatecls.GetUserExperienceByUserId(userid, ref  returnMessage);
        }
        public bool DeleteUserExperienceByUserExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return delegatecls.DeleteUserExperienceByUserExperienceId(userWorkExperienceId, ref  returnMessage);
        }
        public UserWorkExperience GetUserExperienceByUserWorkExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return delegatecls.GetUserExperienceByUserWorkExperienceId(userWorkExperienceId, ref  returnMessage);
        }
        public List<Language> GetLanguageList()
        {
            return delegatecls.GetLanguageList();
        }

        public List<Level> GetLevelList()
        {
            return delegatecls.GetLevelList();
        }
        public List<UserLanguage> GetUserLanguageByUserId(int userid, ref string returnMessage)
        {
            return delegatecls.GetUserLanguageByUserId(userid, ref  returnMessage);
        }
        public bool DeleteUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            return delegatecls.DeleteUserLanguageByUserLanguageId(userLanguageid, ref  returnMessage);
        }
        public UserLanguage GetUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            return delegatecls.GetUserLanguageByUserLanguageId(userLanguageid, ref  returnMessage);
        }
        public bool SaveUserLanguage(UserLanguage userLanguage, ref string returnMessage)
        {
            return delegatecls.SaveUserLanguage(userLanguage, ref  returnMessage);
        }
        public List<Commencement> GetCommencements()
        {
            return delegatecls.GetCommencements();
        }
        public bool UpdateCommencement(int commencementId, int userid, ref string returnMessage)
        {
            return delegatecls.UpdateCommencement(commencementId, userid, ref returnMessage);
        }
        public List<Reference> GetReferences()
        {
            return delegatecls.GetReferences().ToList();
        }
        public List<UserReference> GetUserReferenceByUserId(int userId, ref string returnMessage)
        {
            return delegatecls.GetUserReferenceByUserId(userId, ref returnMessage).ToList();
        }
        public bool DeleteUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return delegatecls.DeleteUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public UserReference GetUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return delegatecls.GetUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public bool SaveUserReference(UserReference userReference, ref string returnMessage)
        {
            return delegatecls.SaveUserReference(userReference, ref  returnMessage);
        }
        public List<Hobby> GetHobbies()
        {
            return delegatecls.GetHobbies();
        }
        public List<UserHobby> GetUserHobbiesByUserId(int userId, ref string returnMessage)
        {
            return delegatecls.GetUserHobbiesByUserId(userId, ref returnMessage).ToList();
        }
        public UserHobby GetUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return delegatecls.GetUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }

        public bool DeleteUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return delegatecls.DeleteUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }
        public bool SaveUserHobby(UserHobby userHobby, ref string returnMessage)
        {
            return delegatecls.SaveUserHobby(userHobby, ref returnMessage);
        }
        public List<Skill> GetSkills()
        {
            return delegatecls.GetSkills();
        }
        public List<UserSkill> GetUserSkillsByUserId(int userId, ref string returnMessage)
        {
            return delegatecls.GetUserSkillsByUserId(userId, ref returnMessage).ToList();
        }
        public UserSkill GetUserSkillByUserSkillyId(int userSkillId, ref string returnMessage)
        {
            return delegatecls.GetUserSkillByUserSkillyId(userSkillId, ref returnMessage);
        }
        public bool DeleteUserSkillByUserSkillId(int userSkillId, ref string returnMessage)
        {
            return delegatecls.DeleteUserSkillByUserSkillId(userSkillId, ref returnMessage);
        }
        public bool SaveUserSkill(UserSkill userSkill, ref string returnMessage)
        {
            return delegatecls.SaveUserSkill(userSkill, ref returnMessage);
        }
        public CompanyInformation GetCompanyInformationByUserId(int userId)
        {
            return delegatecls.GetCompanyInformationByUserId(userId);
        }
        public bool SaveCompanyInformation(CompanyInformation companyInformation, ref string returnMessage)
        {
            return delegatecls.SaveCompanyInformation(companyInformation, ref returnMessage);
        }
        public List<CompanyAbout> GetCompanyAboutUsList(int userId)
        {
            return delegatecls.GetCompanyAboutUsList(userId);
        }
        public bool DeleteCompanyAboutUsByCompanyAboutUsId(int companyAboutUsId)
        {
            return delegatecls.DeleteCompanyAboutUsByCompanyAboutUsId(companyAboutUsId);
        }
        public CompanyAbout GetCompanyAboutUsByCompanyAboutId(int companyAboutUsId)
        {
            return delegatecls.GetCompanyAboutUsByCompanyAboutId(companyAboutUsId);
        }
        public bool SaveCompanyAbout(CompanyAbout companyAbout, ref string returnMessage)
        {
            return delegatecls.SaveCompanyAbout(companyAbout, ref  returnMessage);
        }
        public List<Vacancy> GetVacancyListByUserId(int userId, bool isPrivateInclude, ref string returnMessage)
        {
            return delegatecls.GetVacancyListByUserId(userId, isPrivateInclude, ref returnMessage);
        }
        public List<JobType> GetJobType()
        {
            return delegatecls.GetJobType();
        }
        public bool SaveVacancy(Vacancy vacancy, ref string returnMessage)
        {
            return delegatecls.SaveVacancy(vacancy, ref   returnMessage);
        }
        public bool DeleteVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return delegatecls.DeleteVacancyByVacancyId(vacancyId, ref   returnMessage);
        }
        public Vacancy GetVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return delegatecls.GetVacancyByVacancyId(vacancyId, ref   returnMessage);
        }
        public List<WorkExperience> GetWorkExperience()
        {
            return delegatecls.GetWorkExperience();
        }
        public List<Domicile> GetDomiciles()
        {
            return delegatecls.GetDomiciles();
        }
        public List<Vacancy> JobSearch(int? companyId, JobPrivacy jobprivacy, string sectorName, string function,
          string region, string jobType, string searchText, ref string returnMessage)
        {
            return delegatecls.JobSearch(companyId, jobprivacy, sectorName, function, region, jobType, searchText, ref returnMessage);
        }
        public List<Region> GetRegionList()
        {
            return delegatecls.GetRegionList();
        }
        public List<string> GetDistinctJobFunctionsList()
        {
            return delegatecls.GetDistinctJobFunctionsList();
        }
        public List<string> GetDistinctSector()
        {
            return delegatecls.GetDistinctSector();
        }
        public CompanyInformation GetCompanyInformationByCompanyId(int userId)
        {
            return delegatecls.GetCompanyInformationByCompanyId(userId);
        }
        public bool InsertVacancyApply(VacancyApply vacancyApply, ref string returnMessage)
        {
            return delegatecls.InsertVacancyApply(vacancyApply, ref returnMessage);
        }
        public List<VacancyApply> GetApplicantListByVacancyId(int vacancyId, ref string returnMessage)
        {
            return delegatecls.GetApplicantListByVacancyId(vacancyId, ref returnMessage);
        }
        public bool InsertUserInbox(UserInbox userInbox, ref string returnMessage)
        {
            return delegatecls.InsertUserInbox(userInbox, ref returnMessage);
        }
        public void UpdateVacancyApplyIsCancelEmployeer(int vacancyApplyId, int SenderId, bool IsCancelByEmployee)
        {
            delegatecls.UpdateVacancyApplyIsCancelEmployeer(vacancyApplyId, SenderId, IsCancelByEmployee);
        }
        public List<Vacancy> GetVacancyListSearch(int userId, bool isPrivateInclude, string textSearch, ref string returnMessage)
        {
            return delegatecls.GetVacancyListSearch(userId, isPrivateInclude, textSearch, ref   returnMessage);
        }
        public bool SaveBusinessClub(BusinessClub businessClub, ref string returnMessage)
        {
            return delegatecls.SaveBusinessClub(businessClub, ref  returnMessage);
        }
        public List<BusinessClub> GetBusinessClubs(ref string returnMessage)
        {
            return delegatecls.GetBusinessClubs(ref  returnMessage);
        }
        public List<BusinessClub> GetBusinessClubs(int userId, ref string returnMessage)
        {
            return delegatecls.GetBusinessClubs(userId, ref  returnMessage);
        }
        public BusinessClub GetBusinessClub(int businessClubId, ref string returnMessage)
        {
            return delegatecls.GetBusinessClub(businessClubId, ref  returnMessage);
        }
        public bool InsertBusinessClubMember(BusinessClubMember businessClubMember, ref string returnMessage)
        {
            return delegatecls.InsertBusinessClubMember(businessClubMember, ref  returnMessage);
        }
        public BusinessClub GetBusinessClubWithMemberList(int businessClubId, ref string returnMessage)
        {
            return delegatecls.GetBusinessClubWithMemberList(businessClubId, ref  returnMessage);
        }
        public bool InsertBusiensNews(BusienssClubNewsInfo businessClubNewsInfo, ref string returnMessage)
        {
            return delegatecls.InsertBusiensNews(businessClubNewsInfo, ref  returnMessage);
        }
        public List<BusienssClubNewsInfo> GetBusienssClubNewsInfo(int businessClubId)
        {
            return delegatecls.GetBusienssClubNewsInfo(businessClubId);
        }
        public bool DeleteBusienssClubNewsInfo(int busienssClubNewsInfoId)
        {
            return delegatecls.DeleteBusienssClubNewsInfo(busienssClubNewsInfoId);
        }
        public List<BusinessClub> GetBusinessClubByUserId(int userId)
        {
            return delegatecls.GetBusinessClubByUserId(userId);
        }
        public List<BusienssClubNewsInfo> GetBusinessClubNewsInfo()
        {
            return delegatecls.GetBusinessClubNewsInfo();
        }
        public List<User> GetUserListSearch(EnumGender? enumGender, int? maximumAge, ref string returnMessage)
        {
            return delegatecls.GetUserListSearch(enumGender,maximumAge, ref returnMessage);
        }
        public List<BusinessActivityMessageType> GetBusinessActivityMessageTypes()
        {
            return delegatecls.GetBusinessActivityMessageTypes();
        }
        public bool SaveBusinessActivity(BusinessClubActivity businessClubActivity, ref string returnMessage)
        {
            return delegatecls.SaveBusinessActivity(businessClubActivity, ref returnMessage);
        }
        public List<BusinessClubActivity> GetBusinessEventWithMessages(int? businessClubId, int userId)
        {
            return delegatecls.GetBusinessEventWithMessages(businessClubId, userId);
        }
        public void SaveBusinessClubActivityComments(BusinessClubActivityComment businessClubActivityComment)
        {
            delegatecls.SaveBusinessClubActivityComments(businessClubActivityComment);
        }
        public List<User> getUserList(bool isActive, int businessClubId, ref string ErrorMessage)
        {
            return delegatecls.getUserList(isActive, businessClubId, ref   ErrorMessage);
        }
        public bool InsertBusinessClubJoinRequest(BusinessClubJoinRequest businessClubJoinRequest, ref string returnMessage)
        {
            return delegatecls.InsertBusinessClubJoinRequest(businessClubJoinRequest, ref  returnMessage);
        }
        public List<BusinessClubActivityDetail> GetBusinessEventDetail(int? businessClubId, int userId)
        {
            return delegatecls.GetBusinessEventDetail(businessClubId, userId);
        }

        public List<UserInbox> GetJobNews(int userid)
        {
            return delegatecls.GetJobNews(userid);
        }
        public List<User> GetListOfUser()
        {
            return delegatecls.GetListOfUser();
        }
        public bool SaveUserMessage(UserMessageDetail obj, ref string returnMessage)
        {
            return delegatecls.SaveUserMessage(obj, ref returnMessage);
        }

        public List<UserMessageDetail> GetUserMessage(int userid)
        {
            return delegatecls.GetUserMessage(userid);
        }

        public User GetuserByEmailAddressFirstNameLastName(string fname, string lname, string email)
        {
            return delegatecls.GetuserByEmailAddressFirstNameLastName(fname, lname, email);
        }
        public List<QualificationCategory> GetAllQualificationCategoriesList()
        {
            return delegatecls.GetAllQualificationCategoriesList();
        }
        public Vacancy GetVacancyDetailByVacancyId(int vacancyId)
        {
            return delegatecls.GetVacancyDetailByVacancyId(vacancyId);
        }
    }

}
