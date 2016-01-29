namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Mass))]
    public class MassExtension : MarkupExtension
    {
        public MassExtension(Mass value)
        {
            this.Value = value;
        }

        public Mass Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}