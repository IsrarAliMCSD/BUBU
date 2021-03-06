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
    
    public partial class UserQualification
    {
        public int UserQualificationId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> QualificationId { get; set; }
        public Nullable<int> CompletedYear { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Description { get; set; }
        public string Institution { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public Nullable<decimal> CGPA { get; set; }
        public byte[] VersionNo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<int> QualificationCategoryId { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual User User { get; set; }
        public virtual QualificationCategory QualificationCategory { get; set; }
    }
}
