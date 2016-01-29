namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Density))]
    public class DensityExtension : MarkupExtension
    {
        public DensityExtension(Density value)
        {
            this.Value = value;
        }

        public Density Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}