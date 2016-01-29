namespace Gu.Units.Wpf.UITests
{
    using Demo;
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.Factory;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.TabItems;
    using TestStack.White.UIItems.WPFUIItems;

    public class UnitsOnlyViewTests
    {
        private static readonly string TabId = AutomationIds.UnitsOnlyTab;

        [TestCase("abc")]
        [TestCase("6.789 cm")]
        [TestCase("6,789")]
        public void IllegalInputCausesValidationError(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var cmBox = page.Get<TextBox>(AutomationIds.CentimetresStringCtor);
                var mmBox = page.Get<TextBox>(AutomationIds.MillimetresProp);

                var mmBefore = mmBox.Text;
                cmBox.Enter(text);
                mmBox.Click();
                Assert.AreEqual("HasValidationError: True", cmBox.ItemStatus());
                Assert.AreEqual(mmBefore, mmBox.Text);
            }
        }

        [TestCase("6.789")]
        [TestCase(" 6.789")]
        [TestCase(" 6.789 ")]
        public void ChangeCentimetresUpdatesCorrectly(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var cmBox = page.Get<TextBox>(AutomationIds.CentimetresStringCtor);
                var mmBox = page.Get<TextBox>(AutomationIds.MillimetresProp);

                cmBox.Enter(text);
                mmBox.Click();

                Assert.AreEqual("6.789", page.Get<TextBox>(AutomationIds.CentimetresStringCtor).Text);
                Assert.AreEqual("1200", page.Get<TextBox>(AutomationIds.MillimetresPerSecondStringProp).Text);
                Assert.AreEqual("0.06789", page.Get<TextBox>(AutomationIds.MetresCtor).Text);
                Assert.AreEqual("67.89", page.Get<TextBox>(AutomationIds.MillimetresProp).Text);
                Assert.AreEqual("67.89", page.Get<TextBox>(AutomationIds.DoubleBoxMillimetresStringCtor).Text);
                Assert.AreEqual("1234.567", page.Get<TextBox>(AutomationIds.DoubleBoxNullableMillimetresStringCtor).Text);
                Assert.AreEqual("1.23", page.Get<TextBox>(AutomationIds.DoubleBoxNewtonsPerSquareMillimetreStringCtor).Text);
                Assert.AreEqual("1.23", page.Get<TextBox>(AutomationIds.DoubleBoxMPaStringCtor).Text);
                Assert.AreEqual("67.89", page.Get<TextBox>(AutomationIds.MillimetresInDataTemplate).Text);
                Assert.AreEqual("6.79", page.Get<TextBox>(AutomationIds.F2CmBindingStringFormatInControlTemplate).Text);
                Assert.AreEqual("123.4567", page.Get<TextBox>(AutomationIds.NullableLengthCm).Text);
            }
        }

        [Test]
        public void ChangeDoubleMillimetresUpdatesCorrectly()
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var mmBox = page.Get<TextBox>(AutomationIds.MillimetresProp);
                var mmDoubleBox = page.Get<TextBox>(AutomationIds.DoubleBoxMillimetresStringCtor);

                mmDoubleBox.Enter("6789");
                mmBox.Click();
                Assert.AreEqual("678.9", page.Get<TextBox>(AutomationIds.CentimetresStringCtor).Text);
                Assert.AreEqual("1200", page.Get<TextBox>(AutomationIds.MillimetresPerSecondStringProp).Text);
                Assert.AreEqual("6.789", page.Get<TextBox>(AutomationIds.MetresCtor).Text);
                Assert.AreEqual("6789", page.Get<TextBox>(AutomationIds.MillimetresProp).Text);
                Assert.AreEqual("6789", page.Get<TextBox>(AutomationIds.DoubleBoxMillimetresStringCtor).Text);
                Assert.AreEqual("1234.567", page.Get<TextBox>(AutomationIds.DoubleBoxNullableMillimetresStringCtor).Text);
                Assert.AreEqual("1.23", page.Get<TextBox>(AutomationIds.DoubleBoxNewtonsPerSquareMillimetreStringCtor).Text);
                Assert.AreEqual("1.23", page.Get<TextBox>(AutomationIds.DoubleBoxMPaStringCtor).Text);
                Assert.AreEqual("6789", page.Get<TextBox>(AutomationIds.MillimetresInDataTemplate).Text);
                Assert.AreEqual("678.90", page.Get<TextBox>(AutomationIds.F2CmBindingStringFormatInControlTemplate).Text);
                Assert.AreEqual("123.4567", page.Get<TextBox>(AutomationIds.NullableLengthCm).Text);
            }
        }
    }
}
