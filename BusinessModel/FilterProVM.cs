using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class FilterProVM
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string ProvinceId { get; set; }
        public string UniversityId { get; set; }
        public string NetworkId { get; set; }
        public string CenterId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SyndromId { get; set; }
        public string DiseaseId { get; set; }
        public string AdmissionType { get; set; }
        public int? CurrentUserId { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public bool Standing { get; set; }
        public bool Admitted { get; set; }
        public bool Died { get; set; }
        public bool Positive { get; set; }
        public bool Negative { get; set; }
        public bool Reject { get; set; }
        public bool NoSample { get; set; }
        public bool AnimalTouch { get; set; }
    }
}
