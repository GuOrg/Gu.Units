namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Momentum))]
    public class MomentumExtension : MarkupExtension
    {
        public MomentumExtension(Momentum value)
        {
            this.Value = value;
        }

        public Momentum Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}