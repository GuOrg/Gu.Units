namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Density))]
    public class DensityExtension : MarkupExtension
    {
        public DensityExtension(string value)
        {
            this.Value = Density.Parse(value, CultureInfo.InvariantCulture);
        }

        public Density Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}