namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AnglePerUnitless))]
    public class AnglePerUnitlessExtension : MarkupExtension
    {
        public AnglePerUnitlessExtension(string value)
        {
            this.Value = AnglePerUnitless.Parse(value, CultureInfo.InvariantCulture);
        }

        public AnglePerUnitless Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}