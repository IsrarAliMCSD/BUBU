using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class EFReference
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFReference()
        {
            bubucontext = new BubuEntities();
        }
        public List<Reference> GetReferences()
        {
            return bubucontext.References.ToList();
        }
        public List<UserReference> GetUserReferenceByUserId(int userId, ref string returnMessage)
        {
            return bubucontext.UserReferences.Where(a => a.UserId == userId && a.IsActive == true).ToList();

        }
        public UserReference GetUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            return bubucontext.UserReferences.Where(a => a.UserReferenceId == userReferenceId && a.IsActive == true).FirstOrDefault();
        }




        public bool DeleteUserReferenceByUserReferenceId(int userReferenceId, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                UserReference userReference = bubucontext.UserReferences.Where(a => a.UserReferenceId == userReferenceId).FirstOrDefault();
                if (userReference != null && userReference.UserReferenceId > 0)
                {
                    userReference.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool SaveUserReference(UserReference userReference, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (userReference != null && userReference.UserReferenceId > 0)
                {
                    UserReference userReferenceObj = bubucontext.UserReferences.Where(a => a.UserReferenceId == userReference.UserReferenceId).FirstOrDefault();
                    userReferenceObj.IsActive = true;
                    userReferenceObj.ReferenceCompany = userReference.ReferenceCompany;
                    userReferenceObj.ReferenceContactNo = userReference.ReferenceContactNo;
                    userReferenceObj.ReferenceId = userReference.ReferenceId;
                    userReferenceObj.ReferenceName = userReference.ReferenceName;
                    userReferenceObj.ReferencePosition = userReference.ReferencePosition;
                }
                else
                {
                    bubucontext.UserReferences.Add(userReference);
                }
                bubucontext.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
