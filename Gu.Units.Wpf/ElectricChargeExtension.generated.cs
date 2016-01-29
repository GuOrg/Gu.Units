namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(ElectricCharge))]
    public class ElectricChargeExtension : MarkupExtension
    {
        public ElectricChargeExtension(ElectricCharge value)
        {
            this.Value = value;
        }

        public ElectricCharge Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}