namespace Gu.Units.Generator.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Windows.Media;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class BooleanToBrushConverterExtension : MarkupExtension, IValueConverter
    {
        public Brush WhenTrue { get; set; }

        public Brush WhenFalse { get; set; }

        public Brush WhenNull { get; set; }

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
