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
    
    public partial class ProPatient
    {
        public int PatientID { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> JobID { get; set; }
        public string TelPhone { get; set; }
        public string FullAddressHouse { get; set; }
        public string FullAddressJob { get; set; }
        public string PatientUID { get; set; }
    }
}
