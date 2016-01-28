namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(SolidAngle))]
    public class SolidAngleExtension : MarkupExtension
    {
        public SolidAngleExtension(string value)
        {
            this.Value = SolidAngle.Parse(value, CultureInfo.InvariantCulture);
        }

        public SolidAngle Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}