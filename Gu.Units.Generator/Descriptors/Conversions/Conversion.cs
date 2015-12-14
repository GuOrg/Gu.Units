namespace Gu.Units.Generator
{
    using System;
    using System.CodeDom.Compiler;
    using System.Globalization;
    using System.Linq;

    public static class Conversion
    {
        private static readonly CodeDomProvider CodeDomProvider = CodeDomProvider.CreateProvider("C#");

        public static Unit GetUnit(this IConversion conversion)
        {
            var identityConversion = conversion as PartConversion.IdentityConversion;
            if (identityConversion != null)
            {
                var unit = Settings.Instance.AllUnits.Single(x => x.Symbol == identityConversion.Symbol);
                return unit;
            }

            foreach (var unit in Settings.Instance.AllUnits)
            {
                if (unit.AllConversions.Any(pc => pc == conversion))
                {
                    return unit;
                }
            }

            throw new ArgumentOutOfRangeException($"Could not find a unit matching symbol {conversion.Symbol} for conversion {conversion.Name}");
        }

        public static string GetToSi(this IFactorConversion conversion)
        {
            var parameter = conversion.ParameterName;
            if (conversion.Factor == 1)
            {
                return parameter;
            }

            var intFactor = conversion.Factor.IntFactor();
            if (intFactor == 0)
            {
                return $"{conversion.Factor.ToString(CultureInfo.InvariantCulture)}*{parameter}";
            }

            if (intFactor < 0)
            {
                return $"{parameter}/{Math.Abs(intFactor)}";
            }

            return $"{intFactor}*{parameter}";
        }

        public static string GetFromSi(this IFactorConversion conversion)
        {
            var parameter = conversion.Unit.ParameterName;

            if (conversion.Factor == 1)
            {
                return parameter;
            }

            var intFactor = conversion.Factor.IntFactor();
            if (intFactor == 0)
            {
                return $"{parameter}/{conversion.Factor.ToString(CultureInfo.InvariantCulture)}";
            }

            if (intFactor < 0)
            {
                return $"{Math.Abs(intFactor)}*{parameter}";
            }

            return $"{parameter}/{intFactor}";
        }

        public static string GetSymbolConversion(this IConversion conversion)
        {
            var unit = conversion.Unit;
            var toSi = conversion.ToSi;
            var convert = ConvertToSi(1, conversion.ParameterName, toSi);

            return $"1 {conversion.Symbol.NormalizeSymbol()} = {convert.ToString(CultureInfo.InvariantCulture)} {unit.Symbol.NormalizeSymbol()}";
        }

        public static bool CanRoundtrip(this IConversion conversion)
        {
            var toSi = conversion.ToSi;
            var fromSi = conversion.FromSi;
            foreach (var value in new[] { 0, 100 })
            {
                var si = ConvertToSi(value, conversion.ParameterName, toSi);
                var roundtrip = ConvertFromSi(si, conversion.Unit.ParameterName, fromSi);
                if (roundtrip != value)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsSymbolNameValid(this IConversion conversion) => CodeDomProvider.IsValidIdentifier(conversion.Symbol);

        internal static double ConvertToSi(double value, string parameter, string toSi)
        {
            var result = ExpressionParser.Evaluate(value, parameter, toSi);
            return result;
        }

        internal static double ConvertFromSi(double value, string parameter, string fromSi)
        {
            var result = ExpressionParser.Evaluate(value, parameter, fromSi);
            return result;
        }

        private static long IntFactor(this double factor)
        {
            if (factor >= 1)
            {
                if (factor > 1E15)
                {
                    return 0;
                }
                if (Math.Floor(factor) == factor)
                {
                    return (long)factor;
                }

                // this is an ad hoc mess
                var digits = 14 - (int)Math.Log10(factor);
                var round = Math.Round(factor, digits > 0 ? digits : 0);
                var integer = (long)round;
                if (round == integer)
                {
                    return integer;
                }

                return 0;
            }

            return -IntFactor(1 / factor);
        }
    }
}