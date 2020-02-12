using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class CorporateModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public long ParentId { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public long UniversityId { get; set; }
        public string UniversityName { get; set; }
        public long NetworkId { get; set; }
        public string NetworkName { get; set; }
        public long CenterId { get; set; }
        public string CenterName { get; set; }
        public long SubCenterId { get; set; }
        public string SubCenterName { get; set; }
        public int CorpTypeId { get; set; }
        public CorpTypeCode CorpType { get; set; }
        public string CorpTypeName { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
