namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Policy;

    internal static class SymbolAndPowerReader
    {
        internal static SymbolAndPower Read(string text, ref int pos)
        {
            if (pos == text.Length)
            {
                throw new FormatException($"Expected symbol or operator. {text} position: end");
            }

            SymbolAndPower result;
            if (TryRead(text, ref pos, out result))
            {
                return result;
            }

            throw new FormatException($"No symbol found at {pos} in {text}");
        }

        internal static bool TryRead(string text, out IReadOnlyList<SymbolAndPower> result)
        {
            var pos = 0;
            var success = TryRead(text, ref pos, out result);
            return success && WhiteSpaceReader.IsRestWhiteSpace(text, pos);
        }

        internal static bool TryRead(string text, ref int pos, out IReadOnlyList<SymbolAndPower> result)
        {
            int start = pos;
            var sign = Sign.Positive;
            List<SymbolAndPower> saps = null;
            while (pos < text.Length)
            {
                WhiteSpaceReader.TryRead(text, ref pos);

                SymbolAndPower sap;
                if (!TryRead(text, ref pos, out sap))
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

                if (saps == null)
                {
                    saps = new List<SymbolAndPower>();
                }

                saps.Add(sap);

                var op = OperatorReader.TryReadMultiplyOrDivide(text, ref pos);
                if (op != MultiplyOrDivide.None)
                {
                    WhiteSpaceReader.TryRead(text, ref pos);
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

            if (saps == null || !IsUnique(saps))
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
                result = default(SymbolAndPower);
                return false;
            }

            var start = pos;
            while (text.Length > pos && IsSymbol(text[pos]))
            {
                pos++;
            }

            if (pos == start)
            {
                result = default(SymbolAndPower);
                return false;
            }

            var symbol = text.Substring(start, pos - start);
            WhiteSpaceReader.TryRead(text, ref pos);
            int power;
            if (!PowerReader.TryRead(text, ref pos, out power))
            {
                pos = start;
                result = default(SymbolAndPower);
                return false;
            }

            if (power == 0 || Math.Abs(power) > 5) // 5 > is most likely a typo right?
            {
                pos = start;
                result = default(SymbolAndPower);
                return false;
            }

            result = new SymbolAndPower(symbol, power);
            return true;
        }

        private static bool IsSymbol(char c)
        {
            if (c == '°' || c == '‰' || c == '%')
            {
                return true;
            }

            return char.IsLetter(c);
        }

        private static bool IsUnique(IEnumerable<SymbolAndPower> saps)
        {
            var unique = saps.Select(x => x.Symbol).Distinct().Count();
            return unique == saps.Count();
        }
    }
}
