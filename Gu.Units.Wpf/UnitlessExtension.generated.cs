namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Unitless))]
    public class UnitlessExtension : MarkupExtension
    {
        public UnitlessExtension(Unitless value)
        {
            this.Value = value;
        }

        public Unitless Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}