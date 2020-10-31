namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Time"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Time))]
    public class TimeExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.TimeExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Time"/>.</param>
        public TimeExtension(Time value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Time"/> value
        /// </summary>
        public Time Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
