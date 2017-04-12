namespace Gu.Units.Wpf
{
    using System.ComponentModel;
    using System.Windows;

    internal static class Is
    {
        // not readonly to be able to hack it in tests.
#pragma warning disable SA1401 // Fields must be private
        internal static bool DesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
#pragma warning restore SA1401 // Fields must be private
    }
}
