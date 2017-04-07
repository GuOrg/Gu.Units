namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Wavenumber"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Wavenumber))]
    public class WavenumberExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.WavenumberExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Wavenumber"/>.</param>
        public WavenumberExtension(Wavenumber value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Wavenumber"/> value
        /// </summary>		
        public Wavenumber Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}