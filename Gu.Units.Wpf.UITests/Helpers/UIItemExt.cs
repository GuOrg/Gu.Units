namespace Gu.Units.Wpf.UITests
{
    using System.Windows.Automation;
    using TestStack.White.UIItems;

    public static class UIItemExt
    {
        public static string ItemStatus(this IUIItem item)
        {
            return (string)item.AutomationElement.GetCurrentPropertyValue(AutomationElementIdentifiers.ItemStatusProperty);
        }
    }
}