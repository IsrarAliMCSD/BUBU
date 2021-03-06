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
    
    public partial class Qualification
    {
        public Qualification()
        {
            this.UserQualifications = new HashSet<UserQualification>();
            this.Vacancies = new HashSet<Vacancy>();
        }
    
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public Nullable<int> QualificationLevel { get; set; }
        public byte[] VersionNo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<UserQualification> UserQualifications { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
