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
    
    public partial class spGetLabDiseaseAssignments_Result
    {
        public Nullable<long> Row { get; set; }
        public int Id { get; set; }
        public long LabCorporateId { get; set; }
        public int DiseaseId { get; set; }
        public int SyndromId { get; set; }
        public string SyndromName { get; set; }
        public long LevelId { get; set; }
        public string RegisterDate { get; set; }
        public string DiseaseName { get; set; }
        public string LabName { get; set; }
        public string LevelName { get; set; }
        public Nullable<int> TotalCount { get; set; }
    }
}