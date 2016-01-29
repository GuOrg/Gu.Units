namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Time))]
    public class TimeExtension : MarkupExtension
    {
        public TimeExtension(Time value)
        {
            this.Value = value;
        }

        public Time Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}