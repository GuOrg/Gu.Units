namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;

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
            var text = value as string;
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var settings = Settings.Instance;
            IReadOnlyList<SymbolAndPower> result;
            int pos = 0;
            WhiteSpaceReader.TryRead(text, ref pos);
            var indexOf = text.IndexOf("1/", pos);
            if (indexOf >= 0)
            {
                pos = indexOf + 2;
            }
            if (SymbolAndPowerReader.TryRead(text, ref pos, out result))
            {
                if (WhiteSpaceReader.IsRestWhiteSpace(text, pos))
                {
                    var unitAndPowers = result.Select(sap => UnitAndPower.Create(settings.AllUnits.Single(x => x.Symbol == sap.Symbol), sap.Power))
                                          .ToList();
                    var unitParts = new UnitParts(unitAndPowers);
                    if (indexOf < 0)
                    {
                        return unitParts;
                    }

                    return unitParts.Inverse();
                }
            }

            return text;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return ((UnitParts)value)?.Symbol;
        }
    }
}