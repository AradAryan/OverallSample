using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class VisitCountModel
    {
        public long VisitID { get; set; }
        public Nullable<System.DateTime> RegisterDateTime { get; set; }
        public string PersianDate { get; set; }
        public long UserId { get; set; }
        public long CorporateId { get; set; }
        public int Number { get; set; }
    }
}
