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
    
    public partial class LabDiseaseAssignment
    {
        public int Id { get; set; }
        public long LabCorporateId { get; set; }
        public int DiseaseId { get; set; }
        public long LevelId { get; set; }
        public string RegisterDate { get; set; }
        public int SyndromId { get; set; }
    
        public virtual BasicData BasicData { get; set; }
        public virtual Disease Disease { get; set; }
        public virtual Corporate Corporate { get; set; }
    }
}
