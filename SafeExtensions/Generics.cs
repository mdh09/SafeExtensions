using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeExtensions
{
    public static class Generics
    {
        public static bool SafeAny<TSource>(this IEnumerable<TSource> pSource)
        {

            return pSource?.Any() ?? false;

        }

        public static bool SafeAny<TSource>(this IEnumerable<TSource> pSource, Func<TSource, bool> pPredicate)
        {
            if (!pSource.SafeAny())
            {
                return false;
            }

            if (pPredicate == null)
            {
                return false;
            }

            return pSource.Any(pPredicate);

        }
    }
}
