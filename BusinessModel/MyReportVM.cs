using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class MyReportVM
    {
        public int RowNumber { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceTitle { get; set; }
        public int UniversityId { get; set; }
        public string UniversityTitle { get; set; }
        public int NetworkId { get; set; }
        public string NetworkTitle { get; set; }
        public int CenterId { get; set; }
        public string CenterTitle { get; set; }
        public int SyndromicId { get; set; }
        public string SyndromicTitle { get; set; }
        public int Count { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
