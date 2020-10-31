namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Conductivity"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Conductivity))]
    public class ConductivityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.ConductivityExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Conductivity"/>.</param>
        public ConductivityExtension(Conductivity value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Conductivity"/> value
        /// </summary>
        public Conductivity Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
