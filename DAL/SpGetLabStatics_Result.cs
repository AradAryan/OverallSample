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
    
    public partial class SpGetLabStatics_Result
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SampleId { get; set; }
        public string LabResultDate { get; set; }
        public int DiseasesId { get; set; }
        public long TestQuality { get; set; }
        public long PrimaryLabResult { get; set; }
        public System.DateTime CurrentDateTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ResultIsSecure { get; set; }
    }
}
