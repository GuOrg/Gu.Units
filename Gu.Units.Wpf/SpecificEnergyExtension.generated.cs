namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(SpecificEnergy))]
    public class SpecificEnergyExtension : MarkupExtension
    {
        public SpecificEnergyExtension(SpecificEnergy value)
        {
            this.Value = value;
        }

        public SpecificEnergy Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}