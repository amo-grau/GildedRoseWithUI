using FlaUI.Core;

namespace GildedRoseTests.EndToEnd
{
    internal class ApplicationRunner
    {
        private readonly ApplicationDriver driver = new ();

        internal void AddItemToInventory(string itemName)
        {            
            driver.AddItem(itemName);   
        }

        internal void Close()
        {
            driver.Close();
        }

        internal void ShowAddedItem(string itemName)
        {
            driver.ShowsIsListed(itemName);
        }
    }
}
