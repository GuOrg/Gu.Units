namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Resistance"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Resistance))]
    public class ResistanceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.ResistanceExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Resistance"/>.</param>
        public ResistanceExtension(Resistance value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Resistance"/> value
        /// </summary>
        public Resistance Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}