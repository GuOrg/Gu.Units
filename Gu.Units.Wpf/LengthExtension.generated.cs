namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Length))]
    public class LengthExtension : MarkupExtension
    {
        public LengthExtension(Length value)
        {
            this.Value = value;
        }

        public Length Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}