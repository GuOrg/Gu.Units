namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(ForcePerUnitless))]
    public class ForcePerUnitlessExtension : MarkupExtension
    {
        public ForcePerUnitlessExtension(string value)
        {
            this.Value = ForcePerUnitless.Parse(value, CultureInfo.InvariantCulture);
        }

        public ForcePerUnitless Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}