namespace Gu.Units
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    [Serializable]
    internal sealed class ReadonlySet<T> : IReadOnlyCollection<T>
         where T : notnull
    {
        internal static readonly ReadonlySet<T> Empty = new ReadonlySet<T>(Enumerable.Empty<T>());

        private readonly ISet<T> source;

        internal ReadonlySet(ISet<T> source)
        {
            this.source = source;
        }

        internal ReadonlySet(IEnumerable<T> source)
        {
            this.source = new HashSet<T>(source);
        }

        internal ReadonlySet(IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            this.source = new HashSet<T>(source, comparer);
        }

        public int Count => this.source?.Count ?? 0;

        internal bool IsEmpty => this.Count == 0;

        public static bool operator ==(ReadonlySet<T> left, ReadonlySet<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReadonlySet<T> left, ReadonlySet<T> right)
        {
            return !Equals(left, right);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.source?.GetEnumerator() ??
                   Enumerable.Empty<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(ReadonlySet<T>))
            {
                return false;
            }

            return this.Equals((ReadonlySet<T>)obj);
        }

        public override int GetHashCode()
        {
            if (this.source is null)
            {
                return 0;
            }

            unchecked
            {
                var hash = 0;
                foreach (var item in this.source)
                {
                    hash += item.GetHashCode();
                }

                return hash;
            }
        }

        internal bool Contains(T item)
        {
            return this.source?.Contains(item) == true;
        }

        internal bool SetEquals(IEnumerable<T> other)
        {
            return this.source?.SetEquals(other) == true;
        }

        internal bool Equals(ReadonlySet<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.source.SetEquals(other.source);
        }
    }
}
