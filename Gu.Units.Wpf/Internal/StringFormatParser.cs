namespace Gu.Units.Wpf
{
    using System;
    using System.Collections.Generic;

    internal static class StringFormatParser<TUnit> where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        private static readonly Dictionary<string, QuantityFormat<TUnit>> Cache = new Dictionary<string, QuantityFormat<TUnit>>();

        internal static bool TryParse(string format, out QuantityFormat<TUnit> result)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                result = QuantityFormat<TUnit>.CreateUnknown($"{nameof(format) == null}", Unit<TUnit>.Default);
                return false;
            }

            if (Cache.TryGetValue(format, out result))
            {
                return true;
            }

            int pos = 0;
            WhiteSpaceReader.TryRead(format, ref pos);
            int end = format.Length;
            if (TryReadPrefix(format, ref pos))
            {
                end = format.LastIndexOf('}');
                if (end < 0)
                {
                    result = QuantityFormat<TUnit>.CreateUnknown(format, Unit<TUnit>.Default);
                    return false;
                }

                if (!WhiteSpaceReader.IsRestWhiteSpace(format, end + 1))
                {
                    result = QuantityFormat<TUnit>.CreateUnknown(format, Unit<TUnit>.Default);
                    return false;
                }
            }

            var trimmedFormat = pos != end
                ? format.Substring(pos, end - pos)
                : format;
            var success = CompositeFormatParser.TryParse(trimmedFormat, out result);
            Cache.Add(format, result);
            return success;
        }

        private static bool TryReadPrefix(string format,
            ref int pos)
        {
            var start = pos;

            if (!TryReadChar(format, ref pos, '{'))
            {
                return false;
            }

            if (TryReadChar(format, ref pos, '0'))
            {
                if (!TryReadChar(format, ref pos, ':'))
                {
                    pos = start;
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadChar(string format,
            ref int pos,
            char c)
        {
            var start = pos;
            if (format[pos] != c)
            {
                pos = start;
                return false;
            }
            pos++;
            return true;
        }
    }
}
