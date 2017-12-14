using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClassLib
{
    public class MiscellenousOperation
    {

    }
    public enum AccountStatus
    {
        Active = 1,
        Suspended = 2,
        NonActivate = 0
    }

    public enum Enum_DocumentCategory
    {
        PROFILEPIC = 4,
        LOGOPIC = 5

    }
    public enum Enum_DocumentTypeId
    {
        Certificates = 1,
        Diploma = 2,
        Other_Documents = 3,
        ProfilePic = 4
    }
    public enum EnumGender
    {
        MALE,
        FEMALE,
        NULL
    }
    public enum JobPrivacy
    {
        Private,
        Public,
        ALL
    }
    public enum UserAccountType
    {
        ADMINISTRATOR = 1,
        EMPLOYEE = 2,
        EMPLOYER = 3
    }
    public enum SessionNames
    {
        S_User
    }
}
