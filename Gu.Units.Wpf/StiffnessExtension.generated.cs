namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Stiffness))]
    public class StiffnessExtension : MarkupExtension
    {
        public StiffnessExtension(Stiffness value)
        {
            this.Value = value;
        }

        public Stiffness Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}