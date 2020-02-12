using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Service
{
    public class MinimumSyndromModel
    {
        public Guid CenterGuid { get; set; }
        public string CenterUserNationalCode { get; set; }
        public string RegisterDate { get; set; }
        public string SyndromVisitDate { get; set; }
        public string PatientNationalCode { get; set; }
        public string PatientFirstname { get; set; }
        public string PatientLastname { get; set; }
        public string PatientBirthDate { get; set; }
        public string PatientFathername { get; set; }
        public Gender PatientGender { get; set; }
        public int PatientProvinceId { get; set; }
        public int PatientCityId { get; set; }
        public string PatientAddress { get; set; }
        public string PatientMobile { get; set; }
        public string PatientPhone { get; set; }
        public int SyndromId { get; set; }
        public AdmissionType AdmissionType { get; set; }

    }
}
