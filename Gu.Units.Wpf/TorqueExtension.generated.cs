namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Torque"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Torque))]
    public class TorqueExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.TorqueExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Torque"/>.</param>
        public TorqueExtension(Torque value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Torque"/> value
        /// </summary>		
        public Torque Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}