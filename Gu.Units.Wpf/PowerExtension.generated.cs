namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Power))]
    public class PowerExtension : MarkupExtension
    {
        public PowerExtension(string value)
        {
            this.Value = Power.Parse(value, CultureInfo.InvariantCulture);
        }

        public Power Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}