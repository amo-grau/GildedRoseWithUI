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
        private readonly InventoryTableModel tableModel = new ();

        [Fact]
        public void AddItemRowWhenItemIsAdded()
        {
            var anItem = new Item("anItem");
            
            tableModel.NewItemAdded(anItem);

            Assert.Equal(anItem, tableModel.GetItemAt(0));
            Assert.Equal(1, tableModel.RowCount);
        }

        [Fact]
        public void ItemsAreInsertedAfterTheNextOne()
        {
            var item1 = new Item("item1");
            var item2 = new Item("item2");

            tableModel.NewItemAdded(item1);
            tableModel.NewItemAdded(item2);

            Assert.Equal(item1, tableModel.GetItemAt(0));
            Assert.Equal(item2, tableModel.GetItemAt(1));
        }
    }
}
