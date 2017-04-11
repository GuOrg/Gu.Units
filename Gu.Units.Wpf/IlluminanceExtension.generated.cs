namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Illuminance"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Illuminance))]
    public class IlluminanceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.IlluminanceExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Illuminance"/>.</param>
        public IlluminanceExtension(Illuminance value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Illuminance"/> value
        /// </summary>
        public Illuminance Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}