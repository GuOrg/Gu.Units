namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Parser
    {
        public static readonly string DoublePointPattern = @"[+-]?\d*(?:.\d+)?(?:[eE][+-]?\d+)?";
        public static readonly string DoubleCommaPattern = @"[+-]?\d*(?:,\d+)?(?:[eE][+-]?\d+)?"; // not super nice :)
        public static readonly string UnitValuePointPattern = string.Format(@"^(?: *)(?<Value>{0}) *(?<Unit>.+) *$", DoublePointPattern);
        public static readonly string UnitValueCommaPattern = string.Format(@"^(?: *)(?<Value>{0}) *(?<Unit>.+) *$", DoubleCommaPattern);
        private static readonly ConcurrentDictionary<Type, Symbol[]> SymbolCache = new ConcurrentDictionary<Type, Symbol[]>();

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
                var d = ParseDouble(match.Groups["Value"].Value, provider);
                var unit = ParseUnit<TUnit>(match.Groups["Unit"].Value);
                return creator(d, unit);
            }
            catch (Exception e)
            {
                throw new FormatException("Could not parse the unit value from: " + s, e);
            }
        }

        public static TUnit ParseUnit<TUnit>(string s)
            where TUnit : IUnit
        {
            var type = typeof(TUnit);
            var symbols = SymbolCache.GetOrAdd(type, t => t.Units().Select(x => new Symbol(x)).ToArray());
            return (TUnit)symbols.Single(x => x.IsMatch(s)).Unit;
        }

        public static double ParseDouble(string s, IFormatProvider provider)
        {
            return double.Parse(s, provider);
        }

        private static IEnumerable<IUnit> Units(this Type t)
        {
            var units = t.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static)
                              .Where(f => typeof(IUnit).IsAssignableFrom(f.FieldType))
                              .Select(f => (IUnit)f.GetValue(null))
                              .Distinct()
                              .ToArray();
            return units;
        }

        public class Power
        {
            public Power(int exponent, string[] stringRepresentations)
            {
                this.Exponent = exponent;
                this.StringRepresentations = stringRepresentations;
            }
            public int Exponent { get; private set; }

            public string Pattern
            {
                get
                {
                    var pattern = string.Join("|", StringRepresentations);
                    return pattern;
                }
            }

            public string[] StringRepresentations { get; private set; }

            public override string ToString()
            {
                var @join = string.Join(", ", StringRepresentations);
                return string.Format("Exponent: {0}: {{{1}}}", this.Exponent, @join);
            }
        }

        public class Symbol
        {
            public static readonly Power[] Powers =
                {
                    new Power(1,new []{ "¹","^1"}), 
                    new Power(2,new []{ "²","^2"}), 
                    new Power(3,new []{ "³","^3"}),
                    new Power(-1,new []{ "⁻¹","^-1"}), 
                    new Power(-2,new []{ "⁻²","^-2"}), 
                    new Power(-3,new []{ "⁻³","^-3"})
                };

            public static string PowerPattern = string.Join("|", Powers.SelectMany(x => x.StringRepresentations));

            public static string OperatorPattern = @"[⋅*/]";
            
            public Symbol(IUnit unit)
            {
                this.Unit = unit;
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(@"^ *");
                var powerMatches = Regex.Matches(unit.Symbol, PowerPattern).OfType<Match>().ToArray();
                var operatorMatches = Regex.Matches(unit.Symbol, OperatorPattern).OfType<Match>().ToArray();
                int i = 0;
                while (i < unit.Symbol.Length)
                {
                    var powerMatch = powerMatches.FirstOrDefault(m => m.Index == i);
                    if (powerMatch != null)
                    {
                        var power = Powers.Single(x => x.StringRepresentations.Any(s => s == powerMatch.Value));
                        stringBuilder.AppendFormat(@"({0})", power.Pattern);
                        if (power.Exponent == 1)
                        {
                            stringBuilder.Append("?");
                        }
                        i += powerMatch.Length;
                        continue;
                    }
                    var operatorMatch = operatorMatches.FirstOrDefault(m => m.Index == i);
                    if (operatorMatch!=null)
                    {
                        if (operatorMatch.Value == "/")
                        {
                            throw new NotImplementedException("message");
                        }
                        else
                        {
                            stringBuilder.Append("[⋅*]");
                            i++;
                        }
                        continue;
                    }
                    else
                    {
                        if (!char.IsWhiteSpace(unit.Symbol[i]))
                        {
                            stringBuilder.Append(unit.Symbol[i]);
                        }
                        i++;
                    }
                }
                stringBuilder.Append(@" *$");
                this.Pattern = stringBuilder.ToString();
            }

            public string Pattern { get; private set; }

            public IUnit Unit { get; private set; }

            public bool IsMatch(string s)
            {
                return Regex.IsMatch(s, this.Pattern);
            }

            public override string ToString()
            {
                return String.Format("Unit: {0}, Pattern: {1}", this.Unit, this.Pattern);
            }
        }
    }
}