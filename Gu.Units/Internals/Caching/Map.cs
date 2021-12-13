namespace Gu.Units
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    internal class Map<T1, T2>
        where T1 : notnull
        where T2 : notnull
    {
        private readonly object gate = new();
        private readonly Dictionary<T1, T2> dictT1T2;
        private readonly Dictionary<T2, T1> dictT2T1;

        internal Map()
            : this(null, null)
        {
        }

        internal Map(IEqualityComparer<T1>? comparer1, IEqualityComparer<T2>? comparer2)
        {
            this.dictT1T2 = new Dictionary<T1, T2>(comparer1);
            this.dictT2T1 = new Dictionary<T2, T1>(comparer2);
        }

        internal void TryAdd(T1 key, T2 value)
        {
            lock (this.gate)
            {
                this.dictT1T2.Add(key, value);
                this.dictT2T1.Add(value, key);
            }
        }

        internal bool TryGet(T1 key, [MaybeNullWhen(false)] out T2 result)
        {
            lock (this.gate)
            {
                return this.dictT1T2.TryGetValue(key, out result!);
            }
        }

        internal bool TryGet(T2 key, [MaybeNullWhen(false)] out T1 result)
        {
            lock (this.gate)
            {
                return this.dictT2T1.TryGetValue(key, out result!);
            }
        }
    }
}
