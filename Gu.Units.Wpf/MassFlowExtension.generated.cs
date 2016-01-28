namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(MassFlow))]
    public class MassFlowExtension : MarkupExtension
    {
        public MassFlowExtension(string value)
        {
            this.Value = MassFlow.Parse(value, CultureInfo.InvariantCulture);
        }

        public MassFlow Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}