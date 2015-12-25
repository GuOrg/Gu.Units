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
                var converterCmBox = page.Get<TextBox>(AutomationIds.ConverterCentimetreFormat);
                var converterMmBox = page.Get<TextBox>(AutomationIds.ConverterMillimetreFormat);
                var bindinCmBox = page.Get<TextBox>(AutomationIds.BindingCentimetreFormat);

                converterCmBox.Enter(text);
                converterMmBox.Click();
                Assert.AreEqual("6.78 cm", converterCmBox.Text);
                Assert.AreEqual("67.800 mm", converterMmBox.Text);
                Assert.AreEqual("6.78 cm", bindinCmBox.Text);
            }
        }
    }
}