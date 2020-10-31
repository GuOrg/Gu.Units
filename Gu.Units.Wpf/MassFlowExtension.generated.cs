#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="MassFlow"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(MassFlow))]
    public class MassFlowExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.MassFlowExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.MassFlow"/>.</param>
        public MassFlowExtension(MassFlow value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="MassFlow"/> value
        /// </summary>
        public MassFlow Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
