namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Power"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Power))]
    public class PowerExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.PowerExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Power"/>.</param>
        public PowerExtension(Power value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Power"/> value
        /// </summary>		
        public Power Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}