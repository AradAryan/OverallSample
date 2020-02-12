using BusinessModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class EpidemicMaxHelperModel
    {
        public Gender Gender { get; set; }
        public int AgeGroup { get; set; }
        public string DiseaseName { get; set; }
        public int Count { get; set; }
    }
}
