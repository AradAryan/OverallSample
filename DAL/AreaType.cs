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
    
    public partial class AreaType
    {
        public AreaType()
        {
            this.Tbl_AreaLocation = new HashSet<AreaLocation>();
        }
    
        public int Id { get; set; }
        public string AreaTypeName { get; set; }
    
        public virtual ICollection<AreaLocation> Tbl_AreaLocation { get; set; }
    }
}
