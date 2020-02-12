using BusinessModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class CFRHelperModel
    {
        public int AgeGroup { get; set; }
        public string DiseaseName { get; set; }
        public decimal CFR { get; set; }
        public Gender Gender { get; set; }

        public int DiedCount { get; set; }

        public int Count { get; set; }
        public int PositiveCount { get; set; }
    }
}
