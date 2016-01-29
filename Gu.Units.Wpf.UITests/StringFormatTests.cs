namespace Gu.Units.Wpf.UITests
{
    using Demo;
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.Factory;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.TabItems;

    public class StringFormatTests
    {
        private static readonly string TabId = AutomationIds.StringFormatTab;
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';

        [TestCase("6.78cm")]
        [TestCase("67.8mm")]
        public void HappyPath(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var converterMmBox = page.Get<TextBox>(AutomationIds.F3MmStringFormat);
                var converterCmBox = page.Get<TextBox>(AutomationIds.F2CmStringFormat);

                converterCmBox.Enter(text);
                converterMmBox.Click();
                Assert.AreEqual("67.800 mm", page.Get<TextBox>(AutomationIds.F3MmStringFormat).Text);
                Assert.AreEqual("6.78 cm", page.Get<TextBox>(AutomationIds.F2CmBindingStringFormat).Text);
                Assert.AreEqual("6.78 cm", page.Get<TextBox>(AutomationIds.F2CmStringFormat).Text);
                Assert.AreEqual("6.78 cm", page.Get<TextBox>(AutomationIds.F2CmInDataTemplate).Text);
                Assert.AreEqual("6.78 cm", page.Get<TextBox>(AutomationIds.F2CmBindingStringFormatInControlTemplate).Text);
                Assert.AreEqual("6.78", page.Get<TextBox>(AutomationIds.CmF2BindingStringFormat).Text);
                Assert.AreEqual("1200.00\u00A0mm⋅s⁻¹", page.Get<TextBox>(AutomationIds.MillimetresPerSecondSignedSuperScriptAndValueFormatF2).Text);
                Assert.AreEqual("1200.00", page.Get<TextBox>(AutomationIds.MillimetresPerSecondAndValueFormatF2).Text);
                Assert.AreEqual("67.8", page.Get<TextBox>(AutomationIds.MillimetresDoubleBox).Text);
            }
        }
    }
}