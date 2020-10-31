namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="LengthPerUnitless"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(LengthPerUnitless))]
    public class LengthPerUnitlessExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.LengthPerUnitlessExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public LengthPerUnitlessExtension(LengthPerUnitless value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="LengthPerUnitless"/> value
        /// </summary>
        public LengthPerUnitless Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
