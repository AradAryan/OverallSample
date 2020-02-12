using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class DetailedLabResult
    {
        public int AdmissionId { get; set; }
        public int LabResultId { get; set; }
        public string LabResultDate { get; set; }
        public string LabName { get; set; }
        public string VirusName { get; set; }
        public string SubVirusName { get; set; }
        public string CoInfection { get; set; }

    }
}
