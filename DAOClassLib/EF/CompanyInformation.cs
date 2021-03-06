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
    
    public partial class CompanyInformation
    {
        public CompanyInformation()
        {
            this.CompanyAbouts = new HashSet<CompanyAbout>();
            this.Vacancies = new HashSet<Vacancy>();
        }
    
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }
        public string CompanyContentType { get; set; }
        public byte[] CompanyContentData { get; set; }
        public string Companyformat { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyContactNumber { get; set; }
        public string fileName { get; set; }
        public int UserId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<CompanyAbout> CompanyAbouts { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
