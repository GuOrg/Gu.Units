namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="AreaDensity"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(AreaDensity))]
    public class AreaDensityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.AreaDensityExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.AreaDensity"/>.</param>
        public AreaDensityExtension(AreaDensity value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="AreaDensity"/> value
        /// </summary>
        public AreaDensity Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}