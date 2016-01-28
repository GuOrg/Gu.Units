namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(LengthPerUnitless))]
    public class LengthPerUnitlessExtension : MarkupExtension
    {
        public LengthPerUnitlessExtension(string value)
        {
            this.Value = LengthPerUnitless.Parse(value, CultureInfo.InvariantCulture);
        }

        public LengthPerUnitless Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}