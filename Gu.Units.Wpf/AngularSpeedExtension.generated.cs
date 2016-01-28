namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AngularSpeed))]
    public class AngularSpeedExtension : MarkupExtension
    {
        public AngularSpeedExtension(string value)
        {
            this.Value = AngularSpeed.Parse(value, CultureInfo.InvariantCulture);
        }

        public AngularSpeed Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}