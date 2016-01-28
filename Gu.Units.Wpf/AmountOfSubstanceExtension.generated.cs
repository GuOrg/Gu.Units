namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AmountOfSubstance))]
    public class AmountOfSubstanceExtension : MarkupExtension
    {
        public AmountOfSubstanceExtension(string value)
        {
            this.Value = AmountOfSubstance.Parse(value, CultureInfo.InvariantCulture);
        }

        public AmountOfSubstance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}