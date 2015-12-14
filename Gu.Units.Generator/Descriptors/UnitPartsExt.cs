namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class UnitPartsExt
    {
        public static string AsSymbol(this IEnumerable<UnitAndPower> unitAndPowers)
        {
            return unitAndPowers.Select(x => new SymbolAndPower(x.Unit.Symbol, x.Power))
                                .ToList()
                                .AsSymbol();
        }

        public static string AsSymbol(this IReadOnlyList<UnitAndPower> unitAndPowers)
        {
            return unitAndPowers.Select(x => new SymbolAndPower(x.Unit.Symbol, x.Power))
                      .ToList()
                      .AsSymbol();
        }

        internal static string AsSymbol(this IEnumerable<SymbolAndPower> symbolAndPowers)
        {
            return symbolAndPowers.ToList()
                                .AsSymbol();
        }

        internal static string AsSymbol(this IReadOnlyList<SymbolAndPower> symbolAndPowers)
        {
            if (!symbolAndPowers.Any())
            {
                return "";
            }

            var sb = new StringBuilder();
            var sorted = symbolAndPowers.OrderBy(x => x, BaseUnitOrderComparer.Default).ToArray();
            for (int i = 0; i < sorted.Length; i++)
            {
                var unitAndPower = sorted[i];
                if (i > 0)
                {
                    if (sorted[i - 1].Power > 0 &&
                        sorted[i].Power < 0)
                    {
                        sb.Append("/");
                    }
                    else
                    {
                        sb.Append("⋅");
                    }
                }

                sb.Append(unitAndPower.Symbol);
                if (unitAndPower.Power < 0 && sorted[0].Power < 0)
                {
                    sb.Append("⁻");
                    if (unitAndPower.Power == -1)
                    {
                        sb.Append("¹");
                    }
                }

                switch (Math.Abs(unitAndPower.Power))
                {
                    case 1:
                        break;
                    case 2:
                        sb.Append("²");
                        break;
                    case 3:
                        sb.Append("³");
                        break;
                    case 4:
                        sb.Append("⁴");
                        break;
                    default:
                        sb.Append("^")
                            .Append(Math.Abs(unitAndPower.Power));
                        break;
                }
            }
            return sb.ToString();
        }

        internal static string NormalizeSymbol(this string symbol)
        {
            IReadOnlyList<SymbolAndPower> symbolAndPowers;
            if (SymbolAndPowerReader.TryRead(symbol, out symbolAndPowers))
            {
                return symbolAndPowers.AsSymbol();
            }
            return $"Failed normalizing {symbol}";
        }

        public class BaseUnitOrderComparer : IComparer<SymbolAndPower>
        {
            public static readonly BaseUnitOrderComparer Default = new BaseUnitOrderComparer();
            private static readonly string[] Order = { "kg", "m", "s", "A", "cd", "mol" };

            private BaseUnitOrderComparer()
            {
            }

            int IComparer<SymbolAndPower>.Compare(SymbolAndPower x, SymbolAndPower y)
            {
                if (Math.Sign(x.Power) != Math.Sign(y.Power))
                {
                    return -1 * x.Power.CompareTo(y.Power);
                }

                var indexOfX = Array.IndexOf(Order, x.Symbol);
                var indexOfY = Array.IndexOf(Order, y.Symbol);
                if (indexOfX < 0 && indexOfY < 0)
                {
                    return String.Compare(x.Symbol, y.Symbol, StringComparison.Ordinal);
                }

                return indexOfX.CompareTo(indexOfY);
            }
        }
    }
}