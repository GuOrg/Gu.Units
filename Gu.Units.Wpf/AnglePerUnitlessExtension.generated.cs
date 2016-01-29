namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AnglePerUnitless))]
    public class AnglePerUnitlessExtension : MarkupExtension
    {
        public AnglePerUnitlessExtension(AnglePerUnitless value)
        {
            this.Value = value;
        }

        public AnglePerUnitless Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}