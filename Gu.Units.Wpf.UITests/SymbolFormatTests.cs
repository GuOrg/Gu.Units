namespace Gu.Units.Wpf.UITests
{
    using Demo;
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.Factory;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.TabItems;

    public class SymbolFormatTests
    {
        private static readonly string TabId = AutomationIds.SymbolFormatTab;
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';

        [TestCase("6.789E6Pa")]
        [TestCase("6.789MPa")]
        [TestCase("6.789N^1*mm^-2")]
        public void HappyPath(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var fractionHatBox = page.Get<TextBox>(AutomationIds.FractionHatPowers);
                var fractionSuperScriptBox = page.Get<TextBox>(AutomationIds.FractionSuperScript);
                var signedHatBox = page.Get<TextBox>(AutomationIds.SignedHatPowers);
                var signedSuperscriptBox = page.Get<TextBox>(AutomationIds.SignedSuperScript);

                fractionHatBox.Enter(text);
                fractionSuperScriptBox.Click();
                Assert.AreEqual("6.789\u00A0N/mm^2", fractionHatBox.Text);
                Assert.AreEqual("6.789\u00A0N/mm²", fractionSuperScriptBox.Text);
                Assert.AreEqual("6.789\u00A0N*mm^-2", signedHatBox.Text);
                Assert.AreEqual("6.789\u00A0N⋅mm⁻²", signedSuperscriptBox.Text);
            }
        }
    }
}