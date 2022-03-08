namespace Gu.Units.Wpf.UITests
{
    using Gu.Units.Wpf.Demo;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    // ⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹
    public static class SymbolFormatTests
    {
        [TestCase("6.789E6Pa")]
        [TestCase("6.789MPa")]
        [TestCase("6.789N^1*mm^-2")]
        public static void HappyPath(string text)
        {
            using (var app = Application.Launch(Info.ExeFileName, "SymbolFormatWindow"))
            {
                var window = app.MainWindow;
                var fractionHatBox = window.FindTextBox(AutomationIds.FractionHatPowers);
                var fractionSuperScriptBox = window.FindTextBox(AutomationIds.FractionSuperScript);
                var signedHatBox = window.FindTextBox(AutomationIds.SignedHatPowers);
                var signedSuperscriptBox = window.FindTextBox(AutomationIds.SignedSuperScript);

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
