namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    internal static class SymbolAndPowerReader
    {
        internal static SymbolAndPower Read(string text, ref int pos)
        {
            if (pos == text.Length)
            {
                throw new FormatException($"Expected symbol or operator. {text} position: end");
            }

            if (TryRead(text, ref pos, out SymbolAndPower result))
            {
                return result;
            }

            throw new FormatException($"No symbol found at {pos} in {text}");
        }

        internal static bool TryRead(string text, [NotNullWhen(true)] out IReadOnlyList<SymbolAndPower>? result)
        {
            var pos = 0;
            var success = TryRead(text, ref pos, out result);
#pragma warning disable CS8762 // Parameter must have a non-null value when exiting in some condition.
            return success && WhiteSpaceReader.IsRestWhiteSpace(text, pos);
#pragma warning restore CS8762 // Parameter must have a non-null value when exiting in some condition.
        }

        internal static bool TryRead(string text, ref int pos, [NotNullWhen(true)] out IReadOnlyList<SymbolAndPower>? result)
        {
            var start = pos;
            var sign = Sign.Positive;
            List<SymbolAndPower>? saps = null;
            while (pos < text.Length)
            {
                _ = WhiteSpaceReader.TryRead(text, ref pos);
                if (!TryRead(text, ref pos, out SymbolAndPower sap))
                {
                    pos = start;
                    result = null;
                    return false;
                }

                if (sap.Power < 0 &&
                    sign == Sign.Negative)
                {
                    pos = start;
                    result = null;
                    return false;
                }

                if (sign == Sign.Negative)
                {
                    sap = new SymbolAndPower(sap.Symbol, -1 * sap.Power);
                }

                if (saps is null)
                {
                    saps = new List<SymbolAndPower>();
                }

                saps.Add(sap);

                var op = OperatorReader.TryReadMultiplyOrDivide(text, ref pos);
                if (op != MultiplyOrDivide.None)
                {
                    _ = WhiteSpaceReader.TryRead(text, ref pos);
                    if (OperatorReader.TryReadMultiplyOrDivide(text, ref pos) != MultiplyOrDivide.None)
                    {
                        pos = start;
                        result = null;
                        return false;
                    }

                    if (op == MultiplyOrDivide.Division)
                    {
                        if (sign == Sign.Negative)
                        {
                            pos = start;
                            result = null;
                            return false;
                        }

                        sign = Sign.Negative;
                    }
                }
            }

            if (saps is null || !IsUnique(saps))
            {
                result = null;
                return false;
            }

            result = saps;
            return true;
        }

        internal static bool TryRead(string text, ref int pos, out SymbolAndPower result)
        {
            if (pos == text.Length)
            {
                result = default;
                return false;
            }

            var start = pos;
            while (text.Length > pos && IsSymbol(text[pos]))
            {
                pos++;
            }

            if (pos == start)
            {
                result = default;
                return false;
            }

            var symbol = text.Substring(start, pos - start);
            _ = WhiteSpaceReader.TryRead(text, ref pos);
            if (!PowerReader.TryRead(text, ref pos, out var power))
            {
                pos = start;
                result = default;
                return false;
            }

            // 5 > is most likely a typo right?
            if (power == 0 || Math.Abs(power) > 5)
            {
                pos = start;
                result = default;
                return false;
            }

            result = new SymbolAndPower(symbol, power);
            return true;
        }

        private static bool IsSymbol(char c)
        {
            if (c == '\u00B0' || c == '‰' || c == '%')
            {
                return true;
            }

            return char.IsLetter(c);
        }

        private static bool IsUnique(IReadOnlyCollection<SymbolAndPower> saps)
        {
            var unique = saps.Select(x => x.Symbol).Distinct().Count();
            return unique == saps.Count;
        }
    }
}
