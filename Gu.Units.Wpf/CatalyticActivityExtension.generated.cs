namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(CatalyticActivity))]
    public class CatalyticActivityExtension : MarkupExtension
    {
        public CatalyticActivityExtension(string value)
        {
            this.Value = CatalyticActivity.Parse(value, CultureInfo.InvariantCulture);
        }

        public CatalyticActivity Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}