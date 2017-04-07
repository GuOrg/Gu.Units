namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="AnglePerUnitless"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(AnglePerUnitless))]
    public class AnglePerUnitlessExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.AnglePerUnitlessExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public AnglePerUnitlessExtension(AnglePerUnitless value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="AnglePerUnitless"/> value
        /// </summary>		
        public AnglePerUnitless Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}