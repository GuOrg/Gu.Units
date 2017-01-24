





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Stiffness"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Stiffness))]
    public class StiffnessExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.StiffnessExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Stiffness"/>.</param>
        public StiffnessExtension(Stiffness value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Stiffness"/> value
        /// </summary>		
        public Stiffness Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}