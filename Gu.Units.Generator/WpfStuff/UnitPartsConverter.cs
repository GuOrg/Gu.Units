namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UnitPartsConverter : TypeConverter
    {
        private static readonly string[] Superscripts = { "¹", "²", "³", "⁴" };

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var s =  value as string;
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            var matches = Parse(s);
            var parts = new UnitParts(null);
            int sign = 1;
            bool expectsSymbol = true;
            foreach (Match match in matches)
            {
                if (expectsSymbol)
                {
                    var symbol = match.Groups["Symbol"].Value;
                    if (symbol == "1")
                    {
                        expectsSymbol = false;
                        continue;
                    }
                    var unit = Settings.Instance.AllUnits.Single(x => x.Symbol == symbol);
                    int p = ParsePower(match.Groups["Power"].Value);
                    parts.Add(new UnitAndPower(unit, sign * p));
                    expectsSymbol = false;
                }
                else
                {
                    var op = match.Groups["Op"].Value;
                    if (op == "/")
                    {
                        if (sign < 0)
                        {
                            throw new FormatException("/ can't appear twice found at position:" + match.Index);
                        }
                        else
                        {
                            sign = -1;
                        }
                    }
                    expectsSymbol = true;
                }
            }
            return parts;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return ((UnitParts) value)?.Expression;
        }

        private static IEnumerable<Match> Parse(string s)
        {
            var symbols = Settings.Instance.AllUnits.Where(x => !string.IsNullOrEmpty(x.Symbol))
                                                    .Select(x => Regex.Escape(x.Symbol))
                                                    .ToArray();
            var symbolsPattern = string.Join("|", new[] { "1" }.Concat(symbols));
            var superscriptsPattern = string.Join("|", Superscripts);
            var pattern = $@"(?<Unit>
                                (?<Symbol>({symbolsPattern
                                                }))
                                (?<Power>
                                    ((?:\^)[\+\-]?\d+)
                                    |
                                    (⁻?({superscriptsPattern
                                                }))
                                )?
                                |
                                (?<Op>[⋅\*\/])?
                            )";
            var matches = Regex.Matches(s, pattern, RegexOptions.IgnorePatternWhitespace)
                               .OfType<Match>()
                               .ToArray();
            return matches;
        }

        private static int ParsePower(string power)
        {
            if (power == "")
            {
                return 1;
            }
            if (power[0] == '⁻')
            {
                var indexOf = Array.IndexOf(Superscripts, power.Substring(1));
                if (indexOf < 0)
                {
                    throw new FormatException();
                }
                return -1 * (indexOf + 1);
            }
            int p = Array.IndexOf(Superscripts, power) + 1;
            if (p > 0)
            {
                return p;
            }
            if (power[0] != '^')
            {
                throw new FormatException();
            }
            p = int.Parse(power.TrimStart('^'));
            return p;
        }
    }
}