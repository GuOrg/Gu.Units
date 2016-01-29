namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Jerk))]
    public class JerkExtension : MarkupExtension
    {
        public JerkExtension(Jerk value)
        {
            this.Value = value;
        }

        public Jerk Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}