namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    // not sure we want tis type
    [MarkupExtensionReturnType(typeof(LengthUnit))]
    public class LengthUnitExtension : MarkupExtension
    {
        public static readonly LengthUnit Millimetres = LengthUnit.Millimetres;

        public LengthUnitExtension(LengthUnit value)
        {
            this.Value = value;
        }

        [ConstructorArgument("value")]
        public LengthUnit Value { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}