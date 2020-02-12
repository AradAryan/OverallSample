using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class CuSumProcessModel
    {
        /// <summary>تاریخ</summary>
        public string PersianDate { get; set; }

        /// <summary>مقدار - تعداد یا درصد</summary>
        public decimal Amount { get; set; }

        /// <summary>مقدار پیش پردازش شده</summary>
        public decimal PreProccessed { get; set; }

        /// <summary>میانگین دوره - 3 روزه یا 7 روزه</summary>
        public decimal PeriodAverage { get; set; }

        /// <summary>انحراف معیار دوره - 3 روزه یا 7 روزه</summary>
        public decimal PeriodStdDev { get; set; }

        /// <summary>آستانه هشدار دوره</summary>
        public decimal PeriodUCL { get; set; }

        /// <summary>مقدار ماکزیمم شده مقدار کیوسام برای سطر مورد نظر</summary>
        public double CuSumMaxifiedValue { get; set; }

        /// <summary>سطر مورد نظر اخطار دارد یا نه</summary>
        public bool HasWarn { get; set; }

        /// <summary>مقداری که باعث تولید اخطار آستانه هشدار شده است</summary>
        public decimal WarningValue { get; set; }
    }
}
