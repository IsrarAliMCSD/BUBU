using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFLanguage
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFLanguage()
        {
            bubucontext = new BubuEntities();
        }
        public List<Language> GetLanguageList()
        {
            return bubucontext.Languages.ToList();
        }

        public List<Level> GetLevelList()
        {
            return bubucontext.Levels.ToList();
        }

        public List<UserLanguage> GetUserLanguageByUserId(int userid, ref string returnMessage)
        {
            return bubucontext.UserLanguages.Where(a => a.UserId == userid && a.IsActive == true).ToList();
        }
        public bool DeleteUserLanguageByUserLanguageId(int userLanguageid, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                UserLanguage userLanguage = bubucontext.UserLanguages.Where(a => a.UserLanguageId == userLanguageid).FirstOrDefault();
                if (userLanguage != null && userLanguage.UserLanguageId > 0)
                {
                    userLanguage.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public UserLanguage GetUserLanguageByUserLanguageId(int userLanguageId, ref string returnMessage)
        {
            return bubucontext.UserLanguages.Where(a => a.UserLanguageId == userLanguageId).FirstOrDefault();
        }
        public bool SaveUserLanguage(UserLanguage userLanguage, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (userLanguage != null && userLanguage.UserLanguageId > 0)
                {
                    bubucontext.Entry(userLanguage).State = EntityState.Modified;
                }
                else
                {
                    bubucontext.UserLanguages.Add(userLanguage);
                }
                bubucontext.SaveChanges();
                result = true;
            }
            return result;
        }


    }
}
