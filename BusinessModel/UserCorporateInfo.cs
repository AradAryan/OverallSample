using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class UserCorporateInfo
    {
        public string Province { get; set; }
        public long? ProvinceId { get; set; }

        public string University { get; set; }
        public long? UniversityId { get; set; }

        public string Network { get; set; }
        public long? NetworkId { get; set; }

        public string Center { get; set; }
        public long? CenterId { get; set; }

    }
}
