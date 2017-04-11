namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="MagneticFlux"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(MagneticFlux))]
    public class MagneticFluxExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.MagneticFluxExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.MagneticFlux"/>.</param>
        public MagneticFluxExtension(MagneticFlux value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="MagneticFlux"/> value
        /// </summary>
        public MagneticFlux Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}