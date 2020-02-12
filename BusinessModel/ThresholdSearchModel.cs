using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class ThresholdSearchModel : TherosholdModel
    {
        public bool CountBased { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int WarningStatusId { get; set; }
        public int WarningId { get; set; }


        public int CurrentUserId { get; set; }
    }
}
