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
    
    public partial class Syndromic
    {
        public Syndromic()
        {
            this.Diseases = new HashSet<Disease>();
            this.TblComplications = new HashSet<Complication>();
            this.TblTherosholds = new HashSet<Theroshold>();
        }
    
        public int SyndromicId { get; set; }
        public string SyndromicName { get; set; }
        public string SyndromicCode { get; set; }
        public string TerminologyID { get; set; }
        public Nullable<bool> IsIncludedInLab { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> Code { get; set; }
        public Nullable<int> CheckDuplicateDays { get; set; }
    
        public virtual ICollection<Disease> Diseases { get; set; }
        public virtual ICollection<Complication> TblComplications { get; set; }
        public virtual ICollection<Theroshold> TblTherosholds { get; set; }
    }
}