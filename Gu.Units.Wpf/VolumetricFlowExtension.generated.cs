namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

	/// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="VolumetricFlow"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(VolumetricFlow))]
    public class VolumetricFlowExtension : MarkupExtension
    {
		/// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.VolumetricFlowExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.VolumetricFlow"/>.</param>
        public VolumetricFlowExtension(VolumetricFlow value)
        {
            this.Value = value;
        }

		/// <summary>
        /// Gets the <see cref="VolumetricFlow"/> value
        /// </summary>		
        public VolumetricFlow Value { get; private set; }

		/// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}