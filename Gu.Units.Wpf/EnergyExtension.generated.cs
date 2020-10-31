namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Energy"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Energy))]
    public class EnergyExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.EnergyExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Energy"/>.</param>
        public EnergyExtension(Energy value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Energy"/> value
        /// </summary>
        public Energy Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
