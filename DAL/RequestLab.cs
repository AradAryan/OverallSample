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
    
    public partial class RequestLab
    {
        public int RequestLabId { get; set; }
        public string specimenDate { get; set; }
        public Nullable<int> SpecimenType { get; set; }
        public Nullable<long> AdmissionID { get; set; }
    
        public virtual Coded Tbl_Coded { get; set; }
    }
}
