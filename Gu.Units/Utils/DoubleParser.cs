namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Text;

    internal static class DoubleParser
    {
        private const NumberStyles InvalidNumberStyles = ~(NumberStyles.AllowLeadingWhite |
                                                           NumberStyles.AllowTrailingWhite |
                                                           NumberStyles.AllowLeadingSign |
                                                           NumberStyles.AllowTrailingSign |
                                                           NumberStyles.AllowParentheses |
                                                           NumberStyles.AllowDecimalPoint |
                                                           NumberStyles.AllowThousands |
                                                           NumberStyles.AllowExponent |
                                                           NumberStyles.AllowCurrencySymbol |
                                                           NumberStyles.AllowHexSpecifier);

        private const string LeadingSignNotAllowed = "Leading sign not allowed";
        private const string ExponentNotAllowed = "Exponent not allowed";
        private const string DecimalPointNotAllowed = "Decimal point not allowed";

        internal static double Parse(
            string s,
            int start,
            NumberStyles style,
            IFormatProvider provider,
            out int endPos)
        {
            if (!IsValidFloatingPointStyle(style))
            {
                throw new ArgumentException("Invalid NumberStyles", "style");
            }

            if (style.HasFlag(NumberStyles.AllowHexSpecifier))
            {
                throw new ArgumentException("Hex not supported", "style");
            }

            var pos = start;
            if (style.HasFlag(NumberStyles.AllowLeadingWhite))
            {
                ReadWhite(s, ref pos);
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            var format = NumberFormatInfo.GetInstance(provider);
            string read;
            if (TryRead(s, ref pos, format.NaNSymbol, out read))
            {
                endPos = pos;
                return double.NaN;
            }

            if (TryRead(s, ref pos, format.PositiveInfinitySymbol, out read))
            {
                endPos = pos;
                return double.PositiveInfinity;
            }

            if (TryRead(s, ref pos, format.NegativeInfinitySymbol, out read))
            {
                endPos = pos;
                return double.NegativeInfinity;
            }

            var sb = new StringBuilder();
            if (TryReadSign(s, ref pos, format, out read))
            {
                if (!style.HasFlag(NumberStyles.AllowLeadingSign))
                {
                    throw new FormatException(LeadingSignNotAllowed);
                }
                sb.Append(read);
            }

            ReadDigits(s, ref pos, sb);

            if (TryRead(s, ref pos, format.NumberDecimalSeparator, out read))
            {
                if (!style.HasFlag(NumberStyles.AllowDecimalPoint))
                {
                    throw new FormatException(DecimalPointNotAllowed);
                }
                sb.Append(read);
                ReadDigits(s, ref pos, sb);
            }

            string result;
            string exponent;
            if (TryReadExponent(s, ref pos, out exponent))
            {
                if (!style.HasFlag(NumberStyles.AllowExponent))
                {
                    throw new FormatException(ExponentNotAllowed);
                }
                sb.Append(exponent);
                string sign;
                if (TryReadSign(s, ref pos, format, out sign))
                {
                    sb.Append(sign);
                }

                if (ReadDigits(s, ref pos, sb))
                {
                    result = sb.ToString();
                }
                else
                {
                    var back = exponent.Length + sign.Length;
                    result = sb.ToString(0, sb.Length - back);
                    pos -= back;
                }
            }
            else
            {
                result = sb.ToString();
            }
            var d = double.Parse(result, style, provider);
            endPos = pos;
            return d;
        }

        internal static bool TryParse(
            string s,
            int start,
            NumberStyles style,
            IFormatProvider provider,
            out double value,
            out int endPos)
        {
            value = 0;
            endPos = start;
            if (s == null)
            {
                return false;
            }

            if (!IsValidFloatingPointStyle(style))
            {
                return false;
            }

            if (style.HasFlag(NumberStyles.AllowHexSpecifier))
            {
                return false;
            }

            var pos = start;
            if (style.HasFlag(NumberStyles.AllowLeadingWhite))
            {
                ReadWhite(s, ref pos);
            }

            if (char.IsWhiteSpace(s[pos]))
            {
                return false;
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            var format = NumberFormatInfo.GetInstance(provider);
            var read = string.Empty;
            if (TryRead(s, ref pos, format.NaNSymbol, out read))
            {
                endPos = pos;
                value = double.NaN;
                return true;
            }

            if (TryRead(s, ref pos, format.PositiveInfinitySymbol, out read))
            {
                endPos = pos;
                value = double.PositiveInfinity;
                return true;
            }

            if (TryRead(s, ref pos, format.NegativeInfinitySymbol, out read))
            {
                endPos = pos;
                value = double.NegativeInfinity;
                return true;
            }

            var sb = new StringBuilder();
            if (TryReadSign(s, ref pos, format, out read))
            {
                if (!style.HasFlag(NumberStyles.AllowLeadingSign))
                {
                    return false;
                }
                sb.Append(read);
            }


            ReadDigits(s, ref pos, sb);

            if (TryRead(s, ref pos, format.NumberDecimalSeparator, out read))
            {
                if (!style.HasFlag(NumberStyles.AllowDecimalPoint))
                {
                    return false;
                }
                sb.Append(read);
                ReadDigits(s, ref pos, sb);
            }

            string result;
            string exponent;
            if (TryReadExponent(s, ref pos, out exponent))
            {
                if (!style.HasFlag(NumberStyles.AllowExponent))
                {
                    return false;
                }
                sb.Append(exponent);
                string sign;
                if (TryReadSign(s, ref pos, format, out sign))
                {
                    sb.Append(sign);
                }

                if (ReadDigits(s, ref pos, sb))
                {
                    result = sb.ToString();
                }
                else
                {
                    var back = exponent.Length + sign.Length;
                    result = sb.ToString(0, sb.Length - back);
                    pos -= back;
                }
            }
            else
            {
                result = sb.ToString();
            }
            endPos = pos;
            return double.TryParse(result, style, provider, out value);
        }

        private static bool TryReadSign(string s,
            ref int pos,
            NumberFormatInfo format,
            out string read)
        {
            if (TryRead(s, ref pos, format.PositiveSign, out read))
            {
                return true;
            }

            if (TryRead(s, ref pos, format.NegativeSign, out read))
            {
                return true;
            }

            read = string.Empty;
            return false;
        }

        private static bool TryReadExponent(
            string s,
            ref int pos,
            out string read)
        {
            if (TryRead(s, ref pos, "E", out read))
            {
                return true;
            }

            if (TryRead(s, ref pos, "e", out read))
            {
                return true;
            }

            read = string.Empty;
            return false;
        }

        private static bool ReadDigits(string s, ref int pos, StringBuilder sb)
        {
            var start = pos;
            while (pos < s.Length && char.IsDigit(s[pos]))
            {
                sb.Append(s[pos]);
                pos++;
            }
            return pos != start;
        }

        private static bool TryRead(string s, ref int pos, string toRead, out string read)
        {
            read = null;
            if (pos == s.Length)
            {
                return false;
            }

            int start = pos;
            while (pos < s.Length && pos - start < toRead.Length)
            {
                if (s[pos] != toRead[pos - start])
                {
                    pos = start;
                    return false;
                }
                pos++;
            }

            read = toRead;
            return true;
        }

        private static void ReadWhite(string s, ref int pos)
        {
            while (pos < s.Length && Char.IsWhiteSpace(s[pos]))
            {
                pos++;
            }
        }

        private static bool IsValidFloatingPointStyle(NumberStyles style)
        {
            // Check for undefined flags
            return (style & InvalidNumberStyles) == 0;
        }
    }
}
