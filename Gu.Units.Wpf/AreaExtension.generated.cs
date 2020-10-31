#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Area"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Area))]
    public class AreaExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.AreaExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Area"/>.</param>
        public AreaExtension(Area value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Area"/> value
        /// </summary>
        public Area Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
