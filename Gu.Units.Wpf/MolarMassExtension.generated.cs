namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="MolarMass"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(MolarMass))]
    public class MolarMassExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.MolarMassExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.MolarMass"/>.</param>
        public MolarMassExtension(MolarMass value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="MolarMass"/> value
        /// </summary>
        public MolarMass Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}