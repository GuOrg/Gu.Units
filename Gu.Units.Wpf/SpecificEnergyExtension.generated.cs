namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="SpecificEnergy"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(SpecificEnergy))]
    public class SpecificEnergyExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.SpecificEnergyExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.SpecificEnergy"/>.</param>
        public SpecificEnergyExtension(SpecificEnergy value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="SpecificEnergy"/> value
        /// </summary>		
        public SpecificEnergy Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}