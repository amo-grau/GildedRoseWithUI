using GuildedRose.Model;
using GuildedRose.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GildedRoseTests.EndToEnd
{
    internal class FormDriver : ApplicationDriver
    {
        private Form form;

        public FormDriver(Form form)
        {
            this.form = form;
            form.Show();
        }

        public void AddItem(Item itemName)
        {
            var itemTextBox = FindControl<TextBox>("itemTextBox");

            itemTextBox.Clear();
            itemTextBox.AppendText(itemName.Name);

            var addItemButton = FindControl<Button>("addItemButton");

            addItemButton.PerformClick();
        }

        public void RemoveItem(string name)
        {
            var removeButtonName = name + "RemoveButton";
            var removeButton = FindControl<Button>(removeButtonName);
            removeButton.PerformClick();
        }

        public void showIsListed(Item item)
        {
            var itemTable = FindControl<InventoryTableModel>("itemsTable");
            Assert.Equal(item, itemTable.GetItemAt(itemTable.RowCount - 1));
        }

        public void showIsNotListed(Item item)
        {
            var itemTable = FindControl<InventoryTableModel>("itemsTable");

            var items = Enumerable.Range(0, itemTable.RowCount)
                .Select(i => itemTable.GetItemAt(i))
                .ToList();

            Assert.DoesNotContain(item, items);
        }

        public void Close()
        {
            form.Close();
        }

        private T FindControl<T>(string name) where T : Control
        {
            return (T)form.Controls.Find(name, true).First();
        }
    }
}
