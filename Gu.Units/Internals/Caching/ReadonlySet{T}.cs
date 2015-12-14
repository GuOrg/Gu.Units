namespace Gu.Units
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    [Serializable]
    internal class ReadonlySet<T> : IReadOnlyCollection<T>
    {
        public static readonly ReadonlySet<T> Empty = new ReadonlySet<T>(Enumerable.Empty<T>());

        private readonly ISet<T> source;

        public ReadonlySet(ISet<T> source)
        {
            this.source = source;
        }

        public ReadonlySet(IEnumerable<T> source)
        {
            this.source = new HashSet<T>(source);
        }

        public ReadonlySet(IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            this.source = new HashSet<T>(source, comparer);
        }

        public int Count => this.source?.Count ?? 0;

        public IEnumerator<T> GetEnumerator()
        {
            return this.source?.GetEnumerator() ??
                    Enumerable.Empty<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal bool IsEmpty => Count == 0;

        public static bool operator ==(ReadonlySet<T> left, ReadonlySet<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReadonlySet<T> left, ReadonlySet<T> right)
        {
            return !Equals(left, right);
        }

        public bool Contains(T item)
        {
            return this.source?.Contains(item) == true;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return this.source?.SetEquals(other) == true;
        }

        public bool Equals(ReadonlySet<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.source.SetEquals(other.source);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((ReadonlySet<T>)obj);
        }

        public override int GetHashCode()
        {
            if (this.source == null)
            {
                return 0;
            }
            unchecked
            {
                int hash = 0;
                foreach (var item in this.source)
                {
                    hash += item.GetHashCode();
                }

                return hash;
            }
        }
    }
}
