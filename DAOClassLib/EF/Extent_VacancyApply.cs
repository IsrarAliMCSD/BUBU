using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClassLib.EF
{
    public partial class VacancyApply
    {
        [NotMapped]
        public int CVMatch { get; set; }
    }

    public partial class User
    {
        [NotMapped]
        public int CVMatch { get; set; }
    }
}
