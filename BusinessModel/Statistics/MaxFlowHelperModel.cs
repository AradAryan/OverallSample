using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class MaxFlowHelperModel
    {
        public string PersianDate { get; set; }

        /// <summary>تعداد کل سندروم برای این تاریخ</summary>
        public int SyndromCount { get; set; }
        
        /// <summary>تعداد نمونه گیری شده</summary>
        public int SampledCount { get; set; }

        /// <summary>لیست نام بیماری ها به همراه تعداد</summary>
        public List<KeyValuePair<string, int>> Diseases { get; set; }
    }
}
