#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="ElectricCharge"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(ElectricCharge))]
    public class ElectricChargeExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.ElectricChargeExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.ElectricCharge"/>.</param>
        public ElectricChargeExtension(ElectricCharge value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="ElectricCharge"/> value
        /// </summary>
        public ElectricCharge Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
