namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="CatalyticActivity"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(CatalyticActivity))]
    public class CatalyticActivityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.CatalyticActivityExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.CatalyticActivity"/>.</param>
        public CatalyticActivityExtension(CatalyticActivity value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="CatalyticActivity"/> value
        /// </summary>
        public CatalyticActivity Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
