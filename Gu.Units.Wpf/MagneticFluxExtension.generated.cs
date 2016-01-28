namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(MagneticFlux))]
    public class MagneticFluxExtension : MarkupExtension
    {
        public MagneticFluxExtension(string value)
        {
            this.Value = MagneticFlux.Parse(value, CultureInfo.InvariantCulture);
        }

        public MagneticFlux Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}