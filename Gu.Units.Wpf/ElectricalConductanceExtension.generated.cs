namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="ElectricalConductance"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(ElectricalConductance))]
    public class ElectricalConductanceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.ElectricalConductanceExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.ElectricalConductance"/>.</param>
        public ElectricalConductanceExtension(ElectricalConductance value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="ElectricalConductance"/> value
        /// </summary>
        public ElectricalConductance Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
