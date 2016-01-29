namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Pressure))]
    public class PressureExtension : MarkupExtension
    {
        public PressureExtension(Pressure value)
        {
            this.Value = value;
        }

        public Pressure Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}