namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal static class Ensure
    {
        internal static void GreaterThan<T>(T value, T min, string parameterName)
            where T : IComparable<T>
        {
            Debug.Assert(!string.IsNullOrEmpty(parameterName), $"{nameof(parameterName)} cannot be null");
            if (Comparer<T>.Default.Compare(value, min) <= 0)
            {
                var message = $"Expected {parameterName} to be greater than {min}, {parameterName} was {value}";
                throw new ArgumentException(message, parameterName);
            }
        }
    }
}
