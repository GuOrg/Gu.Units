namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Torque))]
    public class TorqueExtension : MarkupExtension
    {
        public TorqueExtension(string value)
        {
            this.Value = Torque.Parse(value, CultureInfo.InvariantCulture);
        }

        public Torque Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}