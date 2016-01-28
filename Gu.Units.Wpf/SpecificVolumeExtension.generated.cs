namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(SpecificVolume))]
    public class SpecificVolumeExtension : MarkupExtension
    {
        public SpecificVolumeExtension(string value)
        {
            this.Value = SpecificVolume.Parse(value, CultureInfo.InvariantCulture);
        }

        public SpecificVolume Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}