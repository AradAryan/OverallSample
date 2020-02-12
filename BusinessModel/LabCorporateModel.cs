using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class LabCorporateModel
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }


        public long ParentId { get; set; }

        public string CorporateGuid { get; set; }

        public long CorporateId { get; set; }
        public string CorporateName { get; set; }


        public long CenterId { get; set; }
        public string CenterName { get; set; }


        public long NetworkId { get; set; }
        public string NetworkName { get; set; }


        public long UniversityId { get; set; }
        public string UniversityName { get; set; }


        public List<LabDiseaseBindingModel> DiseaseBindings { get; set; }
    }
}
