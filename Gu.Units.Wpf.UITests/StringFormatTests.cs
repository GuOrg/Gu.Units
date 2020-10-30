namespace Gu.Units.Wpf.UITests
{
    using Gu.Units.Wpf.Demo;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    // ⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹
    public class StringFormatTests
    {
        [TestCase("6.78cm")]
        [TestCase("67.8mm")]
        public void HappyPath(string text)
        {
            using (var app = Application.Launch(Info.ExeFileName, "StringFormatWindow"))
            {
                var window = app.MainWindow;
                var converterMmBox = window.FindTextBox(AutomationIds.F3MmStringFormat);
                var converterCmBox = window.FindTextBox(AutomationIds.F2CmStringFormat);

                converterCmBox.Enter(text);
                converterMmBox.Click();
                Assert.AreEqual("67.800 mm", window.FindTextBox(AutomationIds.F3MmStringFormat).Text);
                Assert.AreEqual("6.78 cm", window.FindTextBox(AutomationIds.F2CmBindingStringFormat).Text);
                Assert.AreEqual("6.78 cm", window.FindTextBox(AutomationIds.F2CmStringFormat).Text);
                Assert.AreEqual("6.78 cm", window.FindTextBox(AutomationIds.F2CmInDataTemplate).Text);
                Assert.AreEqual("6.78 cm", window.FindTextBox(AutomationIds.F2CmBindingStringFormatInControlTemplate).Text);
                Assert.AreEqual("6.78", window.FindTextBox(AutomationIds.CmF2BindingStringFormat).Text);
                Assert.AreEqual("1200.00\u00A0mm⋅s⁻¹", window.FindTextBox(AutomationIds.MillimetresPerSecondSignedSuperScriptAndValueFormatF2).Text);
                Assert.AreEqual("1200.00", window.FindTextBox(AutomationIds.MillimetresPerSecondAndValueFormatF2).Text);
                Assert.AreEqual("67.8", window.FindTextBox(AutomationIds.MillimetresDoubleBox).Text);
            }
        }
    }
}