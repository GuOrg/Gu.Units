namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    public class TypeMetaDataConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object quantity)
        {
            return quantity == null ? null : new TypeMetaData((string)quantity);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object quantity, Type destinationType)
        {
            return quantity == null ? null : ((TypeMetaData)quantity).ClassName;
        }
    }

    public class QuantityConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object quantity)
        {
            return quantity == null ? null : new Quantity("", (string)quantity, new SiUnit());
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object quantity, Type destinationType)
        {
            return quantity == null ? null : ((TypeMetaData)quantity).ClassName;
        }
    }
}
