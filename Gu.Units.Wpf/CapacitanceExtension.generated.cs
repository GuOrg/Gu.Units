namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Capacitance))]
    public class CapacitanceExtension : MarkupExtension
    {
        public CapacitanceExtension(string value)
        {
            this.Value = Capacitance.Parse(value, CultureInfo.InvariantCulture);
        }

        public Capacitance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}