namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(MagneticFieldStrength))]
    public class MagneticFieldStrengthExtension : MarkupExtension
    {
        public MagneticFieldStrengthExtension(MagneticFieldStrength value)
        {
            this.Value = value;
        }

        public MagneticFieldStrength Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}