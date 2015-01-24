namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static partial class Enumerable
    {
        public static Length Sum(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.Metres;
                }
            }
            return Length.FromMetres(sum);
        }

        public static Length? Sum(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metres;
                    }
                }
            }
            return Length.FromMetres(sum);
        }

        public static Length Min(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Length);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.SiValue))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.SiValue < value.SiValue)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Length? Min(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Length? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.SiValue))
                {
                    return x;
                }
                if (value == null || x.Value.SiValue < value.Value.SiValue)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Length Max(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Length value = default(Length);
            bool hasValue = false;
            foreach (Length x in source)
            {
                if (System.Double.IsNaN(x.SiValue))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.SiValue > value.SiValue)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Length? Max(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Length? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.SiValue))
                {
                    return x;
                }
                if (value == null || x.Value.SiValue > value.Value.SiValue || System.Double.IsNaN(x.Value.SiValue))
                {
                    value = x;
                }
            }
            return value;
        }

        public static Length Average(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metres;
                    count++;
                }
            }
            if (count > 0)
            {
                return Length.FromMetres(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Length? Average(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metres;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Length.FromMetres(sum / count);
            }
            return null;
        }
    }
}
