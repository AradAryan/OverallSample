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
    
    public partial class MetaVisibleCorporate
    {
        public int Id { get; set; }
        public long CorporateId { get; set; }
        public long CanSeeCorporateId { get; set; }
    
        public virtual Corporate Corporate { get; set; }
        public virtual Corporate Corporate1 { get; set; }
    }
}