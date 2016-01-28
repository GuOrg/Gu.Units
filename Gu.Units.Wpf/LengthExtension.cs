namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Length))]
    public class LengthExtension : MarkupExtension
    {
        public LengthExtension(string value)
        {
            this.Value = Length.Parse(value);
        }

        public Length Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}