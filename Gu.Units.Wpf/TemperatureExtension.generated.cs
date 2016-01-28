namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Temperature))]
    public class TemperatureExtension : MarkupExtension
    {
        public TemperatureExtension(string value)
        {
            this.Value = Temperature.Parse(value, CultureInfo.InvariantCulture);
        }

        public Temperature Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}