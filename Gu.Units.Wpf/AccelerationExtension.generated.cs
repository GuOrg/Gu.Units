namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Acceleration"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Acceleration))]
    public class AccelerationExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.AccelerationExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Acceleration"/>.</param>
        public AccelerationExtension(Acceleration value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Acceleration"/> value
        /// </summary>		
        public Acceleration Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}