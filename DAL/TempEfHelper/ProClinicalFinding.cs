//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.TempEfHelper
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProClinicalFinding
    {
        public int ID { get; set; }
        public Nullable<int> CodeID { get; set; }
        public string PersianDate { get; set; }
        public string Serverity { get; set; }
        public Nullable<int> AdmissionId { get; set; }
    
        public virtual Tbl_Coded Tbl_Coded { get; set; }
        public virtual ProAdmission ProAdmission { get; set; }
    }
}
