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
    
    public partial class AreaLocation
    {
        public AreaLocation()
        {
            this.TblTravels = new HashSet<Travel>();
            this.TblTherosholds = new HashSet<Theroshold>();
            this.ProTravels = new HashSet<ProTravel>();
        }
    
        public int AreLocationID { get; set; }
        public string CodeString { get; set; }
        public string areaName { get; set; }
        public string CodeStringParent { get; set; }
        public Nullable<int> areaType { get; set; }
        public string terminology { get; set; }
        public Nullable<int> areaParentId { get; set; }
        public Nullable<System.Guid> UniversityId { get; set; }
        public string EnglishName { get; set; }
    
        public virtual AreaType AreaType1 { get; set; }
        public virtual ICollection<Travel> TblTravels { get; set; }
        public virtual ICollection<Theroshold> TblTherosholds { get; set; }
        public virtual University Tbl_University { get; set; }
        public virtual ICollection<ProTravel> ProTravels { get; set; }
    }
}
