namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Angle))]
    public class AngleExtension : MarkupExtension
    {
        public AngleExtension(string value)
        {
            this.Value = Angle.Parse(value, CultureInfo.InvariantCulture);
        }

        public Angle Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}