using GuildedRose;
using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.EndToEnd
{
    public class GildedRoseE2E : IAsyncLifetime
    {
        private readonly Inventory inventory = new Inventory();
        private readonly FormDriver driver;

        public GildedRoseE2E()
        {
            driver = new FormDriver(new MainForm(inventory));
        }

        public Task InitializeAsync()
        {
            // Do nothing
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            driver.Close();
            return Task.CompletedTask;
        }

        [Fact]
        public void AnItemIsAddedToTheSystem()
        {
            var item = new Item("an item");
            driver.AddItem(item);
            driver.showIsAdded(item);
        }

        [Fact]
        public void AnItemIsRemovedFromTheSystem()
        {
            var item = new Item("an item");
            driver.AddItem(item);

            driver.RemoveItem(item.Name);
            driver.showIsRemoved(item);
        }
    }
}
