namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Current))]
    public class CurrentExtension : MarkupExtension
    {
        public CurrentExtension(string value)
        {
            this.Value = Current.Parse(value, CultureInfo.InvariantCulture);
        }

        public Current Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}