using DAOClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bubu_WebApp
{
    //public class UserSession
    //{
    //    public int userid { get; set; }
    //    public string userName { get; set; }
    //    public string emailAddress { get; set; }
    //    public string AccountTye { get; set; }
    //}

    public class SessionHelper
    {
        public static UserSession getUserSession()
        {
            return ((UserSession)HttpContext.Current.Session[SessionNames.S_User.ToString()]);
        }

    }
}