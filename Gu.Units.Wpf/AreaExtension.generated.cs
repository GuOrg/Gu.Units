namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Area))]
    public class AreaExtension : MarkupExtension
    {
        public AreaExtension(Area value)
        {
            this.Value = value;
        }

        public Area Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}