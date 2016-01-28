namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Force))]
    public class ForceExtension : MarkupExtension
    {
        public ForceExtension(string value)
        {
            this.Value = Force.Parse(value, CultureInfo.InvariantCulture);
        }

        public Force Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}