using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
   public class PatientModel
    {
        public long PatientID { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNo { get; set; }
        public string BirthDate { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<int> MaritalID { get; set; }
        public Nullable<int> EducationID { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> InsurerID { get; set; }
        public string InsurerCode { get; set; }
        public string InsurerExpireDate { get; set; }
        public string TelPhone { get; set; }
        public string PostalCode { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public string FullAddress { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> TownId { get; set; }
        public Nullable<int> RuralAreaId { get; set; }
        public byte[] Picture { get; set; }
        public Nullable<int> BirthProvinceID { get; set; }
        public Nullable<int> BirthCityID { get; set; }
        public Nullable<int> CardProvinceID { get; set; }
        public Nullable<int> CardCityID { get; set; }
        public string FirstNameFather { get; set; }
        public string LastNameFather { get; set; }
        public string FirstNameMother { get; set; }
        public string LastNameMother { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string FatherNationalCode { get; set; }
        public string MotherNationalCode { get; set; }
        public string PatientUID { get; set; }
        public Nullable<int> ReligionID { get; set; }
        public Nullable<int> RaceID { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public Nullable<long> FileNumber { get; set; }
        public Nullable<int> Age { get; set; }
    }
}
