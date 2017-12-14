using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EFWorkExperience
    {
        public BubuEntities bubucontext;
        bool result = false;

        public EFWorkExperience()
        {
            bubucontext = new BubuEntities();
            bubucontext.Configuration.ProxyCreationEnabled = true;
            bubucontext.Configuration.LazyLoadingEnabled = true;
        }
        public User GetallWorkExperience(int userid, ref string returnMessage)
        {
            using (bubucontext)
            {
                return bubucontext.Users.Include("UserWorkExperiences")
                    .Include("country")
                     .Include("Domicile")
                     .Include("UserQualifications")
                     .Include("UserQualifications.Qualification")
                    .Where(a => a.Userid == userid).FirstOrDefault();
                // return  bubucontext.Users.Include("WorkExperiences").Where(a=>a.Userid==userid).FirstOrDefault();
            }
        }

        public List<UserWorkExperience> GetUserWorkExperienceCurrentJob(int userid, ref string returnMessage)
        {
            return bubucontext.UserWorkExperiences.Where(a => a.UserId == userid && a.IsCurrentJob == true && a.IsActive == true).ToList();
        }
        public bool SaveUserWorkExperience(UserWorkExperience userWorkexperience, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (userWorkexperience != null && userWorkexperience.UserWorkExperienceid > 0)
                {
                    bubucontext.Entry(userWorkexperience).State = EntityState.Modified;
                }
                else
                {
                    bubucontext.UserWorkExperiences.Add(userWorkexperience);
                }
                bubucontext.SaveChanges();
                result = true;
            }
            return result;
        }

        public List<UserWorkExperience> GetUserExperienceByUserId(int userid, ref string returnMessage)
        {
            return bubucontext.UserWorkExperiences.Where(a => a.UserId == userid && a.IsActive == true).OrderByDescending(a=>a.IsCurrentJob).ToList();
        }
        public bool DeleteUserExperienceByUserExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                UserWorkExperience userWorkExperience = bubucontext.UserWorkExperiences.Where(a => a.UserWorkExperienceid == userWorkExperienceId).FirstOrDefault();
                if (userWorkExperience != null && userWorkExperience.UserWorkExperienceid > 0)
                {
                    userWorkExperience.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public UserWorkExperience GetUserExperienceByUserWorkExperienceId(int userWorkExperienceId, ref string returnMessage)
        {
            return bubucontext.UserWorkExperiences.Where(a => a.UserWorkExperienceid == userWorkExperienceId && a.IsActive == true).FirstOrDefault();
        }
        public List<WorkExperience> GetWorkExperience()
        {
            return bubucontext.WorkExperiences.Where(a => a.IsActive == true).ToList();
        }
    }
}
