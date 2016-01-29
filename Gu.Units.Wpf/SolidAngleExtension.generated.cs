namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(SolidAngle))]
    public class SolidAngleExtension : MarkupExtension
    {
        public SolidAngleExtension(SolidAngle value)
        {
            this.Value = value;
        }

        public SolidAngle Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}