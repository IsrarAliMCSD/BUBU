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
    
    public partial class DocumentUpload
    {
        public int UploadDocumentId { get; set; }
        public Nullable<int> Userid { get; set; }
        public Nullable<int> DocumentCategoryid { get; set; }
        public string ContentType { get; set; }
        public byte[] ContentData { get; set; }
        public string format { get; set; }
        public string fileName { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual DocumentCategory DocumentCategory { get; set; }
        public virtual User User { get; set; }
    }
}
