using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClassLib.EF
{
    public partial class BusinessClubJoinRequest
    {
        [NotMapped]
        public string fullName { get; set; }
        [NotMapped]
        public string message { get; set; }
    }
}
