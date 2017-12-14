using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Bubu_WebApp
{
    public class MiscellaneousOperation
    {
        public static AppManager appmanager;
        public string returnMessage = "";
        public static string returnMessageStatic = "";
        public MiscellaneousOperation()
        {
            appmanager = new AppManager();

        }

        public void fillAccountType(ref DropDownList ddl)
        {
            List<AccountType> lst_AccType = appmanager.getAllAccountType(false);
            ddl.DataSource = lst_AccType;
            ddl.DataTextField = "ACCOUNTTITLE";
            ddl.DataValueField = "ACCOUNTTYPEID";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void addSelectInDropdown(ref DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select", "-1")); //updated code
        }

        public User getUserByUserId(int userid, ref string returnMessage)
        {
            appmanager = new AppManager();
            return appmanager.getUserByUserId(userid, ref returnMessage);
        }
        public string GetImage(object img)
        {
            return img != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])img) : "";
        }
        public void fillDocumentType(ref DropDownList ddl)
        {
            List<DocumentCategory> lst_AccType = appmanager.getAllDocumentCategories();
            ddl.DataSource = lst_AccType;
            ddl.DataTextField = "DOCUMENTCATEGORYNAME";
            ddl.DataValueField = "DOCUMENTCATEGORYID";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public static List<DocumentUpload> GetAllDocumentByDocumentIdAndDocumentType(int documentTypeId, int userid)
        {
            appmanager = new AppManager();
            return appmanager.GetAllDocumentByUserIdAndDocumentType(documentTypeId, userid);
        }

        public void fillCountries(ref DropDownList ddl, ref string returnMessage)
        {
            List<Country> lst_country = appmanager.GetCountries(ref returnMessage);
            ddl.DataSource = lst_country;
            ddl.DataValueField = "COUNTRYID";
            ddl.DataTextField = "COUNTRYNAME";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void fillQualification(ref DropDownList ddl, ref string returnMessage)
        {
            List<Qualification> lst_country = appmanager.GetQualificationList(ref returnMessage);
            ddl.DataSource = lst_country;
            ddl.DataValueField = "QUALIFICATIONID";
            ddl.DataTextField = "QUALIFICATIONNAME";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
       
        public void fillLanguage(ref DropDownList ddl)
        {
            List<Language> lst_language = appmanager.GetLanguageList();
            ddl.DataSource = lst_language;
            ddl.DataValueField = "LanguageId";
            ddl.DataTextField = "LanguageName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void FillLevel(ref DropDownList ddl)
        {
            List<Level> lst_level = appmanager.GetLevelList();
            ddl.DataSource = lst_level;
            ddl.DataValueField = "LevelId";
            ddl.DataTextField = "LevelName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void FillGender(ref DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("MALE", "MALE"));
            ddl.Items.Add(new ListItem("FEMALE", "FEMALE"));
            
            addSelectInDropdown(ref ddl);
        }
        public void FillCommencement(ref DropDownList ddl)
        {
            List<Commencement> commencements = appmanager.GetCommencements();
            ddl.DataSource = commencements;
            ddl.DataValueField = "CommencementId";
            ddl.DataTextField = "CommencementDescription";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void FillReference(ref DropDownList ddl)
        {
            List<Reference> references = appmanager.GetReferences();
            ddl.DataSource = references;
            ddl.DataValueField = "ReferenceId";
            ddl.DataTextField = "ReferenceName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void FillHobbies(ref DropDownList ddl)
        {
            List<Hobby> hobbies = appmanager.GetHobbies();
            ddl.DataSource = hobbies;
            ddl.DataValueField = "HobbyId";
            ddl.DataTextField = "HobbyName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void FillSkills(ref DropDownList ddl)
        {
            List<Skill> skills = appmanager.GetSkills();
            ddl.DataSource = skills;
            ddl.DataValueField = "SkillId";
            ddl.DataTextField = "SkillName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void FillJobType(ref DropDownList ddl)
        {
            List<JobType> jobTypes = appmanager.GetJobType();
            ddl.DataSource = jobTypes;
            ddl.DataValueField = "JobTypeId";
            ddl.DataTextField = "JobTypeName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void FillAge(ref DropDownList ddl)
        {
            for (int item = 20; item < 55; item++)
            {
                ddl.Items.Add(new ListItem(item.ToString()));
            }
            addSelectInDropdown(ref ddl);
        }


        public void GetWorkExperience(ref DropDownList ddl)
        {
            List<WorkExperience> workExperiences = appmanager.GetWorkExperience();
            ddl.DataSource = workExperiences;
            ddl.DataValueField = "DaysCount";// "WorkExperienceId";
            ddl.DataTextField = "WorkExperienceName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void GetDomiciles(ref DropDownList ddl)
        {
            List<Domicile> domiciles = appmanager.GetDomiciles();
            ddl.DataSource = domiciles;
            ddl.DataValueField = "DomicileId";// "WorkExperienceId";
            ddl.DataTextField = "DomicileName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void GetRegionList(ref DropDownList ddl)
        {
            List<Region> regions = appmanager.GetRegionList();
            ddl.DataSource = regions;
            ddl.DataValueField = "RegionId";// "WorkExperienceId";
            ddl.DataTextField = "RegionName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void GetDistinctJobFunctionsList(ref DropDownList ddl)
        {
            List<string> regions = appmanager.GetDistinctJobFunctionsList();
            ddl.DataSource = regions;
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void GetDistinctSector(ref DropDownList ddl)
        {
            List<string> sectors = appmanager.GetDistinctSector();
            ddl.DataSource = sectors;
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void FillBusinessClubByUserId(ref DropDownList ddl, int userid)
        {
            List<BusinessClub> businessClubs = appmanager.GetBusinessClubByUserId(userid);
            ddl.DataSource = businessClubs;
            ddl.DataValueField = "BusinessClubId";// "WorkExperienceId";
            ddl.DataTextField = "BusinessClubName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public static void CVDownload(int userId)
        {
            string outputHTML = string.Empty;
            string pdfUrl = string.Empty;
            appmanager = new AppManager();
            string returnMessage = "";
            string fileName = DateTime.Now.ToShortTimeString();
            //=============Basic html form
            outputHTML = @"<html> <body>";
            string outputHtmlClose = "</body></html>";
            GetallUserPersonalInformation(userId, ref fileName, ref  outputHTML);
            GetUserQualification(userId, ref  outputHTML);
            GetUserExperienceByUserId(userId, ref outputHTML);
            GetUserLanguageByUserId(userId, ref outputHTML);
            FillUserSkills(userId, ref outputHTML);
            FillUserHobbies(userId, ref outputHTML);
            FillUserReference(userId, ref outputHTML);
            GetUserDetail(userId, ref outputHTML);
            outputHTML = outputHTML + outputHtmlClose;
            FileDownload(outputHTML, fileName, ref  returnMessage);
        }

        public static void FileDownload(string outputHTML, string fileName, ref string returnMessage)
        {
            try
            {
                byte[] pdfBytes = null;
                pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(outputHTML);
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.AddHeader("content-length", pdfBytes.Length.ToString());
                response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
                response.BinaryWrite(pdfBytes);
                response.Flush();
                response.End();
            }
            catch (Exception ex)
            {
            }
        }
        public void GetBusinessActivityMessageTypes(ref DropDownList ddl)
        {
            List<BusinessActivityMessageType> businessActivityMessageTypes = appmanager.GetBusinessActivityMessageTypes();
            ddl.DataSource = businessActivityMessageTypes;
            ddl.DataValueField = "BusinessActivityMessageTypeId";// "WorkExperienceId";
            ddl.DataTextField = "BusinessActivityMessageTypeName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public static void GetallUserPersonalInformation(int userid, ref string fileName, ref string outputHTML)
        {
            appmanager = new AppManager();
            User user = appmanager.GetallWorkExperience(userid, ref returnMessageStatic);
            if (user != null)
            {
                string dateOfBirth = user.DateOfBirth != null ? Convert.ToDateTime(user.DateOfBirth).ToShortDateString() : "";
                string maritalStatus = user.IsMarried ? "Married" : "Un Married";
                fileName = user.FirstName + " " + user.LastName;
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>PERSONAL DETAILS</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>
                                        <tr>
                                        <td>" + user.UserName + @"</td>
                                        <td>" + user.FirstName + @"</td>
                                        <td>" + dateOfBirth + @"</td>
                                        </tr>
                                        <tr>
                                        <td>" + user.UserAddress + @"</td>
                                        <td>" + user.EmailAddress + @"</td>
                                        <td>" + user.ContactNumber + @"</td>
                                        </tr>
                                        <tr>
                                        <td>" + maritalStatus + @"</td>
                                        <td></td>
                                        <td></td>
                                        </tr>
                                        </table></br>";
            }
        }
        public static void GetUserQualification(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            List<UserQualification> lstUserQualification = appmanager.GetQualificationByUserId(userid, ref returnMessageStatic);
            if (lstUserQualification.Count > 0)
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>SCHOOL EDUCTION</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
                foreach (var item in lstUserQualification)
                {
                    string completedYear = (item.IsCompleted != null && item.IsCompleted.Value) ? item.CompletedYear.ToString() : "(In Progress)";
                    string qualificationName = item.Qualification != null ? item.Qualification.QualificationName : "";
                    outputHTML = outputHTML + @"<tr>
                                        <td>" + completedYear + @"</td>
                                        <td>" + qualificationName + @"</td>
                                        <td>" + item.Institution + @"</td>
                                        </tr>";
                }

            }
            else
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>SCHOOL EDUCTION</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
            }
            outputHTML = outputHTML + @" </table></br>";
        }

        public static void GetUserExperienceByUserId(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            List<UserWorkExperience> lstUserWorkExperience = appmanager.GetUserExperienceByUserId(userid, ref returnMessageStatic);
            if (lstUserWorkExperience.Count > 0)
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>WORK EXPERIENCE</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
                foreach (var item in lstUserWorkExperience)
                {
                    string jobFrom = (item.JobFrom != null) ? item.JobFrom.ToString("MM/dd/yy") : "";
                    jobFrom += (!item.IsCurrentJob && item.JobTo != null) ? item.JobTo.Value.ToString("MM/dd/yy") : "(Present)";
                    outputHTML = outputHTML + @"<tr>
                                        <td>" + jobFrom + @"</td>
                                        <td>" + item.JobFunction + @"</td>
                                        <td>" + item.Company + @"</td>
                                        </tr>";
                }
            }
            else
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>WORK EXPERIENCE</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
            }
            outputHTML = outputHTML + @" </table></br>";
        }

        public static void GetUserLanguageByUserId(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            List<UserLanguage> lstUserLanguage = appmanager.GetUserLanguageByUserId(userid, ref returnMessageStatic);
            if (lstUserLanguage.Count > 0)
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>LANGUAGE</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
                foreach (var item in lstUserLanguage)
                {
                    string language = (item.Language != null) ? item.Language.LanguageName : "";
                    string level = (item.Level != null) ? item.Level.LevelName : "";
                    outputHTML = outputHTML + @"<tr>
                                        <td>" + language + @"</td>
                                        <td>" + level + @"</td>
                                        <td></td>
                                        </tr>";
                }
            }
            else
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>LANGUAGE</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
            }
            outputHTML = outputHTML + @" </table></br>";
        }

        public static void FillUserSkills(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            List<UserSkill> userSkills = appmanager.GetUserSkillsByUserId(userid, ref returnMessageStatic);
            if (userSkills.Count > 0)
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>ADDITIONAL SKILL</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
                int index = 0;
                foreach (var item in userSkills)
                {
                    if (index == 0 || index % 3 == 0)
                    {
                        outputHTML = outputHTML + "<tr>";
                    }
                    string skills = (item.Skill != null) ? item.Skill.SkillName : "";
                    string skillDetail = (item.SkillDetail != null && item.SkillDetail != "") ? "(" + item.SkillDetail + ")" : item.SkillDetail;
                    outputHTML = outputHTML + "<td>" + skills + " " + skillDetail + "</td>";
                    index++;
                    if (index == 3)
                    {
                        outputHTML = outputHTML + "</tr>";
                        index = 0;
                    }

                }
            }
            else
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>ADDITIONAL SKILL</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
            }
            outputHTML = outputHTML + @" </table></br>";
        }
        public static void FillUserHobbies(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            List<UserHobby> userHobbies = appmanager.GetUserHobbiesByUserId(userid, ref returnMessageStatic);
            if (userHobbies.Count > 0)
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>INTERESTS & HOBBIES</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
                int index = 0;
                foreach (var item in userHobbies)
                {
                    if (index == 0 || index % 3 == 0)
                    {
                        outputHTML = outputHTML + "<tr>";
                    }
                    string hobby = (item.Hobby != null) ? item.Hobby.HobbyName : "";
                    string hobbyDetail = (item.HobbyDetail != null && item.HobbyDetail != "") ? "(" + item.HobbyDetail + ")" : item.HobbyDetail;
                    outputHTML = outputHTML + "<td>" + hobby + " " + hobbyDetail + "</td>";
                    index++;
                    if (index == 3)
                    {
                        outputHTML = outputHTML + "</tr>";
                        index = 0;
                    }
                }
            }
            else
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>INTERESTS & HOBBIES</b></br></br></td>
                                        <td  width='33%'></td>
                                        <td  width='33%'></td>
                                        </tr>";
            }
            outputHTML = outputHTML + @" </table></br>";
        }

        public static void FillUserReference(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            List<UserReference> userReferences = appmanager.GetUserReferenceByUserId(userid, ref returnMessageStatic);
            if (userReferences.Count > 0)
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>REFERENCE</b></br></br></td>
                                        <td  width='67%'></td>
                                        </tr>";
                foreach (var item in userReferences)
                {
                    string referenceName = (item.Reference != null) ? item.Reference.ReferenceName : "";
                    outputHTML = outputHTML + @"<tr>
                                        <td>" + referenceName + @"</td>
                                        <td>" + item.ReferenceName + @",  &nbsp;
                                        " + item.ReferencePosition + @",  &nbsp;
                                        " + item.ReferenceCompany + @"</td>
                                        </tr>";
                }
            }
            else
            {
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td  width='33%'><b>REFERENCE</b></br></br></td>
                                        <td  width='67%'></td>
                                        </tr>";
            }
            outputHTML = outputHTML + @" </table></br>";
        }

        public static void GetUserDetail(int userid, ref string outputHTML)
        {
            appmanager = new AppManager();
            User user = appmanager.getUserByUserId(userid, ref returnMessageStatic);
            if (user != null)
            {
                string commencement = user.Commencement != null ? user.Commencement.CommencementDescription : "";
                outputHTML += @"<table width='100%' border='1'>
                                        <tr>
                                        <td><b>COMMENCEMENT OF JOB</b></br></br></td>
                                        </tr>
                                        <tr>
                                        <td>" + commencement + @"</td>
                                        </tr>
                                        </table></br>";
            }
        }

        public void GetAllQualificationCategoriesList(ref DropDownList ddl, ref string returnMessage)
        {
            List<QualificationCategory> lst_QualificationCategory = appmanager.GetAllQualificationCategoriesList();
            ddl.DataSource = lst_QualificationCategory;
            ddl.DataValueField = "QualificationCategoryId";
            ddl.DataTextField = "QualificationCategoryName";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

    }
}