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
            var anItem = "an item";
            
            tableModel.NewItemAdded(anItem);

            Assert.Equal(anItem, tableModel.Controls[0].Text);
            Assert.Equal(1, tableModel.RowCount);
        }

        [Fact]
        public void ItemsAreInsertedAfterTheNextOne()
        {
            var item1 = "item1";
            var item2 = "item2";

            tableModel.NewItemAdded(item1);
            tableModel.NewItemAdded(item2);

            Assert.Equal(item1, tableModel.Controls[0].Text);
            Assert.Equal(item2, tableModel.Controls[1].Text);
        }
    }
}
