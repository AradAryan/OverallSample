using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class ChartData
    {
        /// <summary>عنوان دسته</summary>
        public string Title { get; set; }

        /// <summary>کد گروه - استفاده جهت پیداکردن دسته</summary>
        public string Code { get; set; }

        /// <summary>مقدار</summary>
        public decimal Value { get; set; }

        /// <summary>مقادیر - برای مقایسه چندین سال</summary>
        public List<KeyValuePair<string, decimal>> Values { get; set; }
    }
}
