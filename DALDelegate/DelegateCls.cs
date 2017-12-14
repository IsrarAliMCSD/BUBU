using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAOClassLib.EF;
using DAO.EFOperation;
using DAOClassLib;


namespace DALDelegate
{
    public class DelegateCls
    {
        public EFUser efUser;
        public EFWorkExperience efWorkExperience;
        public EFDocumentUpload efDocumentUpload;
        public EFLanguage efLanguage;
        public EFCompanyInformation efCompanyInformation;

        public DelegateCls()
        {
            efUser = new EFUser();
            efWorkExperience = new EFWorkExperience();
            efDocumentUpload = new EFDocumentUpload();
            efLanguage = new EFLanguage();
        }
        public User GetUserByUserNamePassword(string userName, string password, ref string ErrorMessage)
        {
            return efUser.GetUserByUserNamePassword(userName, password, ref ErrorMessage);
        }
        public User GetUserByUserName(string userName, ref string ErrorMessage)
        {
            return efUser.GetUserByUserName(userName, ref ErrorMessage);
        }
        public User InsertUser(User userObj, ref string ErrorMessage)
        {
            return efUser.InsertUser(userObj, ref ErrorMessage);
        }

        public List<AccountType> getAllAccountType(bool allRecord)
        {
            return efUser.getAllAccountType(allRecord);
        }
        public bool GetAccountActivation(string guid, ref string ErrorMessage)
        {
            return efUser.GetAccountActivation(guid, ref  ErrorMessage);
        }
        public User getUserByUserId(int userId, ref string returnMessage)
        {
            return efUser.getUserByUserId(userId, ref returnMessage);
        }
        public User GetallWorkExperience(int userid, ref string returnMessage)
        {
            return efWorkExperience.GetallWorkExperience(userid, ref  returnMessage);
        }
        public List<DocumentFormatAllow> getAllDocumentFormatAllowByDocumentType(int documentCategoryId)
        {
            return efDocumentUpload.getAllDocumentFormatAllowByDocumentType(documentCategoryId);

        }
        public bool updateProfilePic(int userid, byte[] contentData, string contentType, string format, ref string returnMessage)
        {
            return efUser.updateProfilePic(userid, contentData, contentType, format, ref  returnMessage);
        }
        public List<DocumentUpload> getAllDocumentsByUserId(int userid, ref string returnMessage)
        {
            return efDocumentUpload.getAllDocumentsByUserId(userid, ref  returnMessage);
        }
        public List<DocumentCategory> getAllDocumentCategories()
        {
            return efDocumentUpload.getAllDocumentCategories();
        }
        public bool SaveDocumentUpload(DocumentUpload documentUploadObject, ref string returnMessage)
        {
            return efDocumentUpload.SaveDocumentUpload(documentUploadObject, ref  returnMessage);
        }
        public bool DeleteDocumentUpload(int documentUploadId, ref string returnMessage)
        {
            return efDocumentUpload.DeleteDocumentUpload(documentUploadId, ref  returnMessage);
        }
        public DocumentUpload GetdocumentByUploadDocumentId(int UploadDocumentId, ref string returnMessage)
        {
            return efDocumentUpload.GetdocumentByUploadDocumentId(UploadDocumentId, ref  returnMessage);
        }
        public List<DocumentUpload> GetAllDocumentByUserIdAndDocumentType(int documentTypeId, int userid)
        {
            return efDocumentUpload.GetAllDocumentByUserIdAndDocumentType(documentTypeId, userid);
        }
        public bool UpdateUserAndworkCurrentExperienceByUserId(User user, ref string ErrorMessage)
        {
            return efUser.UpdateUserAndworkCurrentExperienceByUserId(user, ref ErrorMessage);
        }
        public List<Country> GetCountries(ref string returnMessage)
        {
            return efUser.GetCountries(ref returnMessage);
        }
        public List<UserQualification> GetQualificationByUserId(int userid, ref string returnMessage)
        {
            return efUser.GetQualificationByUserId(userid, ref returnMessage);
        }
        public List<Qualification> GetQualificationList(ref string returnMessage)
        {
            return efUser.GetQualificationList(ref returnMessage);
        }
    
        public bool SaveUserQualification(UserQualification userqualification, ref string returnMessage)
        {
            return efUser.SaveUserQualification(userqualification, ref returnMessage);
        }

