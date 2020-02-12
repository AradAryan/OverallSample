using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class SyndromeRegisterModel
    {
        public long SyndromeRegisterId { get; set; }
        public string PatientName { get; set; }
        public string NetworkName { get; set; }
        public string universityName { get; set; }
        public string SyndromeName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Dates { get; set; }
        public string PersianDate { get; set; }
        public string Times { get; set; }
        public string ErrorMessage { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CenterName { get; set; }
        public string CenterGUID { get; set; }
        public Nullable<bool> IsOutRegister { get; set; }
        public Nullable<int> AdmissionType { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<long> PatientID { get; set; }
        public Nullable<int> SyndromicId { get; set; }
        public string CompositionUID { get; set; }
    }
    
}
