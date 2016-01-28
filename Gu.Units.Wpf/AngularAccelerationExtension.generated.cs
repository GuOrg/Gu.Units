namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AngularAcceleration))]
    public class AngularAccelerationExtension : MarkupExtension
    {
        public AngularAccelerationExtension(string value)
        {
            this.Value = AngularAcceleration.Parse(value, CultureInfo.InvariantCulture);
        }

        public AngularAcceleration Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}