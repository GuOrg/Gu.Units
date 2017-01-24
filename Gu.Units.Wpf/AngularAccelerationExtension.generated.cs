





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="AngularAcceleration"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(AngularAcceleration))]
    public class AngularAccelerationExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.AngularAccelerationExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.AngularAcceleration"/>.</param>
        public AngularAccelerationExtension(AngularAcceleration value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="AngularAcceleration"/> value
        /// </summary>		
        public AngularAcceleration Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}