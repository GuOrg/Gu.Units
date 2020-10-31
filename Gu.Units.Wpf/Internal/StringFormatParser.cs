namespace Gu.Units.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    internal static class StringFormatParser<TUnit>
        where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        private static readonly Dictionary<string, QuantityFormat<TUnit>> Cache = new Dictionary<string, QuantityFormat<TUnit>>();

        internal static bool CanParseValueFormat(string? format)
        {
            try
            {
                var text = 1.2.ToString(format, CultureInfo.InvariantCulture);
                return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var _);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return false;
            }
        }

        internal static void VerifyValueFormat(string? format)
        {
            if (CanParseValueFormat(format))
            {
                return;
            }

            if (Is.DesignMode)
            {
                var message = CreateFormatErrorString(format ?? "null", typeof(double));
                throw new FormatException(message);
            }
        }

        internal static void VerifyQuantityFormat(string? format)
        {
            if (CanParseQuantityFormat(format))
            {
                return;
            }

            if (Is.DesignMode)
            {
                var message = CreateFormatErrorString(format ?? "null", typeof(TUnit));
                throw new FormatException(message);
            }
        }

        internal static bool CanParseQuantityFormat(string? format)
        {
            return TryParse(format, out var _);
        }

        internal static string CreateFormatErrorString(string? format, Type type)
        {
            return $"Error parsing: '{format ?? "null"}' for {type}";
        }

        internal static bool TryParse(string? format, [MaybeNullWhen(false)] out QuantityFormat<TUnit> result)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                result = QuantityFormat<TUnit>.CreateUnknown("{nameof(format) is null}", Unit<TUnit>.Default);
                return false;
            }

            if (Cache.TryGetValue(format, out result))
            {
                return true;
            }

            var pos = 0;
            _ = WhiteSpaceReader.TryRead(format, ref pos);
            var end = format.Length;
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
