namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Data))]
    public class DataExtension : MarkupExtension
    {
        public DataExtension(Data value)
        {
            this.Value = value;
        }

        public Data Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}