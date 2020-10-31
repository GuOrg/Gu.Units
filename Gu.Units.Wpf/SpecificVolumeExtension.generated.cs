#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="SpecificVolume"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(SpecificVolume))]
    public class SpecificVolumeExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.SpecificVolumeExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.SpecificVolume"/>.</param>
        public SpecificVolumeExtension(SpecificVolume value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="SpecificVolume"/> value
        /// </summary>
        public SpecificVolume Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
