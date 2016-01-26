namespace Gu.Units.Wpf
{
    using System;
    using System.Collections.Generic;

    internal static class StringFormatParser<TUnit> where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        private static readonly Dictionary<string, QuantityFormat<TUnit>> Cache = new Dictionary<string, QuantityFormat<TUnit>>();

        internal static bool CanParseValueFormat(string format)
        {
            try
            {
                var text = 1.2.ToString(format);
                double temp;
                return double.TryParse(text, out temp);
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static void VerifyValueFormat(string format)
        {
            if (CanParseValueFormat(format))
            {
                return;
            }

            if (Is.DesignMode)
            {
                var message = CreateFormatErrorString(format, typeof(double));
                throw new FormatException(message);
            }
        }

        internal static void VerifyQuantityFormat(string format)
        {
            if (CanParseQuantityFormat(format))
            {
                return;
            }

            if (Is.DesignMode)
            {
                var message = CreateFormatErrorString(format, typeof (TUnit));
                throw new FormatException(message);
            }
        }

        internal static bool CanParseQuantityFormat(string format)
        {
            QuantityFormat<TUnit> result;
            return TryParse(format, out result);
        }

        internal static string CreateFormatErrorString(string format, Type type)
        {
            return $"Error parsing: '{format}' for {type}";
        }

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
            if (success)
            {
                Cache.Add(format, result);
            }

            return success;
        }

        private static bool TryReadPrefix(string format, ref int pos)
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

        private static bool TryReadChar(string format, ref int pos, char c)
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
