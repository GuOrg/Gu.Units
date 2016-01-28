namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Data))]
    public class DataExtension : MarkupExtension
    {
        public DataExtension(string value)
        {
            this.Value = Data.Parse(value, CultureInfo.InvariantCulture);
        }

        public Data Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}