





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="LuminousIntensity"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(LuminousIntensity))]
    public class LuminousIntensityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.LuminousIntensityExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.LuminousIntensity"/>.</param>
        public LuminousIntensityExtension(LuminousIntensity value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="LuminousIntensity"/> value
        /// </summary>		
        public LuminousIntensity Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}