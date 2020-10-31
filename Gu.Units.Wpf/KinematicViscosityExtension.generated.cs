#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="KinematicViscosity"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(KinematicViscosity))]
    public class KinematicViscosityExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.KinematicViscosityExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.KinematicViscosity"/>.</param>
        public KinematicViscosityExtension(KinematicViscosity value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="KinematicViscosity"/> value
        /// </summary>
        public KinematicViscosity Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
