namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Frequency))]
    public class FrequencyExtension : MarkupExtension
    {
        public FrequencyExtension(string value)
        {
            this.Value = Frequency.Parse(value, CultureInfo.InvariantCulture);
        }

        public Frequency Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}