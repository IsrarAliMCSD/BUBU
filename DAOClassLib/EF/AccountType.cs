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
    
    public partial class AccountType
    {
        public AccountType()
        {
            this.Users = new HashSet<User>();
        }
    
        public int AccountTypeId { get; set; }
        public string AccountTitle { get; set; }
        public string AccountDescription { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}