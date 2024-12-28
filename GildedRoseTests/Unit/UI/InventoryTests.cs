using GuildedRose.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.Unit.UI
{
    public class InventoryTests
    {
        Inventory inventory = new ();
        private Mock<InventoryListener> inventoryListenerMock = new Mock<InventoryListener>();

        public InventoryTests()
        {
            inventory.AddInventoryListener(inventoryListenerMock.Object);
        }

        [Fact]
        public void AddItemWhenRequestedAndNotifyListeners()
        {
            var itemName = "an item";
            inventory.AddItemToInventory(itemName);

            Assert.Equal(itemName, inventory.GetItemByName(itemName));
            inventoryListenerMock.Verify(listener => listener.NewItemAdded(itemName), Times.Once);
        }
    }
}
