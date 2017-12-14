using DAO;
using DAOClassLib;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class EFUser
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFUser()
        {
            bubucontext = new BubuEntities();
        }

        public User GetUserByUserNamePassword(string userName, string password, ref string ErrorMessage)
        {
            using (bubucontext)
            {
                bubucontext.Configuration.LazyLoadingEnabled = false;
                User objUser = bubucontext.Users.Include("AccountType").Where(a => a.UserName == userName && a.UserPassword == password).FirstOrDefault();
                if (objUser != null)
                {
                    //if (objUser.AccountStatus == Convert.ToInt32(AccountStatus.NonActivate))
                    //{
                    //    ErrorMessage = Messages.MessageContent(MessageCode.AccountActivatedFail);
                    //    return null;
                    //}
                    //else
                    //{

                    //}

                }
                else
                {
                    ErrorMessage = Messages.MessageContent(MessageCode.NoRecordFound);
                }
                return objUser;
            }
        }
        /// <summary>
        /// Login Use
        /// </summary>
        /// <param name="userObj"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public User InsertUser(User userObj, ref string returnMessage)
        {
            try
            {

                using (bubucontext)
                {
                    User obj_User = bubucontext.Users.Where(a => a.EmailAddress == userObj.EmailAddress || a.UserName == userObj.UserName).FirstOrDefault();
                    if (obj_User == null)
                    {
                        // bubucontext.Users.Add(userObj);
                        User userNewObj = new User();
                        // bubucontext.Entry(userObj).State = EntityState.Added;
                        userNewObj.UserName = userObj.UserName;
                        userNewObj.FirstName = userObj.FirstName;
                        userNewObj.MiddleName = userObj.MiddleName;
                        userNewObj.LastName = userObj.LastName;
                        userNewObj.DateOfBirth = userObj.DateOfBirth;
                        userNewObj.EmailAddress = userObj.EmailAddress;
                        userNewObj.ContactNumber = userObj.ContactNumber;
                        userNewObj.UserPassword = userObj.UserPassword;
                        userNewObj.AccountTypeId = userObj.AccountTypeId;
                        userNewObj.IsActive = userObj.IsActive;
                        userNewObj.AccountStatus = userObj.AccountStatus;
                        userNewObj.IsMarried = userObj.IsMarried;
                        userNewObj.Gender = userObj.Gender;
                        bubucontext.Users.Add(userNewObj);
                        //==============================
                        if (userObj.UserWorkExperiences != null && userObj.UserWorkExperiences.Count > 0)
                        {
                            userNewObj.UserWorkExperiences.Add(userObj.UserWorkExperiences.ToList()[0]);
                        }
                        if (userObj.UserQualifications != null && userObj.UserQualifications.Count > 0)
                        {
                            userNewObj.UserQualifications.Add(userObj.UserQualifications.ToList()[0]);
                        }
                        bubucontext.SaveChanges();
                        returnMessage = Messages.MessageContent(MessageCode.AccountCreated);
                        //==============================
                        return userNewObj;
                    }
                    else
                    {
                        returnMessage = Messages.MessageContent(MessageCode.AlreadyExistsUser);
                    }

                }
            }
            catch (Exception ex) { }
            return null;
        }

        public bool GetAccountActivation(string guid, ref string ErrorMessage)
        {
            using (bubucontext)
            {
                AccountActivation objAccountActivation = bubucontext.AccountActivations.Where(a => a.ActivationCode == guid).FirstOrDefault();
                if (objAccountActivation != null)
                {
                    if (!Convert.ToBoolean(objAccountActivation.IsCompleted))
                    {

                        objAccountActivation.IsCompleted = true;
                        bubucontext.SaveChanges();
                        activateUser(objAccountActivation.Userid);
                        ErrorMessage = Messages.MessageContent(MessageCode.AccountActivatedSuccess);
                    }
                    else
                    {
                        ErrorMessage = Messages.MessageContent(MessageCode.AccountActivatedExpired);
                    }
                }
                else
                {
                    ErrorMessage = Messages.MessageContent(MessageCode.AccountActivatedFail);

                }

            }
            return true;
        }
        public bool activateUser(int? userid)
        {
            using (bubucontext)
            {
                User user = bubucontext.Users.Where(a => a.Userid == userid).FirstOrDefault();
                if (user != null && user.Userid > 0)
                {
                    user.AccountStatus = 1;
                }
                bubucontext.SaveChanges();
                result = true;
            }
            return result;
        }

        public User GetUserByUserName(string userName, ref string ErrorMessage)
        {
            using (bubucontext)
            {
                return bubucontext.Users.Where(a => a.UserName == userName).FirstOrDefault();
            }
        }
        //public void testUser()
        //{
        //    User objUser = null;
        //    EF.User objUser2 = null;
        //    EF.BubuEntities be = new EF.BubuEntities();

        //    objUser = be.Users.Where(a => a.Userid == 1).FirstOrDefault();

        //    if (objUser != null)
        //    {
        //        objUser.FirstName = "ali1";
        //        // be.SaveChanges();

        //    }


        //    EF.BubuEntities be2 = new EF.BubuEntities();
        //    objUser2 = be2.Users.Where(a => a.Userid == 1).FirstOrDefault();
        //    be.SaveChanges();
        //    // be2.Entry(objUser).State = EntityState.Modified;
        //    try
        //    {
        //        objUser2.FirstName = "ali2";
        //        be2.SaveChanges();

        //    }
        //    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
        //    {
        //        //Console.WriteLine("User2: Optimistic Concurrency exception occurred");
        //    }


        //}

        public AccountActivation FillAccountDetail(int userId, bool isCompleted)
        {
            AccountActivation accAct = new AccountActivation();
            accAct.ActivationCode = Guid.NewGuid().ToString();
            accAct.Userid = userId;
            accAct.IsCompleted = isCompleted;
            return accAct;
        }

        public User getUserByUserId(int userId, ref string returnMessage)
        {
            return bubucontext.Users.Where(a => a.Userid == userId).FirstOrDefault();
        }


        public bool updateProfilePic(int userid, byte[] contentData, string contentType, string format, ref string returnMessage)
        {
            using (bubucontext)
            {
                User obj_User = bubucontext.Users.Where(a => a.Userid == userid).FirstOrDefault();
                if (obj_User != null)
                {
                    obj_User.ContentData = contentData;
                    obj_User.ContentType = contentType;
                    obj_User.format = format;
                    bubucontext.SaveChanges();
                    return true;
                }
                else
                {
                    returnMessage = Messages.MessageContent(MessageCode.UserNotfound);
                    return false;
                }

            }
        }

        #region AccountType
        public List<AccountType> getAllAccountType(bool allRecord)
        {
            using (bubucontext)
            {
                bubucontext.Configuration.LazyLoadingEnabled = false;
                List<AccountType> accounTypeList = bubucontext.AccountTypes.ToList();
                if (!allRecord)
                {
                    accounTypeList = accounTypeList.Where(a => a.IsActive == true).ToList();
                }
                return accounTypeList;
            }
        }
        /// <summary>
        /// Personal Information
        /// </summary>
        /// <param name="user"></param>
        /// <param name="ErrorMessage"></param>
        /// <returns></returns>
        public bool UpdateUserAndworkCurrentExperienceByUserId(User user, ref string ErrorMessage)
        {
            bool result = false;
            using (bubucontext)
            {
                User userobj = bubucontext.Users.Include("UserWorkExperiences").Where(a => a.Userid == user.Userid).FirstOrDefault();
                if (userobj != null)
                {
                    userobj.UserName = user.UserName;
                    userobj.FirstName = user.FirstName;
                    userobj.MiddleName = user.MiddleName;
                    userobj.LastName = user.LastName;
                    userobj.DateOfBirth = user.DateOfBirth;
                    userobj.EmailAddress = user.EmailAddress;
                    userobj.ContactNumber = user.ContactNumber;
                    // userobj.Domicile = user.Domicile;
                    userobj.DomicileId = user.DomicileId;
                    userobj.CountryId = user.CountryId;
                    userobj.IsMarried = user.IsMarried;
                    userobj.Gender = user.Gender;
                    userobj.UserAddress = user.UserAddress;
                    if (user.CommencementID != null)
                    {
                        userobj.CommencementID = user.CommencementID;
                    }
                    var currentJobWorkExperience = userobj.UserWorkExperiences.Where(a => a.IsCurrentJob == true && a.IsActive == true).FirstOrDefault();
                    if (user.UserWorkExperiences.Count > 0 && currentJobWorkExperience != null && currentJobWorkExperience.UserWorkExperienceid > 0)
                    {
                        //============Update 
                        currentJobWorkExperience.Company = user.UserWorkExperiences.ToList()[0].Company;
                        currentJobWorkExperience.Position = user.UserWorkExperiences.ToList()[0].Position;
                        currentJobWorkExperience.JobFunction = user.UserWorkExperiences.ToList()[0].JobFunction;
                        currentJobWorkExperience.JobLocation = user.UserWorkExperiences.ToList()[0].JobLocation;
                        currentJobWorkExperience.JobFrom = user.UserWorkExperiences.ToList()[0].JobFrom;
                        currentJobWorkExperience.IsActive = user.UserWorkExperiences.ToList()[0].IsActive;
                    }
                    else if (user.UserWorkExperiences.Count > 0 && currentJobWorkExperience == null)
                    {
                        //===============insert
                        UserWorkExperience woExp = user.UserWorkExperiences.ToList()[0];
                        bubucontext.Entry(woExp).State = EntityState.Added;
                        bubucontext.UserWorkExperiences.Add(woExp);
                    }
                    else if (currentJobWorkExperience != null && currentJobWorkExperience.UserWorkExperienceid > 0 && user.UserWorkExperiences.Count == 0)
                    {
                        currentJobWorkExperience.IsCurrentJob = false;
                    }
                    bubucontext.SaveChanges();
                    result = true;
                }
                else
                {
                    ErrorMessage = Messages.MessageContent(MessageCode.UserNotfound);
                }
                return result;
            }

        }
        #endregion

        #region country
        public List<Country> GetCountries(ref string returnMessage)
        {
            return bubucontext.Countries.Where(a => a.IsActive == true).ToList();
        }
        #endregion
        #region Qualification
        public List<UserQualification> GetQualificationByUserId(int userid, ref string returnMessage)
        {
            using (bubucontext)
            {
                return bubucontext.UserQualifications.Include("Qualification")
                    .Include("country").Where(a => a.UserId == userid && a.IsActive == true).ToList();
            }
        }
        public List<Qualification> GetQualificationList(ref string returnMessage)
        {
            return bubucontext.Qualifications.Where(a => a.IsActive == true).ToList();
        }

       


        public bool SaveUserQualification(UserQualification userqualification, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (userqualification.UserQualificationId > 0)
                {
                    bubucontext.Entry(userqualification).State = EntityState.Modified;
                }
                else
                {
                    bubucontext.UserQualifications.Add(userqualification);
                }
                bubucontext.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteUserQualification(int userQualificationId, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                UserQualification usequalification = bubucontext.UserQualifications.Where(a => a.UserQualificationId == userQualificationId).FirstOrDefault();
                if (usequalification != null && usequalification.UserQualificationId > 0)
                {
                    usequalification.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public UserQualification GetUserQualificationById(int userqualificationId, ref string returnMessage)
        {
            return bubucontext.UserQualifications.Where(a => a.UserQualificationId == userqualificationId).FirstOrDefault();
        }


        #endregion
        public List<User> getUserList(bool isActive, int businessClubId, ref string ErrorMessage)
        {

            int accounttype = Convert.ToInt32(UserAccountType.EMPLOYEE);
            List<int> lstmember = bubucontext.BusinessClubMembers.Where(a => a.BusinessClubId == businessClubId
                                                && a.IsActive == true).Select(a => a.MemberId).ToList();
            BusinessClub bc = bubucontext.BusinessClubs.Where(a => a.BusinessClubId == businessClubId).FirstOrDefault();
            List<User> lstUser = bubucontext.Users.Where(a => a.IsActive == true
                                 && a.AccountTypeId == accounttype
                                 && !lstmember.Contains(a.Userid)
                                 && a.Userid != bc.UserCreatedId).ToList();
            return lstUser;

        }

        public bool InsertBusinessClubJoinRequest(BusinessClubJoinRequest businessClubJoinRequest, ref string returnMessage)
        {

            using (bubucontext)
            {
                var BusinessClub = bubucontext.BusinessClubs.Where(a => a.BusinessClubId == businessClubJoinRequest.RequestedBusinessClubId).FirstOrDefault();
                var IsUserAlreadyMember = bubucontext.BusinessClubMembers.Where(a => a.MemberId == businessClubJoinRequest.RequestTo && a.IsActive == true).Count();
                var IsAlreadyRequestSent = bubucontext.BusinessClubJoinRequests.Where(a => a.RequestTo == businessClubJoinRequest.RequestTo
                    && a.IsActive == true).FirstOrDefault();
                if (IsUserAlreadyMember > 0)
                {
                    returnMessage = "User is already a member of this Club";
                    return false;
                }
                else
                {
                    if (BusinessClub != null)
                    {
                        businessClubJoinRequest.RequestedMessage = businessClubJoinRequest.fullName + "," +
                        "There is an invitation for you to join Busines Club(" + BusinessClub.BusinessClubName + "). " + businessClubJoinRequest.message;
                    }
                    if (IsAlreadyRequestSent == null)
                    {
                        try
                        {
                            // bubucontext.Entry(businessClubJoinRequest).State =  EntityState.Added;
                            //BusinessClubJoinRequest businessClubJoinRequestObj = new BusinessClubJoinRequest();
                            ////businessClubJoinRequestObj.BusinessClubJoinRequestId = businessClubJoinRequest.BusinessClubJoinRequestId;
                            //businessClubJoinRequestObj.RequestedBy = businessClubJoinRequest.RequestedBy;
                            //businessClubJoinRequestObj.RequestTo = businessClubJoinRequest.RequestTo;
                            //businessClubJoinRequestObj.RequestedMessage = businessClubJoinRequest.RequestedMessage;
                            //businessClubJoinRequestObj.CreatedBy = businessClubJoinRequest.CreatedBy;
                            //businessClubJoinRequestObj.CreatedDate = DateTime.Now;
                            //businessClubJoinRequestObj.RequestedBusinessClubId = businessClubJoinRequest.RequestedBusinessClubId;
                            //businessClubJoinRequestObj.IsActive = businessClubJoinRequest.IsActive;

                            bubucontext.Entry(businessClubJoinRequest).State = EntityState.Added;
                            bubucontext.BusinessClubJoinRequests.Add(businessClubJoinRequest);
                            bubucontext.SaveChanges();
                            returnMessage = "The request to join club has been sent to the employee";
                        }
                        catch (Exception exx) { }
                        return true;
                    }
                    else
                    {
                        returnMessage = "The request to join club has already been sent to the employee";
                    }
                    return true;

                }
                return false;
            }

        }

        public User GetuserByEmailAddressFirstNameLastName(string fname, string lname, string email)
        {
            using (bubucontext)
            {
                return bubucontext.Users.Where(a => (a.FirstName == fname && a.LastName == lname) || a.EmailAddress == email).FirstOrDefault();
            }
        }

        public List<QualificationCategory> GetAllQualificationCategoriesList()
        {
            using (bubucontext)
            {
                return bubucontext.QualificationCategories.Where(a => a.IsActive.Value).ToList();
            }
        }
    }
}
