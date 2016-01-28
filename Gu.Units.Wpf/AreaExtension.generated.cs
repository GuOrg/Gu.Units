namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Area))]
    public class AreaExtension : MarkupExtension
    {
        public AreaExtension(string value)
        {
            this.Value = Area.Parse(value, CultureInfo.InvariantCulture);
        }

        public Area Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}