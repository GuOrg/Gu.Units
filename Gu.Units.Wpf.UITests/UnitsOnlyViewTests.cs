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
                var cmTemplateBox = page.Get<TextBox>(AutomationIds.CentimetresInControlTemplate);
                var mBox = page.Get<TextBox>(AutomationIds.MetresCtor);
                var mmBox = page.Get<TextBox>(AutomationIds.MillimetresProp);
                var mmDoubleBox = (TextBox)page.Get<UIItem>(AutomationIds.DoubleControlMillimetresStringCtor).Get(SearchCriteria.ByControlType(typeof(TextBox), WindowsFramework.Wpf));

                cmBox.Enter(text);
                mmBox.Click();
                Assert.AreEqual("67.89", mmBox.Text);
                Assert.AreEqual(text.Trim(), cmTemplateBox.Text);
                Assert.AreEqual("67.89", mmDoubleBox.Text);
                Assert.AreEqual("0.06789", mBox.Text);
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
                var cmBox = page.Get<TextBox>(AutomationIds.CentimetresStringCtor);
                var mBox = page.Get<TextBox>(AutomationIds.MetresCtor);
                var mmBox = page.Get<TextBox>(AutomationIds.MillimetresProp);
                var mmDoubleBox = (TextBox)page.Get<UIItem>(AutomationIds.DoubleControlMillimetresStringCtor).Get(SearchCriteria.ByControlType(typeof(TextBox), WindowsFramework.Wpf));

                mmDoubleBox.Enter("6789");
                mmBox.Click();
                Assert.AreEqual("6789", mmBox.Text);
                Assert.AreEqual("678.9", cmBox.Text);
                Assert.AreEqual("6.789", mBox.Text);
            }
        }
    }
}
