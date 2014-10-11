namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Parser
    {
        public static readonly string DoublePattern = @"[+-]?\d*(?:[.,]\d+)?(?:[eE][+-]?\d+)?";
        public static readonly string UnitValuePattern = string.Format(@"^(?: *)(?<Value>{0}) *(?<Unit>.+) *$", DoublePattern);
        private static readonly ConcurrentDictionary<Type, IUnit[]> Symbols = new ConcurrentDictionary<Type, IUnit[]>();
        public static TValue Parse<TUnit, TValue>(string s, Func<double, TUnit, TValue> creator, IFormatProvider provider = null)
            where TUnit : IUnit
            where TValue : IUnitValue
        {
            if (provider == null)
            {
                provider = CultureInfo.InvariantCulture;
            }
            Match match = Regex.Match(s, UnitValuePattern);
            double d = ParseDouble(match.Groups["Value"].Value, provider);
            var unit = ParseUnit<TUnit>(match.Groups["Unit"].Value);
            return creator(d, unit);
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
            var unitTypes = t.Assembly.GetTypes().Where(x => x.IsValueType && x.GetInterfaces().Any(i => i == t));
            return unitTypes.Select(x => (IUnit)Activator.CreateInstance(x)).ToArray();
        }
    }
}