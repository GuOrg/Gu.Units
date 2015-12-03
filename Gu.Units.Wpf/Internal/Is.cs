namespace Gu.Units.Wpf
{
    using System.ComponentModel;
    using System.Windows;

    internal static class Is
    {
        // not readonly to be able to hack it in tests.
        internal static bool DesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
    }
}
