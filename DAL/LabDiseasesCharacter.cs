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
    
    public partial class LabDiseasesCharacter
    {
        public long Id { get; set; }
        public int DiseasesId { get; set; }
        public Nullable<long> LabDiseaesTypeId { get; set; }
        public bool IstwinTest { get; set; }
        public string TestMethode { get; set; }
        public string Code { get; set; }
    
        public virtual BasicDataType BasicDataType { get; set; }
        public virtual Disease Disease { get; set; }
    }
}
