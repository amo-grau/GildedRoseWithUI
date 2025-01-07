using GuildedRose.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.Unit
{
    public class InventoryTests
    {
        Inventory inventory = new();
        private Mock<InventoryListener> inventoryListenerMock = new Mock<InventoryListener>();

        public InventoryTests()
        {
            inventory.AddInventoryListener(inventoryListenerMock.Object);
        }

        [Fact]
        public void AddItemWhenRequested()
        {
            var item = new Item("anItem");
            inventory.AddItemToInventory(item);

            Assert.Equal(item, inventory.GetItemByName(item.Name));
            inventoryListenerMock.Verify(listener => listener.NewItemAdded(item), Times.Once);
        }
        
        [Fact]
        public void RemoveItemWhenRequested()
        {
            var item = new Item("anItem");
            inventory.AddItemToInventory(item);

            inventory.RemoveItemFromInventory(item);

            Assert.DoesNotContain(item, inventory.Items);
            inventoryListenerMock.Verify(listener => listener.ItemRemoved(item), Times.Once);
        }
    }
}
