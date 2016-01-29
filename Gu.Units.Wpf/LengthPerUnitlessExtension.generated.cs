namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(LengthPerUnitless))]
    public class LengthPerUnitlessExtension : MarkupExtension
    {
        public LengthPerUnitlessExtension(LengthPerUnitless value)
        {
            this.Value = value;
        }

        public LengthPerUnitless Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}