namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AngularAcceleration))]
    public class AngularAccelerationExtension : MarkupExtension
    {
        public AngularAccelerationExtension(AngularAcceleration value)
        {
            this.Value = value;
        }

        public AngularAcceleration Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}