namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Volume))]
    public class VolumeExtension : MarkupExtension
    {
        public VolumeExtension(string value)
        {
            this.Value = Volume.Parse(value, CultureInfo.InvariantCulture);
        }

        public Volume Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}