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
    
    public partial class FaqStatistic
    {
        public int id { get; set; }
        public int SystemId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Ip_Port { get; set; }
        public Nullable<System.DateTime> SeenTime { get; set; }
    
        public virtual TestSystem TestSystem { get; set; }
    }
}
