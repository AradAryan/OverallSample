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
    
    public partial class EntityType
    {
        public EntityType()
        {
            this.EntityEntityTypes = new HashSet<EntityEntityType>();
            this.EntityEntityTypes1 = new HashSet<EntityEntityType>();
            this.EntityEntityTypes2 = new HashSet<EntityEntityType>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public byte WhichType { get; set; }
        public int Code { get; set; }
        public decimal FirstUserReg { get; set; }
        public string FirstDateReg { get; set; }
        public string IP { get; set; }
        public string ClientName { get; set; }
    
        public virtual ICollection<EntityEntityType> EntityEntityTypes { get; set; }
        public virtual ICollection<EntityEntityType> EntityEntityTypes1 { get; set; }
        public virtual ICollection<EntityEntityType> EntityEntityTypes2 { get; set; }
    }
}
