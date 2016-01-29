namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(AngularJerk))]
    public class AngularJerkExtension : MarkupExtension
    {
        public AngularJerkExtension(AngularJerk value)
        {
            this.Value = value;
        }

        public AngularJerk Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}