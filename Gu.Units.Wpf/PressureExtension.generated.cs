namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Pressure"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Pressure))]
    public class PressureExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.PressureExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Pressure"/>.</param>
        public PressureExtension(Pressure value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Pressure"/> value
        /// </summary>
        public Pressure Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
