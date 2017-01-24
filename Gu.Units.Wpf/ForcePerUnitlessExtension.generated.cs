





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="ForcePerUnitless"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(ForcePerUnitless))]
    public class ForcePerUnitlessExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.ForcePerUnitlessExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public ForcePerUnitlessExtension(ForcePerUnitless value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="ForcePerUnitless"/> value
        /// </summary>		
        public ForcePerUnitless Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}