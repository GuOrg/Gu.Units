namespace Gu.Units
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal static partial class Ensure
    {
        internal static void NotNullOrEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            Debug.Assert(!string.IsNullOrEmpty(parameterName), $"{nameof(parameterName)} cannot be null");
            Ensure.NotNull(value, parameterName);

            if (!value.Any())
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        internal static void MinCount(ICollection value, int min, string parameterName)
        {
            Debug.Assert(!string.IsNullOrEmpty(parameterName), $"{nameof(parameterName)} cannot be null");
            Ensure.NotNull(value, parameterName);

            if (value.Count < min)
            {
                var message = $"Expected {nameof(value)}.{nameof(value.Count)} to be at least {min}";
                throw new ArgumentException(parameterName, message);
            }
        }

        internal static void MaxCount(ICollection value, int max, string parameterName)
        {
            Debug.Assert(!string.IsNullOrEmpty(parameterName), $"{nameof(parameterName)} cannot be null");
            Ensure.NotNull(value, parameterName);

            if (value.Count > max)
            {
                var message = $"Expected {nameof(value)}.{nameof(value.Count)} to be less than {max}";
                throw new ArgumentException(parameterName, message);
            }
        }

        internal static void Distinct<T>(IEnumerable<T> value, string parameterName)
        {
            Debug.Assert(!string.IsNullOrEmpty(parameterName), $"{nameof(parameterName)} cannot be null");
            Ensure.NotNull(value, parameterName);

            if (value.Distinct().Count() != value.Count())
            {
                var message = $"Expected {nameof(value)} to be have only distinct entries";
                throw new ArgumentException(parameterName, message);
            }
        }

        internal static void Distinct<T>(IEnumerable<T> value, Func<T, object> selector, string parameterName)
        {
            Debug.Assert(!string.IsNullOrEmpty(parameterName), $"{nameof(parameterName)} cannot be null");
            Ensure.NotNull(value, parameterName);

            if (value.Select(selector).Distinct().Count() != value.Count())
            {
                var message = $"Expected {nameof(value)} to be have only distinct entries";
                throw new ArgumentException(parameterName, message);
            }
        }
    }
}
