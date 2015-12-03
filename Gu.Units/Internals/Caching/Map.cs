namespace Gu.Units
{
    using System.Collections.Generic;

    internal class Map<T1, T2>
    {
        private readonly object gate = new object();
        private Dictionary<T1, T2> dictT1T2;
        private Dictionary<T2, T1> dictT2T1;

        internal Map()
            : this(null, null)
        {
        }

        internal Map(IEqualityComparer<T1> comparer)
            : this(comparer, null)
        {
        }

        internal Map(IEqualityComparer<T2> comparer)
            : this(null, comparer)
        {
        }

        internal Map(IEqualityComparer<T1> comparer1, IEqualityComparer<T2> comparer2)
        {
            this.dictT1T2 = new Dictionary<T1, T2>(comparer1);
            this.dictT2T1 = new Dictionary<T2, T1>(comparer2);
        }

        internal void TryAdd(T1 key, T2 value)
        {
            lock (this.gate)
            {
                this.dictT1T2 = new Dictionary<T1, T2>(this.dictT1T2, this.dictT1T2.Comparer) { { key, value } };
                this.dictT2T1 = new Dictionary<T2, T1>(this.dictT2T1, this.dictT2T1.Comparer) { { value, key } };
            }
        }

        internal bool TryGet(T1 key, out T2 result)
        {
            return this.dictT1T2.TryGetValue(key, out result);
        }

        internal bool TryGet(T2 key, out T1 result)
        {
            return this.dictT2T1.TryGetValue(key, out result);
        }
    }
}
