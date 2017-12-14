using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFSkill
    {
        public BubuEntities bubucontext;
        bool result = false;

        public EFSkill()
        {
            bubucontext = new BubuEntities();
            //  bubucontext.Configuration.LazyLoadingEnabled = false;
        }
        public List<Skill> GetSkills()
        {
            return bubucontext.Skills.Where(a => a.IsActive == true).ToList();
        }
        public List<UserSkill> GetUserSkillsByUserId(int userId, ref string returnMessage)
        {
            return bubucontext.UserSkills.Where(a => a.UserId == userId && a.IsActive == true).ToList();
        }
        public UserSkill GetUserSkillByUserSkillyId(int userSkillId, ref string returnMessage)
        {
            return bubucontext.UserSkills.Where(a => a.UserSkillId == userSkillId && a.IsActive == true).FirstOrDefault();
        }
        public bool DeleteUserSkillByUserSkillId(int userSkillId, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                UserSkill userSkill = bubucontext.UserSkills.Where(a => a.UserSkillId == userSkillId).FirstOrDefault();
                if (userSkill != null && userSkill.UserSkillId > 0)
                {
                    userSkill.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool SaveUserSkill(UserSkill userSkill, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (userSkill != null && userSkill.UserSkillId > 0)
                {
                    UserSkill userSkillObj = bubucontext.UserSkills.Where(a => a.UserSkillId == userSkill.UserSkillId).FirstOrDefault();
                    userSkillObj.IsActive = true;
                    userSkillObj.SkillDetail = userSkill.SkillDetail;
                    userSkillObj.SkillId = userSkill.SkillId;
                    result = true;
                }
                else
                {
                    UserSkill userSkillObj = bubucontext.UserSkills.Where(a => a.UserId == userSkill.UserId &&
                                            a.SkillId == userSkill.SkillId).FirstOrDefault();
                    if (userSkillObj != null && userSkillObj.UserSkillId > 0)
                    {
                        returnMessage = Messages.MessageContent(MessageCode.AlreadyExistUserHobby);
                    }
                    else
                    {
                        bubucontext.UserSkills.Add(userSkill);
                        result = true;
                    }
                }
                bubucontext.SaveChanges();

            }
            return result;
        }

    }
}
