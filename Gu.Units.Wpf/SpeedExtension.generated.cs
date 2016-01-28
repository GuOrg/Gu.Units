namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Speed))]
    public class SpeedExtension : MarkupExtension
    {
        public SpeedExtension(string value)
        {
            this.Value = Speed.Parse(value, CultureInfo.InvariantCulture);
        }

        public Speed Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}