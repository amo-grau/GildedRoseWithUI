using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.EndToEnd
{
    public class GildedRoseE2E : IAsyncLifetime
    {
        private readonly ApplicationRunner application = new ();
        public Task InitializeAsync()
        {
            // Do nothing
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            application.Close();
            return Task.CompletedTask;
        }

        [Fact]
        public void AnItemIsAddedToTheSystem()
        {
            var itemName = "an item";
            application.AddItemToInventory(itemName);
            application.ShowAddedItem(itemName);
        }

    }
}
