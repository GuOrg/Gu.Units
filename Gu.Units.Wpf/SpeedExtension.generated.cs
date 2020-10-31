namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Speed"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Speed))]
    public class SpeedExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.SpeedExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Speed"/>.</param>
        public SpeedExtension(Speed value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Speed"/> value
        /// </summary>
        public Speed Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
