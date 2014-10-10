namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class UnitParser
    {
        public const string UnitValuePattern = @"^(?: *)(?<Value>[+-]?\d+([eE][+-]\d+)?([.,]\d+)?) *(?<Unit>.+) *$";
        public const string DoublePattern = @"[+-]?\d+([eE][+-]\d+)?([.,]\d+)?";
        public static TValue Parse<TUnit, TValue>(string s, Func<double, TUnit, TValue> creator) 
            where TUnit : IUnit 
            where TValue : IUnitValue
        {
            Match match = Regex.Match(s, UnitValuePattern);
            double d = ParseDouble(match.Groups["Value"].Value);
            var unit = ParseUnit<TUnit>(match.Groups["Unit"].Value);
            return creator(d, (TUnit)unit);
        }

        public static TUnit ParseUnit<TUnit>(string s)
        {
            var trim = s.Trim();
            throw new NotImplementedException("message");
        }

        public static double ParseDouble(string s)
        {
            return double.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
    }
}