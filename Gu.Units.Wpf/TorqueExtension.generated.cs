namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Torque))]
    public class TorqueExtension : MarkupExtension
    {
        public TorqueExtension(Torque value)
        {
            this.Value = value;
        }

        public Torque Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}