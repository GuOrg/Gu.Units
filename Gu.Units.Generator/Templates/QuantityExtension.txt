namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(KinematicViscosity))]
    public class KinematicViscosityExtension : MarkupExtension
    {
        public KinematicViscosityExtension(string value)
        {
            this.Value = KinematicViscosity.Parse(value, CultureInfo.InvariantCulture);
        }

        public KinematicViscosity Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}