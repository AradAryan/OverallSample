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
    
    public partial class Country
    {
        public Country()
        {
            this.TblTravels = new HashSet<Travel>();
            this.ProTravels = new HashSet<ProTravel>();
        }
    
        public int CountryID { get; set; }
        public string country { get; set; }
        public string code { get; set; }
        public string TerminologyId { get; set; }
    
        public virtual ICollection<Travel> TblTravels { get; set; }
        public virtual ICollection<ProTravel> ProTravels { get; set; }
    }
}