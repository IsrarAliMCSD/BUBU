using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Bubu_WebApp
{
    public class MisOp
    {
        public static void ShowMessage(ref UpdatePanel UpdatePanelForm, string message, bool IsError)
        {
            ScriptManager.RegisterStartupScript(UpdatePanelForm, UpdatePanelForm.GetType(), "JScript1",
                "ShowMessage('" + message.Replace("'", "\"") + "'," + ((IsError == true) ? "true" : "false") + ");", true);
        }
        public static void ShowMessage(Control ctrl, string message, string messageTitle, bool IsError)
        {
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "JScript1", "ShowMessage('" + message.Replace("'", "\"") + "', '" + messageTitle + "'," + ((IsError == true) ? "true" : "false") + ");", true);
        }
        public static void ClearMessage(ref UpdatePanel UpdatePanelForm)
        {
            ScriptManager.RegisterStartupScript(UpdatePanelForm, UpdatePanelForm.GetType(), "JScript1", "ClearMessage();", true);
        }
        public static string getContentType(string extension)
        {
            string contenttype = "";
            switch (extension)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            return contenttype;

        }

        public static void DownloadFile(string contentType, string fileName, byte[] bytes)
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = contentType;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static string GetImageURL(string format)
        {
            string returnUL = "";
            if (format == null)
            {
                return "";
            }
            switch (format.ToUpper())
            {
                case ".DOC":
                    returnUL = "~/Images/documentLogo/Doc.png";
                    break;
                case ".DOCX":
                    returnUL = "~/Images/documentLogo/docx.jpg";
                    break;
                case ".PDF":
                    returnUL = "~/Images/documentLogo/pdf.jpg";
                    break;
                case ".RTF":
                    returnUL = "~/Images/documentLogo/RTF.jpg";
                    break;
                case ".TXT":
                    returnUL = "~/Images/documentLogo/TXT.jpg";
                    break;
            }
            return returnUL;
        }
        public static List<string> GetImageTypeList()
        {
            return new List<string> { ".JPG", ".JFIF", ".EXIF", ".TIFF", ".GIF", ".BMP", ".PNG" };
        }
        public static bool IsImageFileFormat(string format)
        {
            return format == null ? false : GetImageTypeList().Contains(format.ToUpper());
        }

        public static string MotivationLetter()
        {
            return "Motivation letter";
        }
        public static string GetDefaultProfileURL(Gender gender)
        {
            return gender.ToString() == Gender.MALE.ToString() ? @"\Images\Icon\male.png" : @"\Images\Icon\FeMale.png";
        }
        public static User AddEmptyUser()
        {
            User user = new User();
            user.ContentData=new byte[10];
            user.format = ".jpg";
            user.FirstName = "";
            return user;
        }

    }
    public enum AccountStatus
    {
        Active = 1,
        Suspended = 2,
        NonActivate = 0

    }
    public enum Account_Type
    {
        Administrator = 1,
        Employee = 2,
        Employer = 3
    }
    public enum SessionNames
    {
        S_User
    }
    public enum GridCommand
    {
        GRIDDOWNLOAD,
        GRIDEDIT,
        GRIDDELETE,
        QUALIFICATIONDELETE,
        QUALIFICATIONEDIT
    }
    public enum Gender
    {
        MALE,
        FEMALE
    }


}