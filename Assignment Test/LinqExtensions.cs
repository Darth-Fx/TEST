using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public static class LinqExtensions
    { 
        public static IEnumerable<TResult> FirstOrEmpty<TKey, TResult>(
                        this IEnumerable<IGrouping<TKey, TResult>> source)

        {
            return source.FirstOrDefault() ?? Enumerable.Empty<TResult>();
        }
    }
}
