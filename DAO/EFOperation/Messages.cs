using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Messages
    {
        public static string MessageContent(MessageCode mc)
        {
            switch (mc)
            {
                case MessageCode.AlreadyExistsUser:
                    return "The user with the same User Name / email address already exists.";
                case MessageCode.AccountCreated:
                    return "The account has been created successfully. Please login in";
                    //return "The account has been created successfully. An email has been generated for account activation";
                case MessageCode.AccountActivatedAlready:
                    return "User is already activated";
                case MessageCode.AccountActivatedFail:
                    return "The account is not activated.";
                case MessageCode.AccountActivatedSuccess:
                    return "<p> <strong>Congratulation {0} </strong> </p> <p>your account has been activated.</p>";
                case MessageCode.NoRecordFound:
                    return "Login fail";
                case MessageCode.AccountActivatedExpired:
                    return " Acount activation code has been expired";
                case MessageCode.NoUserNamefound:
                    return "Email Address is not found";
                case MessageCode.AccountActivatedNotFound:
                    return "Acount activation code is not found";
                case MessageCode.UserNotfound:
                    return "User not found";
                case MessageCode.UserCommencementUpdate:
                    return "User Commencement has been updated.";
                case MessageCode.AlreadyExistUserHobby:
                    return "User already has record with same hobby. Please update Instead of insert user's hobby which is already exists";
                case MessageCode.AlreadyExistUserSkill:
                    return "User already has record with same skill. Please update Instead of insert user's skill which is already exists";
                case MessageCode.AlreadyAppliedForVacancy:
                    return "You have already applied for the vacancy.";
                case MessageCode.AppliedForVacancySaved:
                    return "You have applied for the vacancy successfully";
                case MessageCode.MessageSentSuccessfully:
                    return "Message has been sent successfully";
                case MessageCode.BusinessClubAlreadyExists:
                    return "Business with the same name already Exists";
                case MessageCode.BusinessClubNotExists:
                    return "Business club does not exists";
                case MessageCode.BusinessClubAlreadyMember:
                    return "You are already a member of this Business club";
                case MessageCode.BusinessClubMemberAdd:
                    return "Congratulation. You have become a member of the club";
                    

                default:
                    return "";
            }


        }
    }
    public enum MessageCode
    {
        AlreadyExistsUser,
        NoRecordFound,
        NoUserNamefound,
        AccountCreated,
        AccountActivatedSuccess,
        AccountActivatedNotFound,
        AccountActivatedExpired,
        AccountActivatedAlready,
        AccountActivatedFail,
        UserNotfound,
        UserCommencementUpdate,
        AlreadyExistUserHobby,
        AlreadyExistUserSkill,
        AlreadyAppliedForVacancy,
        AppliedForVacancySaved,
        MessageSentSuccessfully,
        BusinessClubAlreadyExists,
        BusinessClubNotExists,
        BusinessClubAlreadyMember,
        BusinessClubMemberAdd

    }


}
