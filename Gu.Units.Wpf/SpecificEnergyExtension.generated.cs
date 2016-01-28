namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(SpecificEnergy))]
    public class SpecificEnergyExtension : MarkupExtension
    {
        public SpecificEnergyExtension(string value)
        {
            this.Value = SpecificEnergy.Parse(value, CultureInfo.InvariantCulture);
        }

        public SpecificEnergy Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}