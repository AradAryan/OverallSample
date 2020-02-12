using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class WarningThresholdModel
    {
        public long Row { get; set; }

        public TherosholdModel Threshold { get; set; }
        public int TotalCount { get; set; }


        public string PersianDate { get; set; }

        public decimal ThresholdValue { get; set; }

        public decimal CurrentValue { get; set; }

        /// <summary>شناسه آخرین وضعیت اخطار</summary>
        public long? LastStatusId { get; set; }

        /// <summary>آخرین وضعیت اخطار</summary>
        public string LastStatusTitle { get; set; }

        public int WarningId { get; set; }

        public bool Unverified { get; set; }
    }
}
