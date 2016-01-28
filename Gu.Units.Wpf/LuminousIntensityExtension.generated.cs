namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(LuminousIntensity))]
    public class LuminousIntensityExtension : MarkupExtension
    {
        public LuminousIntensityExtension(string value)
        {
            this.Value = LuminousIntensity.Parse(value, CultureInfo.InvariantCulture);
        }

        public LuminousIntensity Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}