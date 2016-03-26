namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Force"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Force))]
    public class ForceExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.ForceExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Force"/>.</param>
        public ForceExtension(Force value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Force"/> value
        /// </summary>		
        public Force Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}