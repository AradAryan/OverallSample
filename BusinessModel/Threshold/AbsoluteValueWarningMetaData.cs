using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Threshold
{
    public class AbsoluteValueWarningMetaData
    {
        /*
        public int Id { get; set; }

        public int WarningId { get; set; }

        /// <summary>
        /// اطلاعات به صورت متن
        /// json
        /// </summary>
        public string MetaData { get; set; }
        */

        public decimal ThresholdValue { get; set; }

        public decimal CurrentValue { get; set; }
    }
}
