namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Parser
    {
        public static readonly string DoublePointPattern = @"[+-]?\d*(?:.\d+)?(?:[eE][+-]?\d+)?";
        public static readonly string DoubleCommaPattern = @"[+-]?\d*(?:,\d+)?(?:[eE][+-]?\d+)?"; // not super nice :)
        public static readonly string UnitValuePointPattern = string.Format(@"^(?: *)(?<Value>{0}) *(?<Unit>.+) *$", DoublePointPattern);
        public static readonly string UnitValueCommaPattern = string.Format(@"^(?: *)(?<Value>{0}) *(?<Unit>.+) *$", DoubleCommaPattern);
        private static readonly ConcurrentDictionary<Type, IUnit[]> Symbols = new ConcurrentDictionary<Type, IUnit[]>();
        public static TValue Parse<TUnit, TValue>(string s, Func<double, TUnit, TValue> creator, IFormatProvider provider = null)
            where TUnit : IUnit
            where TValue : IQuantity
        {
            if (provider == null)
            {
                provider = CultureInfo.InvariantCulture;
            }
            try
            {
                var format = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo));
                var separator = format.NumberDecimalSeparator;
                Match match;
                if (separator == ".")
                {
                    if (s.IndexOf(',') >= 0)
                    {
                        throw new ArgumentException("The given string does not match the culture");
                    }
                    match = Regex.Match(s, UnitValuePointPattern);
                }
                else if (separator == ",")
                {
                    if (s.IndexOf('.') >= 0)
                    {
                        throw new ArgumentException("The given string does not match the culture");
                    }
                    match = Regex.Match(s, UnitValuePointPattern);
                }
                else
                {
                    throw new ArgumentException("Cannot format the given culture", "provider");
                }
                double d = ParseDouble(match.Groups["Value"].Value, provider);
                var unit = ParseUnit<TUnit>(match.Groups["Unit"].Value);
                return creator(d, unit);
            }
            catch (Exception e)
            {
                throw new FormatException("Could not parse the unit value from: " + s, e);
            }
        }

        public static TUnit ParseUnit<TUnit>(string s)
        {
            var trim = s.Trim();
            var type = typeof(TUnit);
            var symbols = Symbols.GetOrAdd(type, t => t.Symbol());
            return (TUnit)symbols.Single(x => x.Symbol == trim);
        }

        public static double ParseDouble(string s, IFormatProvider provider)
        {
            return double.Parse(s, provider);
        }

        private static IUnit[] Symbol(this Type t)
        {
            var units = t.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static)
                              .Where(f => typeof(IUnit).IsAssignableFrom(f.FieldType))
                              .Select(f => (IUnit)f.GetValue(null))
                              .Distinct()
                              .ToArray();
            return units;
        }
    }
}