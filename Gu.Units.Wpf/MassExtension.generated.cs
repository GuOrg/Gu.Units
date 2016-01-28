namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Mass))]
    public class MassExtension : MarkupExtension
    {
        public MassExtension(string value)
        {
            this.Value = Mass.Parse(value, CultureInfo.InvariantCulture);
        }

        public Mass Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}