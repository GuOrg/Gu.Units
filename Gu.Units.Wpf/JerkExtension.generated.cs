namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Jerk"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Jerk))]
    public class JerkExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.JerkExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Jerk"/>.</param>
        public JerkExtension(Jerk value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Jerk"/> value
        /// </summary>
        public Jerk Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
