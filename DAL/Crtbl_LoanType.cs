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
    
    public partial class Crtbl_LoanType
    {
        public Crtbl_LoanType()
        {
            this.Crtbl_Loan = new HashSet<Crtbl_Loan>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Crtbl_Loan> Crtbl_Loan { get; set; }
    }
}