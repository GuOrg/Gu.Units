namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Wavenumber))]
    public class WavenumberExtension : MarkupExtension
    {
        public WavenumberExtension(string value)
        {
            this.Value = Wavenumber.Parse(value, CultureInfo.InvariantCulture);
        }

        public Wavenumber Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}