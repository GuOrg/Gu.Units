namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Frequency))]
    public class FrequencyExtension : MarkupExtension
    {
        public FrequencyExtension(Frequency value)
        {
            this.Value = value;
        }

        public Frequency Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}