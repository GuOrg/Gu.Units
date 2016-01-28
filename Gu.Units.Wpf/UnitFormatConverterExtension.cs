namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class UnitFormatConverterExtension : MarkupExtension, IValueConverter
    {
        public UnitFormatConverterExtension(SymbolFormat format)
        {
            this.Format = format;
        }

        [ConstructorArgument("format")]
        public SymbolFormat Format { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lengthUnit = value as IUnit;
            if (lengthUnit == null)
            {
                return value;
            }

            return lengthUnit.ToString(this.Format);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("UnitFormatConverterExtension can only be used in oneway bindings");
        }
    }
}
