





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Capacitance"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Capacitance))]
    public class CapacitanceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.CapacitanceExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Capacitance"/>.</param>
        public CapacitanceExtension(Capacitance value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Capacitance"/> value
        /// </summary>		
        public Capacitance Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}