namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Angle"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Angle))]
    public class AngleExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.AngleExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Angle"/>.</param>
        public AngleExtension(Angle value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Angle"/> value
        /// </summary>		
        public Angle Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}