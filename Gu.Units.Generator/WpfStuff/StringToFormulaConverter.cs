namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class StringToFormulaConverter : TypeConverter
    {
        public static readonly string DoublePattern = @"[+-]?\d*(?:[.]\d+)?(?:[eE][+-]?\d+)?";
        public static readonly string FormulaPattern = string.Format(@"(?<factor>{0}\*)?(?<base>\w+)(?<offset>{0})",
            DoublePattern);
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
            var s = value as string;
            if (s == null)
            {
                return null;
            }
            else
            {
                var match = Regex.Match(s, FormulaPattern);
                var factor = match.Groups["factor"].Value == ""
                    ? ""
                    : match.Groups["factor"].Value.Substring(0, match.Groups["factor"].Value.Length - 1);
                var offset = match.Groups["offset"].Value;
                return new ConversionFormula(null)
                {
                    ConversionFactor = !string.IsNullOrEmpty(factor) ? double.Parse(factor, CultureInfo.InvariantCulture) : 1,
                    Offset = !string.IsNullOrEmpty(offset) ? double.Parse(offset, CultureInfo.InvariantCulture) : 0
                };
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var formula = value as ConversionFormula;
            if (formula == null)
            {
                return null;
            }
            else
            {
                return formula.ToSi;
            }
        }
    }
}
