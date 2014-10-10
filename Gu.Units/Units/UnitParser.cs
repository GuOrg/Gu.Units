namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static class UnitParser
    {
        public const string UnitValuePattern = @"^(?: *)(?<Value>[+-]?\d+([eE][+-]\d+)?([.,]\d+)?) *(?<Unit>.+) *$";
        public const string DoublePattern = @"[+-]?\d+([eE][+-]\d+)?([.,]\d+)?";
        private static readonly ConcurrentDictionary<Type, string> Symbols = new ConcurrentDictionary<Type, string>();
        public static TValue Parse<TUnit, TValue>(string s, Func<double, TUnit, TValue> creator)
            where TUnit : IUnit
            where TValue : IUnitValue
        {
            Match match = Regex.Match(s, UnitValuePattern);
            double d = ParseDouble(match.Groups["Value"].Value);
            var unit = ParseUnit<TUnit>(match.Groups["Unit"].Value);
            return creator(d, unit);
        }

        public static TUnit ParseUnit<TUnit>(string s)
        {
            var trim = s.Trim();
            var type = typeof(TUnit);
            var symbol = Symbols.GetOrAdd(type, t => t.Symbol());
            throw new NotImplementedException("message");
        }

        public static double ParseDouble(string s)
        {
            return double.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        private static string Symbol(this Type t)
        {
            throw new NotImplementedException("message");
        }
     }
}