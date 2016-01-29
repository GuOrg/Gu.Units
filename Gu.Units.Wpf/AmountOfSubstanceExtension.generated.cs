namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AmountOfSubstance))]
    public class AmountOfSubstanceExtension : MarkupExtension
    {
        public AmountOfSubstanceExtension(AmountOfSubstance value)
        {
            this.Value = value;
        }

        public AmountOfSubstance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}