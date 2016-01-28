namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(MagneticFieldStrength))]
    public class MagneticFieldStrengthExtension : MarkupExtension
    {
        public MagneticFieldStrengthExtension(string value)
        {
            this.Value = MagneticFieldStrength.Parse(value, CultureInfo.InvariantCulture);
        }

        public MagneticFieldStrength Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}