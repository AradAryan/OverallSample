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
    
    public partial class ProLab
    {
        public int LabID { get; set; }
        public Nullable<int> CodeID { get; set; }
        public Nullable<int> AdmissionID { get; set; }
    
        public virtual ProAdmission ProAdmission { get; set; }
    }
}
