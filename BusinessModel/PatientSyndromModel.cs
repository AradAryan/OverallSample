using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class PatientSyndromModel
    {
        public Nullable<long> CenterId { get; set; }
        public Nullable<int> SyndromeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<Guid> NetworkId { get; set; }
        public Nullable<Guid> universityId { get; set; }
        public string Dates { get; set; }
        public DateTime Times { get; set; }
        public string NationalCode { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public string TelPhone { get; set; }
        public Nullable<int> JobID { get; set; }
        public int AdmissionType { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string FirstNameFather { get; set; }
        public string CellPhone { get; set; }
        public Nullable<int> hasNationalCode { get; set; }
        public long PatientID { get; set; }
        public int AdmissionId { get; set; }
        public bool IsPro { get; set; }
        public int AddressProvinceId { get; set; }
        public int AddressCityId { get; set; }
    }
}
