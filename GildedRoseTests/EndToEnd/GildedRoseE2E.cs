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
        public void AnItemIsAdded()
        {
            var item = new Item("an item");
            driver.AddItem(item);
            driver.showIsListed(item);
        }

        [Fact]
        public void AnItemIsRemoved()
        {
            var item = new Item("an item");
            driver.AddItem(item);

            driver.RemoveItem(item.Name);
            driver.showIsNotListed(item);
        }
    }
}
