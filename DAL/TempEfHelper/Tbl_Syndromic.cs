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
    
    public partial class Tbl_Syndromic
    {
        public Tbl_Syndromic()
        {
            this.Diseases = new HashSet<Disease>();
            this.TblComplications = new HashSet<TblComplication>();
            this.TblTherosholds = new HashSet<TblTheroshold>();
        }
    
        public int SyndromicId { get; set; }
        public string SyndromicName { get; set; }
        public string SyndromicCode { get; set; }
        public string TerminologyID { get; set; }
        public Nullable<bool> IsIncludedInLab { get; set; }
        public string EnglishName { get; set; }
    
        public virtual ICollection<Disease> Diseases { get; set; }
        public virtual ICollection<TblComplication> TblComplications { get; set; }
        public virtual ICollection<TblTheroshold> TblTherosholds { get; set; }
    }
}
