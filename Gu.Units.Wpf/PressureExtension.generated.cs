namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Pressure))]
    public class PressureExtension : MarkupExtension
    {
        public PressureExtension(string value)
        {
            this.Value = Pressure.Parse(value, CultureInfo.InvariantCulture);
        }

        public Pressure Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}