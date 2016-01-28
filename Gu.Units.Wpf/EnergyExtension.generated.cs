namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Energy))]
    public class EnergyExtension : MarkupExtension
    {
        public EnergyExtension(string value)
        {
            this.Value = Energy.Parse(value, CultureInfo.InvariantCulture);
        }

        public Energy Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}