namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="AmountOfSubstance"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(AmountOfSubstance))]
    public class AmountOfSubstanceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.AmountOfSubstanceExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public AmountOfSubstanceExtension(AmountOfSubstance value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="AmountOfSubstance"/> value
        /// </summary>		
        public AmountOfSubstance Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}