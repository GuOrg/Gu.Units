namespace Gu.Units
{
    using System;

    internal class StringMap<TItem>
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations
        private static readonly CachedItem[] Empty = new CachedItem[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
        private readonly object gate = new object();
        private CachedItem[] cache = Empty;

        internal bool TryGetBySubString(string text, int pos, out TItem result)
        {
            return this.TryGetBySubString(text, pos, out var _, out result);
        }

        internal bool TryGetBySubString(string text, int pos, out string key, out TItem result)
        {
            if (text is null)
            {
                key = null;
                result = default;
                return false;
            }

            var tempCache = this.cache;
            var index = BinaryFindSubstring(this.cache, text, pos);
            if (index < 0)
            {
                key = null;
                result = default;
                return false;
            }

            var match = tempCache[index];
            for (var i = index + 1; i < tempCache.Length; i++)
            {
                // searching linearly for longest match after finding one
                var temp = tempCache[i];
                if (Compare(temp.Key, text, pos) <= 0)
                {
                    match = temp;
                }
                else
                {
                    key = match.Key;
                    result = match.Value;
                    return true;
                }
            }

            key = match.Key;
            result = match.Value;
            return true;
        }

        internal bool TryGet(string key, out TItem match)
        {
            if (key is null)
            {
                match = default;
                return false;
            }

            var tempCache = this.cache;
            var index = BinaryFind(this.cache, key);
            if (index < 0)
            {
                match = default;
                return false;
            }

            match = tempCache[index].Value;
            return true;
        }

        internal CachedItem Add(string key, TItem item)
        {
            Ensure.NotNull(key, $"{nameof(item)}.{key}");
            //// this was five times faster than ReaderWriterLockSlim in benchmarks.
            lock (this.gate)
            {
                var i = BinaryFind(this.cache, key);
                if (i >= 0)
                {
                    var cachedItem = this.cache[i];
                    if (cachedItem.Key == key)
                    {
                        if (Equals(cachedItem.Value, item))
                        {
                            return cachedItem;
                        }

                        throw new InvalidOperationException("Cannot add same key with different values.\r\n" +
                                                            $"The key is {key} and the values are {{{item}, {cachedItem.Value}}}");
                    }
                }

                var updated = new CachedItem[this.cache.Length + 1];
                Array.Copy(this.cache, 0, updated, 0, this.cache.Length);
                var newItem = new CachedItem(key, item);
                updated[this.cache.Length] = newItem;
                Array.Sort(updated);
                this.cache = updated;
                return newItem;
            }
        }

        private static int BinaryFindSubstring(CachedItem[] cache, string key, int pos)
        {
            var lo = 0;
            var hi = cache.Length - 1;
            while (lo <= hi)
            {
                var i = (lo + hi) / 2;
                var cached = cache[i];
                var c = Compare(cached.Key, key, pos);
                if (c == 0)
                {
                    return i;
                }

                if (c < 0)
                {
                    lo = i + 1;
                }
                else
                {
                    hi = i - 1;
                }
            }

            return ~lo;
        }

        private static int BinaryFind(CachedItem[] cache, string key)
        {
            var lo = 0;
            var hi = cache.Length - 1;
            while (lo <= hi)
            {
                var i = (lo + hi) / 2;
                var cached = cache[i];
                var c = Compare(cached.Key, key);
                if (c == 0)
                {
                    return i;
                }

                if (c < 0)
                {
                    lo = i + 1;
                }
                else
                {
                    hi = i - 1;
                }
            }

            return ~lo;
        }

        private static int Compare(string cached, string key, int pos)
        {
            for (var i = 0; i < cached.Length; i++)
            {
                var j = i + pos;
                if (key.Length == j)
                {
                    return 1;
                }

                var compare = Invariant(cached[i]) - Invariant(key[j]);
                if (compare != 0)
                {
                    return compare;
                }
            }

            return 0;
        }

        private static char Invariant(char c)
        {
            return c switch
            {
                // use lowercase greek mu instead of micro.
                // http://www.fileformat.info/info/unicode/char/00b5/index.htm
                // http://www.fileformat.info/info/unicode/char/03BC/index.htm
                '\u00B5' => '\u03BC',

                // use lowercase greek mu instead of micro.
                // http://www.fileformat.info/info/unicode/char/2126/index.htm
                // http://www.fileformat.info/info/unicode/char/03a9/index.htm
                '\u2126' => '\u03A9',
                _ => c,
            };
        }

        private static int Compare(string cached, string key)
        {
            for (var i = 0; i < cached.Length; i++)
            {
                if (key.Length == i)
                {
                    return 1;
                }

                var compare = cached[i] - key[i];
                if (compare != 0)
                {
                    return compare;
                }
            }

            return cached.Length - key.Length;
        }

        internal readonly struct CachedItem : IComparable<CachedItem>
        {
            internal readonly string Key;
            internal readonly TItem Value;

            internal CachedItem(string key, TItem value)
            {
                this.Key = key;
                this.Value = value;
            }

            public int CompareTo(CachedItem other)
            {
                return Compare(this.Key, other.Key);
            }

            public override string ToString() => this.Key;
        }
    }
}