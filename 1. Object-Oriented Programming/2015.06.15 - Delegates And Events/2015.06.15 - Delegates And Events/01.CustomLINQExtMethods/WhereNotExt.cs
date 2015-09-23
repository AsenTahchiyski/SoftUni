namespace CustomLINQExtMethods
{
    using System;
    using System.Collections.Generic;

    public static class WhereNotExt
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> output = new List<T>();
            foreach (T item in collection)
            {
                if (!predicate(item))
                {
                    output.Add(item);
                }
            }
            return output;
        }
    }
}
