namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(LuminousFlux))]
    public class LuminousFluxExtension : MarkupExtension
    {
        public LuminousFluxExtension(LuminousFlux value)
        {
            this.Value = value;
        }

        public LuminousFlux Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}