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
        public void InsertMultipleItems()
        {
            foreach (var index  in Enumerable.Range(0, 5))
            {
                var item = new Item(index.ToString());
                tableModel.NewItemAdded(item);

                Assert.Equal(item, tableModel.GetItemAt(index));
            }
        }
    }
}
