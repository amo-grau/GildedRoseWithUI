using GuildedRose.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.Unit
{
    public class InventoryTableModelTests
    {
        Inventory inventory = new();
        private Mock<InventoryListener> inventoryListenerMock = new Mock<InventoryListener>();

        public InventoryTableModelTests()
        {
            inventory.AddInventoryListener(inventoryListenerMock.Object);
        }

        [Fact]
        public void AddItemWhenRequestedAndNotifyListeners()
        {
            var item = new Item("anItem");
            inventory.AddItemToInventory(item);

            Assert.Equal(item, inventory.GetItemByName(item.Name));
            inventoryListenerMock.Verify(listener => listener.NewItemAdded(item), Times.Once);
        }
    }
}
