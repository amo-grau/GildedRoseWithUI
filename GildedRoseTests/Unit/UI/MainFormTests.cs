using GildedRoseTests.EndToEnd;
using GuildedRose;
using GuildedRose.Model;
using GuildedRose.UI;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GildedRoseTests.Unit.UI
{
    public class MainFormTests
    {
        private Form form;
        private Mock<Inventory> inventory = new ();

        public MainFormTests()
        {
            form = new MainForm(inventory.Object);
        }

        [Fact]
        public void TableStartsWithoutItems()
        {
            var table = form.Controls.Find("itemsTable", true).First() as TableLayoutControl;
            
            Assert.NotNull(table);
            Assert.Equal(0, table.RowCount);
        }
    }
}
