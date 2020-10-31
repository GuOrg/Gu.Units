#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="MolarHeatCapacity"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(MolarHeatCapacity))]
    public class MolarHeatCapacityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.MolarHeatCapacityExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.MolarHeatCapacity"/>.</param>
        public MolarHeatCapacityExtension(MolarHeatCapacity value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="MolarHeatCapacity"/> value
        /// </summary>
        public MolarHeatCapacity Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
