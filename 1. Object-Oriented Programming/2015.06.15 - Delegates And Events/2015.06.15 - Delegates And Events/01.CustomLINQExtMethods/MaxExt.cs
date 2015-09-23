namespace CustomLINQExtMethods
{
    using System;
    using System.Collections.Generic;

    public static class MaxExt
    {
        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> predicate) 
            where TSelector : IComparable
        {
            if (collection == null)
            {
                throw new InvalidOperationException("Collection is empty.");
            }

            TSelector max = default(TSelector);
            bool first = true;

            foreach (TSource item in collection)
            {
                if (first)
                {
                    max = predicate(item);
                    first = false;
                }

                if (predicate(item).CompareTo(max) == 1)
                {
                    max = predicate(item);
                }
            }

            return max;
        }
    }
}
