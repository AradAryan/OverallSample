using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class TherosholdModel
    {
        public long Row { get; set; }
        public int TherosholdID { get; set; }
        public long MethodID { get; set; }
        public decimal? FixNumber { get; set; }
        public int SyndromicId { get; set; }
        public string SyndromicName { get; set; }
        public string MethodName { get; set; }
        public string ProvinceName { get; set; }
        public int ProvinceId { get; set; }
        public long UniversityId { get; set; }
        public string UniversityName { get; set; }
        public long NetworkId { get; set; }
        public string NetworkGuid { get; set; }
        public string NetworkName { get; set; }

        public long? PreProcessMethod { get; set; }
        public string PreProcessMethodTitle { get; set; }
        public double? Factor { get; set; }

        /// <summary>
        /// حداقل درصد تا تعداد که در الگوریتمهای 
        /// Relative+, Statistical+
        /// فقط در صورتی اخطار صادر میشود که از این حد عبور کرده باشیم
        /// </summary>
        public decimal? MinAbsoluteLimit { get; set; }

        /// <summary>
        /// مبنای محاسبه آستانه هشدار
        /// </summary>
        public bool? PercentBased { get; set; }

        public int TotalCount { get; set; }

        public bool Deleted { get; set; }

        public string ProvinceEnglishName { get; set; }
    }
}
