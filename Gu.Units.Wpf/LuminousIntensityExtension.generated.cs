namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(LuminousIntensity))]
    public class LuminousIntensityExtension : MarkupExtension
    {
        public LuminousIntensityExtension(LuminousIntensity value)
        {
            this.Value = value;
        }

        public LuminousIntensity Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}