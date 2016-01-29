namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(MagneticFlux))]
    public class MagneticFluxExtension : MarkupExtension
    {
        public MagneticFluxExtension(MagneticFlux value)
        {
            this.Value = value;
        }

        public MagneticFlux Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}