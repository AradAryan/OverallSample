using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class LabResultVM
    {
        public int? LabResultId { get; set; }
        public string LabName { get; set; }
        public string SamplingDate { get; set; }
        public string SyndromName { get; set; }
        public string SampleReceiveDate { get; set; }
        public string LabResultDate { get; set; }
        public string TestQualityTitle { get; set; }
        public string PrimaryLabResultTitle { get; set; }
        public int DiseaseId { get; set; }
        public int DiseaseCode { get; set; }
        public string DiseaseName { get; set; }
        public List<LabResultDetailVM> Details { get; set; }

        public string LabDiseaseLevel { get; set; }

        public long? LevelCode { get; set; }
    }

    public class LabResultDetailVM
    {
        public int LabResultId { get; set; }
        public string DetailTitle { get; set; }
        public string DetailCode { get; set; }
        public string TypeTitle { get; set; }
        public long TypeCode { get; set; }
        public string Value { get; set; }
    }
}
