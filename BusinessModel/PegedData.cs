using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class PegedData<T>
    {
        public IEnumerable<T> Data;
        public int Total;
    }
}
