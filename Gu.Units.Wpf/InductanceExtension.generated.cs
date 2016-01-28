namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Inductance))]
    public class InductanceExtension : MarkupExtension
    {
        public InductanceExtension(string value)
        {
            this.Value = Inductance.Parse(value, CultureInfo.InvariantCulture);
        }

        public Inductance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}