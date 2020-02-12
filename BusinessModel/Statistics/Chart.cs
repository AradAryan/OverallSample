using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class Chart
    {
        public string Title { get; set; }
        public List<ChartData> Bars { get; set; }
    }
}
