namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Length"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Length))]
    public class LengthExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.LengthExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Length"/>.</param>
        public LengthExtension(Length value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Length"/> value
        /// </summary>
        public Length Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}