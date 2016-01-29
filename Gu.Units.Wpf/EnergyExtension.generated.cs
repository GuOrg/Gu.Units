namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Energy))]
    public class EnergyExtension : MarkupExtension
    {
        public EnergyExtension(Energy value)
        {
            this.Value = value;
        }

        public Energy Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}