        public bool DeleteUserQualification(int userQualificationId, ref string returnMessage)
        {
            return efUser.DeleteUserQualification(userQualificationId, ref returnMessage);
        }
        public UserQualification GetUserQualificationById(int userqualificationId, ref string returnMessage)
        {
            return efUser.GetUserQualificationById(userqualificationId, ref  returnMessage);
        }
        public List<UserWorkExperience> GetUserWorkExperienceCurrentJob(int userid, ref string returnMessage)
        {
            return efWorkExperience.GetUserWorkExperienceCurrentJob(userid, ref  returnMessage);
        }
        public bool SaveUserWorkExperience(UserWorkExperience userWorkexperience, ref string returnMessage)
        {
            return efWorkExperience.SaveUserWorkExperience(userWorkexperience, ref  returnMessage);
        }
        public List<UserWorkExperience> GetUserExperienceByUserId(int userid, ref string returnMessage)
        {
            return efWorkExperience.GetUserExperienceByUserId(userid, ref  returnMessage);
        }

        public bool DeleteUserExperienceByUserExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return efWorkExperience.DeleteUserExperienceByUserExperienceId(userWorkExperienceId, ref  returnMessage);
        }
        public UserWorkExperience GetUserExperienceByUserWorkExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return efWorkExperience.GetUserExperienceByUserWorkExperienceId(userWorkExperienceId, ref  returnMessage);
        }
        public List<Language> GetLanguageList()
        {
            return efLanguage.GetLanguageList();
        }
        public List<Level> GetLevelList()
        {
            return efLanguage.GetLevelList();
        }
        public List<UserLanguage> GetUserLanguageByUserId(int userid, ref string returnMessage)
        {
            return efLanguage.GetUserLanguageByUserId(userid, ref  returnMessage);
        }
        public bool DeleteUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            return efLanguage.DeleteUserLanguageByUserLanguageId(userLanguageid, ref  returnMessage);
        }
        public UserLanguage GetUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            return efLanguage.GetUserLanguageByUserLanguageId(userLanguageid, ref  returnMessage);
        }
        public bool SaveUserLanguage(UserLanguage userLanguage, ref string returnMessage)
        {
            return efLanguage.SaveUserLanguage(userLanguage, ref  returnMessage);
        }
        public List<Commencement> GetCommencements()
        {
            return new EFCommencement().GetCommencements();
        }
        public bool UpdateCommencement(int commencementId, int userid, ref string returnMessage)
        {
            return new EFCommencement().UpdateCommencement(commencementId, userid, ref returnMessage);
        }
        public List<Reference> GetReferences()
        {
            return new EFReference().GetReferences().ToList();
        }
        public List<UserReference> GetUserReferenceByUserId(int userId, ref string returnMessage)
        {
            return new EFReference().GetUserReferenceByUserId(userId, ref returnMessage).ToList();
        }
        public bool DeleteUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return new EFReference().DeleteUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public UserReference GetUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return new EFReference().GetUserReferenceByUserReferenceId(userReferenceId, ref returnMessage);
        }
        public bool SaveUserReference(UserReference userReference, ref string returnMessage)
        {
            return new EFReference().SaveUserReference(userReference, ref   returnMessage);
        }
        public List<Hobby> GetHobbies()
        {
            return new EFHobby().GetHobbies();
        }
        public List<UserHobby> GetUserHobbiesByUserId(int userId, ref string returnMessage)
        {
            return new EFHobby().GetUserHobbiesByUserId(userId, ref returnMessage).ToList();
        }
        public UserHobby GetUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return new EFHobby().GetUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }

        public bool DeleteUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return new EFHobby().DeleteUserHobbyByUserHobbyId(userHobbyId, ref returnMessage);
        }

        public bool SaveUserHobby(UserHobby userHobby, ref string returnMessage)
        {
            return new EFHobby().SaveUserHobby(userHobby, ref returnMessage);
        }
        public List<Skill> GetSkills()
        {
            return new EFSkill().GetSkills();
        }
        public List<UserSkill> GetUserSkillsByUserId(int userId, ref string returnMessage)
        {
            return new EFSkill().GetUserSkillsByUserId(userId, ref returnMessage).ToList();
        }
        public UserSkill GetUserSkillByUserSkillyId(int userSkillId, ref string returnMessage)
        {
            return new EFSkill().GetUserSkillByUserSkillyId(userSkillId, ref returnMessage);
        }

        public bool DeleteUserSkillByUserSkillId(int userSkillId, ref string returnMessage)
        {
            return new EFSkill().DeleteUserSkillByUserSkillId(userSkillId, ref returnMessage);
        }
        public bool SaveUserSkill(UserSkill userSkill, ref string returnMessage)
        {
            return new EFSkill().SaveUserSkill(userSkill, ref returnMessage);
        }

        public CompanyInformation GetCompanyInformationByUserId(int userId)
        {
            return new EFCompanyInformation().GetCompanyInformationByUserId(userId);
        }
        public bool SaveCompanyInformation(CompanyInformation companyInformation, ref string returnMessage)
        {
            return new EFCompanyInformation().SaveCompanyInformation(companyInformation, ref returnMessage);
        }
        public List<CompanyAbout> GetCompanyAboutUsList(int userId)
        {
            return new EFCompanyInformation().GetCompanyAboutUsList(userId);
        }
        public bool DeleteCompanyAboutUsByCompanyAboutUsId(int companyAboutUsId)
        {
            return new EFCompanyInformation().DeleteCompanyAboutUsByCompanyAboutUsId(companyAboutUsId);
        }

        public CompanyAbout GetCompanyAboutUsByCompanyAboutId(int companyAboutUsId)
        {
            return new EFCompanyInformation().GetCompanyAboutUsByCompanyAboutId(companyAboutUsId);
        }
        public bool SaveCompanyAbout(CompanyAbout companyAbout, ref string returnMessage)
        {
            return new EFCompanyInformation().SaveCompanyAbout(companyAbout, ref  returnMessage);
        }
        public List<Vacancy> GetVacancyListByUserId(int userId, bool isPrivateInclude, ref string returnMessage)
        {
            return new EFVacancy().GetVacancyListByUserId(userId, isPrivateInclude, ref returnMessage);
        }
        public List<JobType> GetJobType()
        {
            return new EFVacancy().GetJobType();
        }
        public bool SaveVacancy(Vacancy vacancy, ref string returnMessage)
        {
            return new EFVacancy().SaveVacancy(vacancy, ref   returnMessage);
        }
        public bool DeleteVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return new EFVacancy().DeleteVacancyByVacancyId(vacancyId, ref   returnMessage);
        }
        public Vacancy GetVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return new EFVacancy().GetVacancyByVacancyId(vacancyId, ref   returnMessage);
        }
        public List<WorkExperience> GetWorkExperience()
        {
            return new EFWorkExperience().GetWorkExperience();
        }

        public List<Domicile> GetDomiciles()
        {
            return new EFDomicile().GetDomiciles();
        }
        public List<Vacancy> JobSearch(int? companyId, JobPrivacy jobprivacy, string sectorName, string function,
            string region, string jobType, string searchText, ref string returnMessage)
        {
            return new EFJobSearch().JobSearch(companyId, jobprivacy, sectorName, function, region, jobType, searchText, ref returnMessage);
        }
        public List<Region> GetRegionList()
        {
            return new EFJobSearch().GetRegionList();
        }
        public List<string> GetDistinctJobFunctionsList()
        {
            return new EFJobSearch().GetDistinctJobFunctionsList();
        }
        public List<string> GetDistinctSector()
        {
            return new EFJobSearch().GetDistinctSector();
        }
        public CompanyInformation GetCompanyInformationByCompanyId(int userId)
        {
            return new EFCompanyInformation().GetCompanyInformationByCompanyId(userId);
        }
        public bool InsertVacancyApply(VacancyApply vacancyApply, ref string returnMessage)
        {
            return new EFJobSearch().InsertVacancyApply(vacancyApply, ref returnMessage);
        }
        public List<VacancyApply> GetApplicantListByVacancyId(int vacancyId, ref string returnMessage)
        {
            return new EFJobSearch().GetApplicantListByVacancyId(vacancyId, ref returnMessage);
        }
        public bool InsertUserInbox(UserInbox userInbox, ref string returnMessage)
        {
            return new EFJobSearch().InsertUserInbox(userInbox, ref returnMessage);
        }
        public void UpdateVacancyApplyIsCancelEmployeer(int vacancyApplyId, int SenderId, bool IsCancelByEmployee)
        {
            new EFJobSearch().UpdateVacancyApplyIsCancelEmployeer(vacancyApplyId, SenderId, IsCancelByEmployee);
        }
        public List<Vacancy> GetVacancyListSearch(int userId, bool isPrivateInclude, string textSearch, ref string returnMessage)
        {
            return new EFVacancy().GetVacancyListSearch(userId, isPrivateInclude, textSearch, ref returnMessage);
        }
        public bool SaveBusinessClub(BusinessClub businessClub, ref string returnMessage)
        {
            return new EFBusinessClub().SaveBusinessClub(businessClub, ref  returnMessage);
        }
        public List<BusinessClub> GetBusinessClubs(ref string returnMessage)
        {
            return new EFBusinessClub().GetBusinessClubs(ref  returnMessage);
        }
        public List<BusinessClub> GetBusinessClubs(int userId, ref string returnMessage)
        {
            return new EFBusinessClub().GetBusinessClubs(userId, ref  returnMessage);
        }
        public BusinessClub GetBusinessClub(int businessClubId, ref string returnMessage)
        {
            return new EFBusinessClub().GetBusinessClub(businessClubId, ref  returnMessage);
        }

        public bool InsertBusinessClubMember(BusinessClubMember businessClubMember, ref string returnMessage)
        {
            return new EFBusinessClub().InsertBusinessClubMember(businessClubMember, ref  returnMessage);
        }
        public BusinessClub GetBusinessClubWithMemberList(int businessClubId, ref string returnMessage)
        {
            return new EFBusinessClub().GetBusinessClubWithMemberList(businessClubId, ref  returnMessage);
        }
        public bool InsertBusiensNews(BusienssClubNewsInfo businessClubNewsInfo, ref string returnMessage)
        {
            return new EFBusinessClub().InsertBusiensNews(businessClubNewsInfo, ref  returnMessage);
        }
        public List<BusienssClubNewsInfo> GetBusienssClubNewsInfo(int businessClubId)
        {
            return new EFBusinessClub().GetBusienssClubNewsInfo(businessClubId);
        }
        public bool DeleteBusienssClubNewsInfo(int busienssClubNewsInfoId)
        {
            return new EFBusinessClub().DeleteBusienssClubNewsInfo(busienssClubNewsInfoId);
        }
        public List<BusinessClub> GetBusinessClubByUserId(int userId)
        {
            return new EFBusinessClub().GetBusinessClubByUserId(userId);
        }

        public List<BusienssClubNewsInfo> GetBusinessClubNewsInfo()
        {
            return new EFBusinessClub().GetBusinessClubNewsInfo();
        }
        public List<User> GetUserListSearch(EnumGender? enumGender, int? maximumAge, ref string returnMessage)
        {
            return new EFJobSearch().GetUserListSearch(enumGender, maximumAge, ref returnMessage);
        }
        public List<BusinessActivityMessageType> GetBusinessActivityMessageTypes()
        {
            return new EFBusinessActivityMessageType().GetBusinessActivityMessageTypes();
        }
        public bool SaveBusinessActivity(BusinessClubActivity businessClubActivity, ref string returnMessage)
        {
            return new EFBusinessActivityMessageType().SaveBusinessActivity(businessClubActivity, ref returnMessage);
        }
        public List<BusinessClubActivity> GetBusinessEventWithMessages(int? businessClubId, int userId)
        {
            return new EFBusinessActivityMessageType().GetBusinessEventWithMessages(businessClubId, userId);
        }
        public void SaveBusinessClubActivityComments(BusinessClubActivityComment businessClubActivityComment)
        {
            new EFBusinessActivityMessageType().SaveBusinessClubActivityComments(businessClubActivityComment);
        }
        public List<User> getUserList(bool isActive, int businessClubId, ref string ErrorMessage)
        {
            return efUser.getUserList(isActive, businessClubId, ref   ErrorMessage);
        }
        public bool InsertBusinessClubJoinRequest(BusinessClubJoinRequest businessClubJoinRequest, ref string returnMessage)
        {
            return efUser.InsertBusinessClubJoinRequest(businessClubJoinRequest, ref  returnMessage);
        }

        public List<BusinessClubActivityDetail> GetBusinessEventDetail(int? businessClubId, int userId)
        {
            return new EFBusinessActivityMessageType().GetBusinessEventDetail(businessClubId, userId);
        }


        public List<UserInbox> GetJobNews(int userid)
        {
            return new EFBusinessActivityMessageType().GetJobNews(userid);
        }

        public List<User> GetListOfUser()
        {
            return new EFBusinessActivityMessageType().GetListOfUser();
        }

        public bool SaveUserMessage(UserMessageDetail obj, ref string returnMessage)
        {
            return new EFBusinessActivityMessageType().SaveUserMessage(obj, ref returnMessage);
        }

        public List<UserMessageDetail> GetUserMessage(int userid)
        {
            return new EFBusinessActivityMessageType().GetUserMessage(userid);
        }

        public User GetuserByEmailAddressFirstNameLastName(string fname, string lname, string email)
        {
            return efUser.GetuserByEmailAddressFirstNameLastName(fname, lname, email);
            //return delegatecls.GetuserByEmailAddressFirstNameLastName(fname, lname, email);
        }
        public List<QualificationCategory> GetAllQualificationCategoriesList()
        {
            return efUser.GetAllQualificationCategoriesList();
        }

        public Vacancy GetVacancyDetailByVacancyId(int vacancyId)
        {
            return new EFVacancy().GetVacancyDetailByVacancyId(vacancyId);
        }

    }



}
