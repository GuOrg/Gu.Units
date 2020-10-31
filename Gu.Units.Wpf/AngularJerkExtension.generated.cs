namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="AngularJerk"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(AngularJerk))]
    public class AngularJerkExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.AngularJerkExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.AngularJerk"/>.</param>
        public AngularJerkExtension(AngularJerk value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="AngularJerk"/> value
        /// </summary>
        public AngularJerk Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
