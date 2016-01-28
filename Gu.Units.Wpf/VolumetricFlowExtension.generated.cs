namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(VolumetricFlow))]
    public class VolumetricFlowExtension : MarkupExtension
    {
        public VolumetricFlowExtension(string value)
        {
            this.Value = VolumetricFlow.Parse(value, CultureInfo.InvariantCulture);
        }

        public VolumetricFlow Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}