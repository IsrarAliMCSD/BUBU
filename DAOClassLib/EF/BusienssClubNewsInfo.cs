//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAOClassLib.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusienssClubNewsInfo
    {
        public int BusinessClubNewsInfoId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDetail { get; set; }
        public int BusinessClubId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual BusinessClub BusinessClub { get; set; }
        public virtual User User { get; set; }
    }
}
