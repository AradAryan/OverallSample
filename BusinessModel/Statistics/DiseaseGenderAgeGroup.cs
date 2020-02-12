using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class DiseaseGenderAgeGroup
    {
        public string DiseaseName { get; set; }
        public List<AgeGroup> Data { get; set; }

        public DiseaseGenderAgeGroup()
        {
            Data = new List<AgeGroup>();
        }
    }
}
