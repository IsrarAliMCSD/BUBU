using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFHobby
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFHobby()
        {
            bubucontext = new BubuEntities();
        }
        public List<Hobby> GetHobbies()
        {
            return bubucontext.Hobbies.Where(a => a.IsActive == true).ToList();
        }
        public List<UserHobby> GetUserHobbiesByUserId(int userId, ref string returnMessage)
        {
            return bubucontext.UserHobbies.Where(a => a.UserId == userId && a.IsActive == true).ToList();
        }
        public UserHobby GetUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            return bubucontext.UserHobbies.Where(a => a.UserHobbyId == userHobbyId && a.IsActive == true).FirstOrDefault();
        }

        public bool DeleteUserHobbyByUserHobbyId(int userHobbyId, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                UserHobby userHobby = bubucontext.UserHobbies.Where(a => a.UserHobbyId == userHobbyId).FirstOrDefault();
                if (userHobby != null && userHobby.UserHobbyId > 0)
                {
                    userHobby.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool SaveUserHobby(UserHobby userHobby, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (userHobby != null && userHobby.UserHobbyId > 0)
                {
                    UserHobby userHobbyObj = bubucontext.UserHobbies.Where(a => a.UserHobbyId == userHobby.UserHobbyId).FirstOrDefault();
                    userHobbyObj.IsActive = true;
                    userHobbyObj.HobbyDetail = userHobby.HobbyDetail;
                    userHobbyObj.HobbyId = userHobby.HobbyId;
                    result = true;
                }
                else
                {
                    UserHobby userHobbyObj = bubucontext.UserHobbies.Where(a => a.UserId == userHobby.UserId &&
                                            a.HobbyId == userHobby.HobbyId).FirstOrDefault();
                    if (userHobbyObj != null && userHobbyObj.UserHobbyId > 0)
                    {
                        returnMessage = Messages.MessageContent(MessageCode.AlreadyExistUserHobby);
                    }
                    else
                    {
                        bubucontext.UserHobbies.Add(userHobby);
                        result = true;
                    }
                }
                bubucontext.SaveChanges();

            }
            return result;
        }

    }
}
