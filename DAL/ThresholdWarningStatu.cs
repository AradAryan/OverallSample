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
    
    public partial class ThresholdWarningStatu
    {
        public int Id { get; set; }
        public int WarningId { get; set; }
        public long StatusId { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public string PersianDate { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Comment { get; set; }
        public Nullable<int> AdmissionId { get; set; }
    
        public virtual BasicData BasicData { get; set; }
        public virtual ProAdmission ProAdmission { get; set; }
        public virtual User User { get; set; }
        public virtual WarningThreshold WarningThreshold { get; set; }
    }
}