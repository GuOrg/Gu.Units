namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Gu.Units.Generator.Annotations;

    public class UnitPartsConverter : TypeConverter
    {
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
            if (value == null)
            {
                return null;
            }
            int sign = 1;
            var s = (string)value;
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            var symbols = UnitBase.AllUnitsStatic.Select(x => x.Symbol).ToArray();
            var pattern = string.Format(@"(?<Unit>(?<Symbol>({0}))((?:\^)(?<Power>[+-]?\d+))?)|(?<Op>[\*\/])", string.Join("|", symbols));
            var matches = Regex.Matches(s, pattern);
            var parts = new UnitParts();
            bool expectsSymbol = true;
            foreach (Match match in matches)
            {
                if (expectsSymbol)
                {
                    var symbol = match.Groups["Symbol"].Value;
                    var unit = UnitBase.AllUnitsStatic.Single(x => x.Symbol == symbol);
                    var power = match.Groups["Power"].Value;
                    if (power == "")
                    {
                        parts.Add(new UnitAndPower(unit, sign * 1));
                    }
                    else
                    {
                        parts.Add(new UnitAndPower(unit, sign * int.Parse(power)));
                    }
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
                //capture["Unit"]
                //parts.Add([""]);
            }
            return parts;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return value == null ? null : ((UnitParts)value).UiName;
        }
    }
}