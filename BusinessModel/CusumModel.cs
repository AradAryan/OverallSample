using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class CusumModel
    {
        public Nullable<int> Count { get; set; }
        public Nullable<int> CityId { get; set; }
        public string PersianDate { get; set; }
        public double Preprocess { get; set; }
        public double firstsecondary { get; set; }
        public double Seconsecondary { get; set; }
        public bool Alert { get; set; }
    }
}
