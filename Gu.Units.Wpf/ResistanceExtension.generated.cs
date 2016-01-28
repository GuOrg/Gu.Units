namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Resistance))]
    public class ResistanceExtension : MarkupExtension
    {
        public ResistanceExtension(string value)
        {
            this.Value = Resistance.Parse(value, CultureInfo.InvariantCulture);
        }

        public Resistance Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}