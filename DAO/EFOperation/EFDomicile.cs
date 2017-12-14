using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFDomicile
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFDomicile()
        {
            bubucontext = new BubuEntities();
        }
        public List<Domicile> GetDomiciles()
        {
            return bubucontext.Domiciles.ToList();
        }
    }
}
