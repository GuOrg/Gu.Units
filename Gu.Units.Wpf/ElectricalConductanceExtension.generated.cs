namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(ElectricalConductance))]
    public class ElectricalConductanceExtension : MarkupExtension
    {
        public ElectricalConductanceExtension(ElectricalConductance value)
        {
            this.Value = value;
        }

        public ElectricalConductance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}