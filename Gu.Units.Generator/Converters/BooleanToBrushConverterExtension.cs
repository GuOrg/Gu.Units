namespace Gu.Units.Generator.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Windows.Media;

    [MarkupExtensionReturnType(typeof(BooleanToBrushConverterExtension))]
    [ValueConversion(typeof(bool?), typeof(Brush))]
    public class BooleanToBrushConverterExtension : MarkupExtension, IValueConverter
    {
        public Brush WhenTrue { get; set; }

        public Brush WhenFalse { get; set; }

        public Brush WhenNull { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                true => this.WhenTrue,
                false => this.WhenFalse,
                null => this.WhenNull,
                _ => throw new ArgumentException("Not a bool.", nameof(value)),
            };
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(BooleanToBrushConverterExtension)} can only be used in OneWay bindings");
        }
    }
}
