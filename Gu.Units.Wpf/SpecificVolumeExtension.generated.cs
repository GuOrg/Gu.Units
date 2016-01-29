namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(SpecificVolume))]
    public class SpecificVolumeExtension : MarkupExtension
    {
        public SpecificVolumeExtension(SpecificVolume value)
        {
            this.Value = value;
        }

        public SpecificVolume Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}