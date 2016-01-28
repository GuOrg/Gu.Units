namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Voltage))]
    public class VoltageExtension : MarkupExtension
    {
        public VoltageExtension(string value)
        {
            this.Value = Voltage.Parse(value, CultureInfo.InvariantCulture);
        }

        public Voltage Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}