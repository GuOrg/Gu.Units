namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Illuminance))]
    public class IlluminanceExtension : MarkupExtension
    {
        public IlluminanceExtension(string value)
        {
            this.Value = Illuminance.Parse(value, CultureInfo.InvariantCulture);
        }

        public Illuminance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}