





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Current"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Current))]
    public class CurrentExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.CurrentExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Current"/>.</param>
        public CurrentExtension(Current value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Current"/> value
        /// </summary>		
        public Current Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}