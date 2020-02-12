using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class GetToxinModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public List<GetToxinModel> Items { get; set; }
    }
}
