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
    
    public partial class Crtbl_BranchBossInfo
    {
        public Crtbl_BranchBossInfo()
        {
            this.Crtbl_CashierInfo = new HashSet<Crtbl_CashierInfo>();
        }
    
        public int id { get; set; }
        public int PersonelId { get; set; }
        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    
        public virtual Crtbl_BranchInfo Crtbl_BranchInfo { get; set; }
        public virtual ICollection<Crtbl_CashierInfo> Crtbl_CashierInfo { get; set; }
    }
}