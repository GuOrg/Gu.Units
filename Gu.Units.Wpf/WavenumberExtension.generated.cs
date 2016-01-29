namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Wavenumber))]
    public class WavenumberExtension : MarkupExtension
    {
        public WavenumberExtension(Wavenumber value)
        {
            this.Value = value;
        }

        public Wavenumber Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}