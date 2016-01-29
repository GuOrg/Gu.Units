namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Angle))]
    public class AngleExtension : MarkupExtension
    {
        public AngleExtension(Angle value)
        {
            this.Value = value;
        }

        public Angle Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}