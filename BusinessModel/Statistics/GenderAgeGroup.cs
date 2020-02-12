using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class GenderAgeGroup
    {
        public BusinessModel.Service.Gender Gender { get; set; }
        public int AgeGroup { get; set; }
        public int Count { get; set; }
    }
}
