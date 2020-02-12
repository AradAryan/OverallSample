using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class AgeGroup
    {
        public string Title { get; set; }
        public decimal Value { get; set; }
        public List<decimal> Values { get; set; }

        public AgeGroup()
        {
            Values = new List<decimal>();
        }
    }
}
