using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class ILISentinel
    {
        /// <summary>تعداد کل</summary>
        public int TotalCount { get; set; }

        /// <summary>تعداد زنان</summary>
        public int Female { get; set; }

        /// <summary>تعداد مردان</summary>
        public int Male { get; set; }

        /// <summary>تفکیک سنی موارد گزارش شده</summary>
        public List<KeyValuePair<string, int>> GroupedByAge { get; set; }

        /// <summary>تعداد پایگاه های گزارش دهنده</summary>
        public int ReportedHospitalsCount { get; set; }

        /// <summary>تعداد کل ویزیت ها</summary>
        public int TotalVisitedCount { get; set; }

        /// <summary>درصد بیماران مشکوک</summary>
        public decimal DubiousPercent { get; set; }
    }
}
