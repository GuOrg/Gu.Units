namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AngularJerk))]
    public class AngularJerkExtension : MarkupExtension
    {
        public AngularJerkExtension(string value)
        {
            this.Value = AngularJerk.Parse(value, CultureInfo.InvariantCulture);
        }

        public AngularJerk Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}