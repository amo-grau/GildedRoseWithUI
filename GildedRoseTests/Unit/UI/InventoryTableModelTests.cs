using GuildedRose.Model;
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
        private readonly InventoryTableModel tableModel = new (null);
        private Mock<UserRequestListener> userRequestListenerMock = new ();

        [Fact]
        public void AddItemRowWhenItemIsAdded()
        {
            var anItem = new Item("anItem");
            
            tableModel.NewItemAdded(anItem);

            Assert.Equal(anItem, tableModel.GetItemAt(0));
            Assert.Equal(1, tableModel.RowCount);
        }

        [Fact]
        public void InsertMultipleItems()
        {
            foreach (var index  in Enumerable.Range(0, 5))
            {
                var item = new Item(index.ToString());
                tableModel.NewItemAdded(item);

                Assert.Equal(item, tableModel.GetItemAt(index));
            }
        }

        [Fact]
        public void NotifiesListenersWhenRemoveButtonClicked()
        {
            var item = new Item("anItem");
            tableModel.NewItemAdded(item);
            var removeButton = tableModel.Controls.Find($"{item.Name}RemoveButton", false).First() as Button 
                ?? throw new ArgumentNullException();

            removeButton.PerformClick();

            userRequestListenerMock.Verify(listener => listener.RemovedItemFromInventory(item.Name), Times.Once);
        }
    }
}
