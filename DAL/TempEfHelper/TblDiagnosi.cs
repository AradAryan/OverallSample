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
    
    public partial class TblDiagnosi
    {
        public long DiagnosisID { get; set; }
        public long AdmissionID { get; set; }
        public Nullable<int> DiagnosisCodeID { get; set; }
        public string DiagnosisDDate { get; set; }
        public Nullable<short> StatusId { get; set; }
    
        public virtual Tbl_Coded Tbl_Coded { get; set; }
        public virtual TblAdmission TblAdmission { get; set; }
    }
}
