namespace Gu.Units.Internals
{
    using System;
    using System.Collections.Generic;

    internal static class EnumerableExt
    {
        /// <summary>
        /// http://stackoverflow.com/a/504683/1069200
        /// </summary>
        internal static int BinarySearchBy<TSource, TKey>(
            this IReadOnlyList<TSource> list,
            Func<TSource, TKey> projection,
            TKey key)
        {
            var min = 0;
            var max = list.Count - 1;

            while (min <= max)
            {
                var mid = (min + max) / 2;
                var midKey = projection(list[mid]);
                var comparison = Comparer<TKey>.Default.Compare(midKey, key);
                if (comparison == 0)
                {
                    return mid;
                }

                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return ~min;
        }
    }
}
