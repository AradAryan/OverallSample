//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sample
    {
        public Sample()
        {
            this.LabResults = new HashSet<LabResult>();
        }
    
        public int Id { get; set; }
        public int PaperCode { get; set; }
        public string RegisterDate { get; set; }
        public int UserId { get; set; }
        public long LabCorporateId { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual ProAdmission ProAdmission { get; set; }
        public virtual Corporate Corporate { get; set; }
        public virtual ICollection<LabResult> LabResults { get; set; }
    }
}