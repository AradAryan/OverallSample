using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class SearchResult<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
