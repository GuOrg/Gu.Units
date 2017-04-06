namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="LuminousFlux"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(LuminousFlux))]
    public class LuminousFluxExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.LuminousFluxExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.LuminousFlux"/>.</param>
        public LuminousFluxExtension(LuminousFlux value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="LuminousFlux"/> value
        /// </summary>		
        public LuminousFlux Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}