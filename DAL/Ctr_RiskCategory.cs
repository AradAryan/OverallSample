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
    
    public partial class Ctr_RiskCategory
    {
        public Ctr_RiskCategory()
        {
            this.Ctr_Risk = new HashSet<Ctr_Risk>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Ctr_Risk> Ctr_Risk { get; set; }
    }
}
