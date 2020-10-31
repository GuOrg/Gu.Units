#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Voltage"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Voltage))]
    public class VoltageExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.VoltageExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Voltage"/>.</param>
        public VoltageExtension(Voltage value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Voltage"/> value
        /// </summary>
        public Voltage Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
