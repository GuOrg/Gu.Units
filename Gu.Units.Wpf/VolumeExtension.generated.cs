namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Volume"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Volume))]
    public class VolumeExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.VolumeExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Volume"/>.</param>
        public VolumeExtension(Volume value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Volume"/> value
        /// </summary>		
        public Volume Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}