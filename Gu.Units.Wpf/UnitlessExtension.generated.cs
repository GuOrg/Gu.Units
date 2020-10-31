namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Unitless"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Unitless))]
    public class UnitlessExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.UnitlessExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Unitless"/>.</param>
        public UnitlessExtension(Unitless value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Unitless"/> value
        /// </summary>
        public Unitless Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
