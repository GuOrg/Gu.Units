namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Inductance"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Inductance))]
    public class InductanceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.InductanceExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Inductance"/>.</param>
        public InductanceExtension(Inductance value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Inductance"/> value
        /// </summary>
        public Inductance Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}