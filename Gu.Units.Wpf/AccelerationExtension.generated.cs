namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Acceleration))]
    public class AccelerationExtension : MarkupExtension
    {
        public AccelerationExtension(string value)
        {
            this.Value = Acceleration.Parse(value, CultureInfo.InvariantCulture);
        }

        public Acceleration Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}