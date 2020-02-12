using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class LabDiseaseBindingModel
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }


        public long LabCorporateId { get; set; }
        public string LabCorporateName { get; set; }


        public long LLevelId { get; set; }
        public string LLevelTitle { get; set; }


        public long RLevelId { get; set; }
        public string RLevelTitle { get; set; }
    }
}
