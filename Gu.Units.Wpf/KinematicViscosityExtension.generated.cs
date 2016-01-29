namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(KinematicViscosity))]
    public class KinematicViscosityExtension : MarkupExtension
    {
        public KinematicViscosityExtension(KinematicViscosity value)
        {
            this.Value = value;
        }

        public KinematicViscosity Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}