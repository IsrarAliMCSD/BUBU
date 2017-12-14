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
    
    public partial class BusinessClubActivity
    {
        public BusinessClubActivity()
        {
            this.BusinessClubActivityComments = new HashSet<BusinessClubActivityComment>();
            this.BusinessClubActivityDetails = new HashSet<BusinessClubActivityDetail>();
        }
    
        public int BusinesClubActivityId { get; set; }
        public string MessageDetail { get; set; }
        public int BusinessClubMessageTypeId { get; set; }
        public string Subject { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int BusinessClubId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ActivityDate { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
    
        public virtual BusinessActivityMessageType BusinessActivityMessageType { get; set; }
        public virtual BusinessClub BusinessClub { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BusinessClubActivityComment> BusinessClubActivityComments { get; set; }
        public virtual ICollection<BusinessClubActivityDetail> BusinessClubActivityDetails { get; set; }
    }
}