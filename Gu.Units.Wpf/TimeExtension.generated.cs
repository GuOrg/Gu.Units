namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Time))]
    public class TimeExtension : MarkupExtension
    {
        public TimeExtension(string value)
        {
            this.Value = Time.Parse(value, CultureInfo.InvariantCulture);
        }

        public Time Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}