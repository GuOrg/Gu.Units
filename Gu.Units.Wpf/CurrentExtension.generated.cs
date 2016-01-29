namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Current))]
    public class CurrentExtension : MarkupExtension
    {
        public CurrentExtension(Current value)
        {
            this.Value = value;
        }

        public Current Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}