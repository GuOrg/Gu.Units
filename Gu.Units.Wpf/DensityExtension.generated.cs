namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Density"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Density))]
    public class DensityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.DensityExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Density"/>.</param>
        public DensityExtension(Density value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Density"/> value
        /// </summary>		
        public Density Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}