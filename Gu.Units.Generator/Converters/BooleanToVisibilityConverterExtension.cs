namespace Gu.Units.Generator.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class BooleanToVisibilityConverterExtension : MarkupExtension, IValueConverter
    {
        public Visibility WhenTrue { get; set; }

        public Visibility WhenFalse { get; set; }

        public Visibility WhenNull { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isTrue)
            {
                return isTrue
                           ? this.WhenTrue
                           : this.WhenFalse;
            }

            return this.WhenNull;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}