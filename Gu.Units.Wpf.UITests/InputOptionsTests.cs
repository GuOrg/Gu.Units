namespace Gu.Units.Wpf.UITests
{
    using Demo;
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.Factory;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.TabItems;

    public class InputOptionsTests
    {
        private static readonly string TabId = AutomationIds.InputOptionsTab;

        [TestCase("abc")]
        [TestCase("6.789 cm")]
        [TestCase("6,789")]
        public void ScalarOnlyError(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var scalarBox = page.Get<TextBox>(AutomationIds.ScalarOnly);
                var symbolAllowedBox = page.Get<TextBox>(AutomationIds.SymbolAllowed);

                var before = symbolAllowedBox.Text;
                Assert.AreEqual("HasValidationError: False", scalarBox.ItemStatus());

                scalarBox.Enter(text);
                symbolAllowedBox.Click();
                Assert.AreEqual("HasValidationError: True", scalarBox.ItemStatus());
                Assert.AreEqual(before, symbolAllowedBox.Text);
            }
        }

        [TestCase("6.789")]
        [TestCase(" 6.789")]
        [TestCase(" 6.789 ")]
        public void ScalarOnlyHappyPath(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var scalarBox = page.Get<TextBox>(AutomationIds.ScalarOnly);
                var symbolAllowedBox = page.Get<TextBox>(AutomationIds.SymbolAllowed);
                var symbolRequiredBox = page.Get<TextBox>(AutomationIds.SymbolRequired);

                scalarBox.Enter(text);
                symbolAllowedBox.Click();
                Assert.AreEqual("6.789", scalarBox.Text);
                Assert.AreEqual("6789", symbolAllowedBox.Text);
                Assert.AreEqual("678.9\u00A0cm", symbolRequiredBox.Text);
            }
        }

        [TestCase("6789")]
        [TestCase(" 6789")]
        [TestCase(" 6789 ")]
        [TestCase(" 6789mm ")]
        [TestCase(" 6789 mm ")]
        [TestCase(" 6.789m ")]
        [TestCase(" 6.789 m ")]
        public void SymbolAllowedHappyPath(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var scalarBox = page.Get<TextBox>(AutomationIds.ScalarOnly);
                var symbolAllowedBox = page.Get<TextBox>(AutomationIds.SymbolAllowed);
                var symbolRequiredBox = page.Get<TextBox>(AutomationIds.SymbolRequired);

                symbolAllowedBox.Enter(text);
                scalarBox.Click();
                Assert.AreEqual("6.789", scalarBox.Text);
                Assert.AreEqual("6789", symbolAllowedBox.Text);
                Assert.AreEqual("678.9\u00A0cm", symbolRequiredBox.Text);
            }
        }

        [TestCase("abc")]
        [TestCase("6.789 mm/s")]
        [TestCase("6,789")]
        public void SymbolAllowedError(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var scalarBox = page.Get<TextBox>(AutomationIds.ScalarOnly);
                var symbolAllowedBox = page.Get<TextBox>(AutomationIds.SymbolAllowed);
                var symbolRequiredBox = page.Get<TextBox>(AutomationIds.SymbolRequired);

                var before = scalarBox.Text;
                Assert.AreEqual("HasValidationError: False", symbolAllowedBox.ItemStatus());

                symbolAllowedBox.Enter(text);
                scalarBox.Click();
                Assert.AreEqual("HasValidationError: True", symbolAllowedBox.ItemStatus());
                Assert.AreEqual(before, scalarBox.Text);
            }
        }

        [TestCase(" 6789mm ")]
        [TestCase(" 6789 mm ")]
        [TestCase(" 6.789m ")]
        [TestCase(" 6.789 m ")]
        [TestCase(" 678.9 cm ")]
        public void SymbolRequiredHappyPath(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var scalarBox = page.Get<TextBox>(AutomationIds.ScalarOnly);
                var symbolAllowedBox = page.Get<TextBox>(AutomationIds.SymbolAllowed);
                var symbolRequiredBox = page.Get<TextBox>(AutomationIds.SymbolRequired);

                symbolRequiredBox.Enter(text);
                scalarBox.Click();
                Assert.AreEqual("6.789", scalarBox.Text);
                Assert.AreEqual("6789", symbolAllowedBox.Text);
                Assert.AreEqual("678.9\u00A0cm", symbolRequiredBox.Text);
            }
        }

        [TestCase("abc")]
        [TestCase("6.789 mm/s")]
        [TestCase("6.789")]
        public void SymbolSymbolRequiredError(string text)
        {
            using (var app = Application.AttachOrLaunch(Info.ProcessStartInfo))
            {
                var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                var page = window.Get<TabPage>(TabId);
                page.Select();
                var scalarBox = page.Get<TextBox>(AutomationIds.ScalarOnly);
                var symbolAllowedBox = page.Get<TextBox>(AutomationIds.SymbolAllowed);
                var symbolRequiredBox = page.Get<TextBox>(AutomationIds.SymbolRequired);

                var before = scalarBox.Text;
                Assert.AreEqual("HasValidationError: False", symbolRequiredBox.ItemStatus());
                symbolRequiredBox.Enter(text);
                scalarBox.Click();
                Assert.AreEqual("HasValidationError: True", symbolRequiredBox.ItemStatus());
                Assert.AreEqual(before, scalarBox.Text);
            }
        }
    }
}