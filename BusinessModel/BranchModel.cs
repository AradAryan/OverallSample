using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class BranchModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public string Branch { get; set; }
    }
}
