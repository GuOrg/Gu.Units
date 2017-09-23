namespace Gu.Units.Generator
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Conversion
    {
        public static Unit GetUnit(this IConversion conversion)
        {
            if (conversion is PartConversion.IdentityConversion identityConversion)
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
            //// ReSharper disable once CompareOfFloatsByEqualityOperator
            if (conversion.Factor == 1)
            {
                return parameter;
            }

            var intFactor = conversion.Factor.IntFactor();
            if (intFactor == 0)
            {
                return $"{conversion.Factor.ToString(CultureInfo.InvariantCulture)} * {parameter}";
            }

            if (intFactor < 0)
            {
                return $"{parameter} / {Math.Abs(intFactor)}";
            }

            return $"{intFactor} * {parameter}";
        }

        public static string GetFromSi(this IFactorConversion conversion)
        {
            var parameter = conversion.Unit.ParameterName;
            //// ReSharper disable once CompareOfFloatsByEqualityOperator
            if (conversion.Factor == 1)
            {
                return parameter;
            }

            var intFactor = conversion.Factor.IntFactor();
            if (intFactor == 0)
            {
                return $"{parameter} / {conversion.Factor.ToString(CultureInfo.InvariantCulture)}";
            }

            if (intFactor < 0)
            {
                return $"{Math.Abs(intFactor)} * {parameter}";
            }

            return $"{parameter} / {intFactor}";
        }

        public static async Task<string> GetSymbolConversionAsync(this IConversion conversion)
        {
            if (conversion.ToSi == null || conversion.Symbol == null)
            {
                return "Invalid";
            }

            try
            {
                var unit = conversion.Unit;
                var toSi = conversion.ToSi;
                var convert = await ConvertToSiAsync(1, conversion.ParameterName, toSi).ConfigureAwait(false);

                return $"1 {conversion.Symbol.NormalizeSymbol()} = {convert.ToString(CultureInfo.InvariantCulture)} {unit.Symbol.NormalizeSymbol()}";
            }
            catch (Exception)
            {
                return "Invalid";
            }
        }

        public static async Task<bool> CanRoundtripCoreAsync(this IConversion conversion)
        {
            try
            {
                var toSi = conversion.ToSi;
                var fromSi = conversion.FromSi;
                if (string.IsNullOrEmpty(toSi) ||
                    string.IsNullOrEmpty(fromSi))
                {
                    return false;
                }

                foreach (var value in new[] { 0, 100 })
                {
                    var si = await ConvertToSiAsync(value, conversion.ParameterName, toSi).ConfigureAwait(false);
                    var roundtrip = await ConvertFromSiAsync(si, conversion.Unit.ParameterName, fromSi).ConfigureAwait(false);
                    //// ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (roundtrip != value)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false; // lazy here only used in the code gen ui.
            }

            return true;
        }

        internal static Task<double> ConvertToSiAsync(double value, string parameter, string toSi)
        {
            return ExpressionParser.EvaluateAsync(value, parameter, toSi);
        }

        internal static Task<double> ConvertFromSiAsync(double value, string parameter, string fromSi)
        {
            return ExpressionParser.EvaluateAsync(value, parameter, fromSi);
        }

        private static long IntFactor(this double factor)
        {
            if (factor >= 1)
            {
                if (factor > 1E15)
                {
                    return 0;
                }

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (Math.Floor(factor) == factor)
                {
                    return (long)factor;
                }

                // this is an ad hoc mess
                var digits = 14 - (int)Math.Log10(factor);
                var round = Math.Round(factor, digits > 0 ? digits : 0);
                var integer = (long)round;
                //// ReSharper disable once CompareOfFloatsByEqualityOperator
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