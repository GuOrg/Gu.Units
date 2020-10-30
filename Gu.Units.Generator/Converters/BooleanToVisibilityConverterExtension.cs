namespace Gu.Units.Generator.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(BooleanToVisibilityConverterExtension))]
    [ValueConversion(typeof(bool?), typeof(Visibility))]
    public class BooleanToVisibilityConverterExtension : MarkupExtension, IValueConverter
    {
        public Visibility WhenTrue { get; set; }

        public Visibility WhenFalse { get; set; }

        public Visibility WhenNull { get; set; }

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
            throw new NotSupportedException($"{nameof(BooleanToVisibilityConverterExtension)} can only be used in OneWay bindings");
        }
    }
}