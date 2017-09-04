namespace Gu.Units.Wpf.UITests
{
    using Demo;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class UnitsOnlyViewTests
    {
        [TestCase("abc")]
        [TestCase("6.789 cm")]
        [TestCase("6,789")]
        public void IllegalInputCausesValidationError(string text)
        {
            using (var app = Application.Launch(Info.ExeFileName, "UnitsOnlyWindow"))
            {
                var window = app.MainWindow;
                var cmBox = window.FindTextBox(AutomationIds.CentimetresStringCtor);
                var mmBox = window.FindTextBox(AutomationIds.MillimetresProp);

                var mmBefore = mmBox.Text;
                cmBox.Enter(text);
                mmBox.Click();
                Assert.AreEqual("HasValidationError: True", cmBox.ItemStatus);
                Assert.AreEqual(mmBefore, mmBox.Text);
            }
        }

        [TestCase("6.789")]
        [TestCase(" 6.789")]
        [TestCase(" 6.789 ")]
        public void ChangeCentimetresUpdatesCorrectly(string text)
        {
            using (var app = Application.Launch(Info.ExeFileName, "UnitsOnlyWindow"))
            {
                var window = app.MainWindow;
                var cmBox = window.FindTextBox(AutomationIds.CentimetresStringCtor);
                var mmBox = window.FindTextBox(AutomationIds.MillimetresProp);

                cmBox.Enter(text);
                mmBox.Click();

                Assert.AreEqual("6.789", window.FindTextBox(AutomationIds.CentimetresStringCtor).Text);
                Assert.AreEqual("1200", window.FindTextBox(AutomationIds.MillimetresPerSecondStringProp).Text);
                Assert.AreEqual("0.06789", window.FindTextBox(AutomationIds.MetresCtor).Text);
                Assert.AreEqual("67.89", window.FindTextBox(AutomationIds.MillimetresProp).Text);
                Assert.AreEqual("67.89", window.FindTextBox(AutomationIds.DoubleBoxMillimetresStringCtor).Text);
                Assert.AreEqual("1234.567", window.FindTextBox(AutomationIds.DoubleBoxNullableMillimetresStringCtor).Text);
                Assert.AreEqual("1.23", window.FindTextBox(AutomationIds.DoubleBoxNewtonsPerSquareMillimetreStringCtor).Text);
                Assert.AreEqual("1.23", window.FindTextBox(AutomationIds.DoubleBoxMPaStringCtor).Text);
                Assert.AreEqual("67.89", window.FindTextBox(AutomationIds.MillimetresInDataTemplate).Text);
                Assert.AreEqual("6.79", window.FindTextBox(AutomationIds.F2CmBindingStringFormatInControlTemplate).Text);
                Assert.AreEqual("123.4567", window.FindTextBox(AutomationIds.NullableLengthCm).Text);
            }
        }

        [Test]
        public void ChangeDoubleMillimetresUpdatesCorrectly()
        {
            using (var app = Application.Launch(Info.ExeFileName, "UnitsOnlyWindow"))
            {
                var window = app.MainWindow;
                var mmBox = window.FindTextBox(AutomationIds.MillimetresProp);
                var mmDoubleBox = window.FindTextBox(AutomationIds.DoubleBoxMillimetresStringCtor);

                mmDoubleBox.Enter("6789");
                mmBox.Click();
                Assert.AreEqual("678.9", window.FindTextBox(AutomationIds.CentimetresStringCtor).Text);
                Assert.AreEqual("1200", window.FindTextBox(AutomationIds.MillimetresPerSecondStringProp).Text);
                Assert.AreEqual("6.789", window.FindTextBox(AutomationIds.MetresCtor).Text);
                Assert.AreEqual("6789", window.FindTextBox(AutomationIds.MillimetresProp).Text);
                Assert.AreEqual("6789", window.FindTextBox(AutomationIds.DoubleBoxMillimetresStringCtor).Text);
                Assert.AreEqual("1234.567", window.FindTextBox(AutomationIds.DoubleBoxNullableMillimetresStringCtor).Text);
                Assert.AreEqual("1.23", window.FindTextBox(AutomationIds.DoubleBoxNewtonsPerSquareMillimetreStringCtor).Text);
                Assert.AreEqual("1.23", window.FindTextBox(AutomationIds.DoubleBoxMPaStringCtor).Text);
                Assert.AreEqual("6789", window.FindTextBox(AutomationIds.MillimetresInDataTemplate).Text);
                Assert.AreEqual("678.90", window.FindTextBox(AutomationIds.F2CmBindingStringFormatInControlTemplate).Text);
                Assert.AreEqual("123.4567", window.FindTextBox(AutomationIds.NullableLengthCm).Text);
            }
        }
    }
}
