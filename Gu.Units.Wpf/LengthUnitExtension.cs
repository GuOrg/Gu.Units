//// not sure we want this type
namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// <see cref="MarkupExtension"/> for creating <see cref="LengthUnit"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(LengthUnit))]
    public class LengthUnitExtension : MarkupExtension
    {
        /// <summary>
        /// An instance of <see cref="LengthUnit.Millimetres"/>.
        /// </summary>
        public static readonly LengthUnit Millimetres = LengthUnit.Millimetres;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.LengthUnitExtension"/> class.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.LengthUnit"/>.</param>
        public LengthUnitExtension(LengthUnit value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [ConstructorArgument("value")]
        public LengthUnit Value { get; set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}
