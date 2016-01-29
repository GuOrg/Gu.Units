namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(VolumetricFlow))]
    public class VolumetricFlowExtension : MarkupExtension
    {
        public VolumetricFlowExtension(VolumetricFlow value)
        {
            this.Value = value;
        }

        public VolumetricFlow Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}