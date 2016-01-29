namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Acceleration))]
    public class AccelerationExtension : MarkupExtension
    {
        public AccelerationExtension(Acceleration value)
        {
            this.Value = value;
        }

        public Acceleration Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}