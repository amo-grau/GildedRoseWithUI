
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace GildedRoseTests.EndToEnd
{
    internal class ApplicationDriver
    {
        private const string AppExecutablePath = "C:\\Users\\15osc\\source\\repos\\GildedRose\\GuildedRose\\bin\\Debug\\net8.0-windows\\GuildedRoseUI.exe";
        private readonly Application app;
        private readonly Window window;

        internal ApplicationDriver()
        {
            app = Application.Launch(AppExecutablePath);
            using (var automation = new UIA3Automation())
            {
                window = app.GetMainWindow(automation);
            }
        }

        internal void AddItem(string itemName)
        {
            var newItemTextBox = Find("itemTextBox").AsTextBox();
            newItemTextBox.Focus();
            newItemTextBox.Enter(itemName);

            var addItemButton = Find("addItemButton").AsButton();
            addItemButton.Click();

            app.WaitWhileBusy(new TimeSpan(1000));
        }

        internal void ShowsIsListed(string itemName)
        {
            var itemLabel = Find("itemLabel").AsLabel();
            Assert.Equal(itemName, itemLabel.Text);
        }

        internal void Close()
        {
            app.Close();
        }

        public AutomationElement Find(string elementName)
        {
            return window.FindFirstDescendant(cf 
                => cf.ByAutomationId(elementName))?? 
                throw new ArgumentException($"Window does not contain element with name: {elementName}");
        }
    }
}