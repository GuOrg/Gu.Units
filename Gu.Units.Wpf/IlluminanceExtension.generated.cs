namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Illuminance))]
    public class IlluminanceExtension : MarkupExtension
    {
        public IlluminanceExtension(Illuminance value)
        {
            this.Value = value;
        }

        public Illuminance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}