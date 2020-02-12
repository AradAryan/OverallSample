using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System
{
    public static class EXT
    {
        public static decimal SumOrDefault<T>(this IEnumerable<T> source, Func<T, decimal> exp)
        {
            if (source == null || source.Count() == 0)
                return 0;
            return source.Sum(exp);
        }

        public static int SumOrDefault<T>(this IEnumerable<T> source, Func<T, int?> exp)
        {
            if (source == null || source.Count() == 0)
                return 0;
            int? result = source.Sum(exp);
            return result.GetValueOrDefault();
        }
    }
}
