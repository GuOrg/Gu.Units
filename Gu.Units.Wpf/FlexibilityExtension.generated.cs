#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Flexibility"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Flexibility))]
    public class FlexibilityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.FlexibilityExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Flexibility"/>.</param>
        public FlexibilityExtension(Flexibility value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Flexibility"/> value
        /// </summary>
        public Flexibility Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
