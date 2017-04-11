namespace Gu.Units
{
    using System;
    using System.Collections.Generic;

    internal static class UnitParser<TUnit> where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        internal static TUnit Parse(string text)
        {
            if (TryParse(text, out TUnit result))
            {
                return result;
            }

            var message = $"Could not parse: '{text}' to {typeof(TUnit).Name}";
            throw new FormatException(message);
        }

        internal static TUnit Parse(string text, ref int pos)
        {
            if (TryParse(text, ref pos, out TUnit result))
            {
                return result;
            }

            var message = $"Could not parse: '{text}' to {typeof(TUnit).Name}";
            throw new FormatException(message);
        }

        internal static bool TryParse(string text, out TUnit value)
        {
            var pos = 0;
            WhiteSpaceReader.TryRead(text, ref pos);
            return TryParse(text, ref pos, out value) &&
                   WhiteSpaceReader.IsRestWhiteSpace(text, pos);
        }

        internal static bool TryParse(string text, ref int pos, out TUnit result)
        {
            var start = pos;
            if (UnitFormatCache<TUnit>.Cache.TryGetUnitForSymbol(text, ref pos, out result))
            {
                return true;
            }

            if (SymbolAndPowerReader.TryRead(text, ref pos, out IReadOnlyList<SymbolAndPower> symbolsAndPowers))
            {
                var symbol = text.Substring(start, pos - start);

                WhiteSpaceReader.TryRead(text, ref pos, out string postPadding);
                if (!IsEndOfSymbol(text, pos))
                {
                    result = Unit<TUnit>.Default;
                    return false;
                }


                if (UnitFormatCache<TUnit>.Cache.TryGetUnitForParts(symbolsAndPowers, out result))
                {
                    UnitFormatCache<TUnit>.Cache.Add(symbol, symbolsAndPowers);
                    UnitFormatCache<TUnit>.Cache.Add(symbol, result);
                    return true;
                }
            }

            pos = start;
            result = Unit<TUnit>.Default;
            return false;
        }

        private static bool IsEndOfSymbol(string text, int pos)
        {
            if (pos == text.Length)
            {
                return true;
            }

            return text[pos] == '}' || WhiteSpaceReader.IsRestWhiteSpace(text, pos);
        }
    }
}