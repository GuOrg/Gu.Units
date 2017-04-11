namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Temperature"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Temperature))]
    public class TemperatureExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.TemperatureExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Temperature"/>.</param>
        public TemperatureExtension(Temperature value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Temperature"/> value
        /// </summary>
        public Temperature Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}