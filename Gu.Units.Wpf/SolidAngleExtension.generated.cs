namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="SolidAngle"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(SolidAngle))]
    public class SolidAngleExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.SolidAngleExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.SolidAngle"/>.</param>
        public SolidAngleExtension(SolidAngle value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="SolidAngle"/> value
        /// </summary>
        public SolidAngle Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}