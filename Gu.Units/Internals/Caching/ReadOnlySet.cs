namespace Gu.Units
{
    using System;
    using System.Collections.Generic;

    internal static class ReadOnlySet
    {
        internal static ReadonlySet<T> AsReadOnly<T>(this ISet<T> source)
            where T : IEquatable<T>
        {
            return new ReadonlySet<T>(source);
        }
    }
}