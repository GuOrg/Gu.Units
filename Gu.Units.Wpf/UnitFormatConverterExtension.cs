namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    /// Use this to format unit values in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(IValueConverter))]
    [ValueConversion(typeof(IUnit), typeof(string))]
    public class UnitFormatConverterExtension : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.UnitFormatConverterExtension"/> class.
        /// </summary>
        /// <param name="format"><see cref="Gu.Units.SymbolFormat"/>.</param>
        public UnitFormatConverterExtension(SymbolFormat format)
        {
            this.Format = format;
        }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        [ConstructorArgument("format")]
        public SymbolFormat Format { get; set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                IUnit unit => unit.ToString(this.Format),
                _ => value,
            };
        }

        /// <inheritdoc />
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("UnitFormatConverterExtension can only be used in oneway bindings");
        }
    }
}
