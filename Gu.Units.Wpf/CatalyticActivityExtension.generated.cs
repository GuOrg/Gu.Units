namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(CatalyticActivity))]
    public class CatalyticActivityExtension : MarkupExtension
    {
        public CatalyticActivityExtension(CatalyticActivity value)
        {
            this.Value = value;
        }

        public CatalyticActivity Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}