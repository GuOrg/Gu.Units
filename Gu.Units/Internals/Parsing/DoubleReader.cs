namespace Gu.Units
{
    using System;
    using System.Globalization;

    internal static class DoubleReader
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

        internal static double Read(
            string text,
            ref int pos,
            NumberStyles style,
            IFormatProvider provider)
        {
            if (!IsValidFloatingPointStyle(style))
            {
                throw new ArgumentException("Invalid NumberStyles", nameof(style));
            }

            if ((style & NumberStyles.AllowHexSpecifier) != 0)
            {
                throw new ArgumentException("Hex not supported", nameof(style));
            }

            double result;
            if (TryRead(text, ref pos, style, provider, out result))
            {
                return result;
            }

            var message = $"Expected to find a double starting at index {pos}\r\n" +
                          $"String: {text}\r\n" +
                          $"        {new string(' ', pos)}^";
            throw new FormatException(message);
        }

        internal static bool TryRead(
            string text,
            ref int pos,
            NumberStyles style,
            IFormatProvider provider,
            out double result)
        {
            result = 0;
            var start = pos;
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (!IsValidFloatingPointStyle(style))
            {
                return false;
            }

            if ((style & NumberStyles.AllowHexSpecifier) != 0)
            {
                return false;
            }

            if ((style & NumberStyles.AllowLeadingWhite) != 0)
            {
                WhiteSpaceReader.TryRead(text, ref pos);
            }

            if (char.IsWhiteSpace(text[pos]))
            {
                return false;
            }

            if (TrySkipDoubleDigits(text, ref pos, style, provider))
            {
                return TryParseSubString(text, start, ref pos, style, provider, out result);
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            var format = NumberFormatInfo.GetInstance(provider);
            if (Skipper.TrySkip(text, ref pos, format.NaNSymbol))
            {
                result = double.NaN;
                return true;
            }

            if (Skipper.TrySkip(text, ref pos, format.PositiveInfinitySymbol))
            {
                result = double.PositiveInfinity;
                return true;
            }

            if (Skipper.TrySkip(text, ref pos, format.NegativeInfinitySymbol))
            {
                result = double.NegativeInfinity;
                return true;
            }

            pos = start;
            return false;
        }

        // Try parse a double from digits ignoring +-Inf and NaN
        private static bool TrySkipDoubleDigits(
            string text,
            ref int pos,
            NumberStyles style,
            IFormatProvider provider)
        {
            var start = pos;
            var format = NumberFormatInfo.GetInstance(provider);
            Sign sign;
            if (TryReadSign(text, ref pos, format, out sign))
            {
                if ((style & NumberStyles.AllowLeadingSign) == 0)
                {
                    pos = start;
                    return false;
                }
            }

            if (!TrySkipIntegerDigits(text, ref pos, style, format))
            {
                pos = start;
                return false;
            }

            if (Skipper.TrySkip(text, ref pos, format.NumberDecimalSeparator))
            {
                if ((style & NumberStyles.AllowDecimalPoint) == 0)
                {
                    pos = start;
                    return false;
                }

                TrySkipFractionDigits(text, ref pos);
            }

            if (TrySkipExponent(text, ref pos))
            {
                if ((style & NumberStyles.AllowExponent) == 0)
                {
                    pos = start;
                    return false;
                }
                Sign exponentSign;
                TryReadSign(text, ref pos, format, out exponentSign);
                if (TrySkipExponentDigits(text, ref pos))
                {
                    return true;
                }

                // This is a tricky spot we read digits followed by (sign) exponent 
                // then no digits were thrown. I choose to return the double here.
                // Both alternatives will be wrong in some situations.
                // returning false here would make it impossible to parse 1.2eV
                var backStep = exponentSign == Sign.None
                    ? 1
                    : 2;
                pos -= backStep;
                return true;
            }

            return true;
        }

        private static bool TryParseSubString(
            string text,
            int start,
            ref int end,
            NumberStyles style,
            IFormatProvider provider,
            out double result)
        {
            var s = text.Substring(start, end - start);
            var success = double.TryParse(s, style, provider, out result);
            if (!success)
            {
                end = start;
            }
            return success;
        }

        private static bool TryReadSign(string text,
            ref int pos,
            NumberFormatInfo format,
            out Sign sign)
        {
            if (Skipper.TrySkip(text, ref pos, format.PositiveSign))
            {
                sign = Sign.Positive;
                return true;
            }

            if (Skipper.TrySkip(text, ref pos, format.NegativeSign))
            {
                sign = Sign.Negative;
                return true;
            }

            sign = Sign.None;
            return false;
        }

        private static bool TrySkipExponent(
            string text,
            ref int pos)
        {
            if (Skipper.TrySkip(text, ref pos, 'E'))
            {
                return true;
            }

            if (Skipper.TrySkip(text, ref pos, "e"))
            {
                return true;
            }

            return false;
        }

        private static bool TrySkipIntegerDigits(string text, ref int pos, NumberStyles styles, NumberFormatInfo format)
        {
            if (pos == text.Length)
            {
                return false;
            }

            var start = pos;
            if (format?.NumberDecimalSeparator != null &&
                Skipper.TrySkip(text, ref pos, format.NumberDecimalSeparator))
            {
                if (!IntReader.IsDigit(text, pos))
                {
                    pos = start;
                    return false;
                }

                pos = start;
                return true;
            }

            if (!IntReader.IsDigit(text[pos]))
            {
                return false;
            }

            while (pos < text.Length)
            {
                var i = text[pos] - '0';
                if (0 <= i && i <= 9)
                {
                    pos++;
                    continue;
                }

                if ((styles & NumberStyles.AllowThousands) != 0)
                {
                    if (format?.NumberDecimalSeparator != null &&
                        Skipper.TrySkip(text, ref pos, format.NumberGroupSeparator))
                    {
                        continue;
                    }
                }

                break;
            }

            return pos - start < 310;
        }

        private static bool TrySkipFractionDigits(string text, ref int pos)
        {
            return IntReader.TrySkipDigits(text, ref pos);
        }

        private static bool TrySkipExponentDigits(string text, ref int pos)
        {
            return IntReader.TrySkipDigits(text, ref pos);
        }

        private static bool IsValidFloatingPointStyle(NumberStyles style)
        {
            // Check for undefined flags
            return (style & InvalidNumberStyles) == 0;
        }
    }
}
