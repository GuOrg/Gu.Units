namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="MagneticFieldStrength"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(MagneticFieldStrength))]
    public class MagneticFieldStrengthExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.MagneticFieldStrengthExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public MagneticFieldStrengthExtension(MagneticFieldStrength value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="MagneticFieldStrength"/> value
        /// </summary>
        public MagneticFieldStrength Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
