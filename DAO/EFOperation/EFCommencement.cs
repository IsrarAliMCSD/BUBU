using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFCommencement
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFCommencement()
        {
            bubucontext = new BubuEntities();
        }
        public List<Commencement> GetCommencements()
        {
            return bubucontext.Commencements.ToList();
        }
        public bool UpdateCommencement(int commencementId, int userid, ref string returnMessage)
        {
            using (bubucontext)
            {
                User user = bubucontext.Users.Where(a => a.Userid == userid).FirstOrDefault();
                if (user != null)
                {
                    user.CommencementID = commencementId;
                    bubucontext.SaveChanges();
                    returnMessage = Messages.MessageContent(MessageCode.UserCommencementUpdate);
                    result = true;
                }
                return result;
            }
 
        }

    }
}
