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
    
    public partial class ProComplication
    {
        public int ComplicationID { get; set; }
        public Nullable<int> CausativeAgentCodeID { get; set; }
        public Nullable<int> AdmissionID { get; set; }
        public string Severity { get; set; }
        public Nullable<int> ComplicationCodeID { get; set; }
    }
}
