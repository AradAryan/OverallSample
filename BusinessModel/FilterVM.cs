using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class FilterVM
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
        public string AdmissionType { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
