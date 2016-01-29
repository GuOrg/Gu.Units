namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(MassFlow))]
    public class MassFlowExtension : MarkupExtension
    {
        public MassFlowExtension(MassFlow value)
        {
            this.Value = value;
        }

        public MassFlow Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}