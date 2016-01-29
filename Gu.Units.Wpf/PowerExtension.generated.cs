namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Power))]
    public class PowerExtension : MarkupExtension
    {
        public PowerExtension(Power value)
        {
            this.Value = value;
        }

        public Power Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}