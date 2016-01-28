namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(ElectricCharge))]
    public class ElectricChargeExtension : MarkupExtension
    {
        public ElectricChargeExtension(string value)
        {
            this.Value = ElectricCharge.Parse(value, CultureInfo.InvariantCulture);
        }

        public ElectricCharge Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}