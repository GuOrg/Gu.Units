namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Voltage))]
    public class VoltageExtension : MarkupExtension
    {
        public VoltageExtension(Voltage value)
        {
            this.Value = value;
        }

        public Voltage Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}