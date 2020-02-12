using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class RiskVM
    {

        public int Row { get; set; }
        public int id { get; set; }
        public int RiskId { get; set; }
        public string Description { get; set; }
        public Nullable<int> CashierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string CustomerCode { get; set; }
    }
}
