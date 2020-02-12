using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class UserPositionHierarchy
    {
        public long? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public long? UniversityId { get; set; }
        public string UniversityName { get; set; }
        public long? NetworkId { get; set; }
        public string NetworkName { get; set; }
        public long? CenterId { get; set; }
        public string CenterName { get; set; }
    }
}
