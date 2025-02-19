﻿using GuildedRose.Model;
using GuildedRose.UI;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GildedRoseTests.Unit.UI
{
    public class InventoryTableModelTests
    {
        private readonly InventoryTableModel tableModel = new (new TableLayoutControl(Enum.GetNames(typeof(ItemProperties)).Length));
        private Mock<UserRequestListener> userRequestListenerMock = new ();

        public InventoryTableModelTests()
        {
            tableModel.AddListener(userRequestListenerMock.Object);
        }

        [Fact]
        public void AddItemRowWhenItemIsAdded()
        {
            var anItem = new Item("anItem");
            
            tableModel.ItemAdded(anItem);

            Assert.Equal(anItem, tableModel.GetItemAt(0));
            Assert.Equal(1, tableModel.ItemCount);
        }

        [Fact]
        public void InsertMultipleItems()
        {
            foreach (var index  in Enumerable.Range(0, 5))
            {
                var item = new Item(index.ToString());
                tableModel.ItemAdded(item);

                Assert.Equal(item, tableModel.GetItemAt(index));
            }
        }

        [Fact]
        public void NotifiesListenersWhenRemoveButtonClicked()
        {
            var item = new Item("anItem");
            tableModel.ItemAdded(item);

            tableModel.RemoveButtonFor(item).PerformClick();

            userRequestListenerMock.Verify(listener => listener.RemoveItemFromInventory(item), Times.Once);
        }

        [Fact]
        public void RemoveItemWhenRequested()
        {
            var anItem = new Item("anItem");
            tableModel.ItemAdded(anItem);

            tableModel.ItemRemoved(anItem);

            Assert.Equal(0, tableModel.ItemCount);
        }
    }
}
