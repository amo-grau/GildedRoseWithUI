using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.UI
{
    public class InventoryTableModel : TableLayoutPanel, InventoryListener
    {
        public void NewItemAdded(Item item)
        {
            AddTextBoxControl(item.Name, DisplayedItemProperties.Name);
            AddTextBoxControl(item.SellIn.ToString(), DisplayedItemProperties.SellIn);

            RowCount++;
            RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
        }

        public Item GetItemAt(int row)
        {
            var lastItemName = GetControlAt(DisplayedItemProperties.Name, row);
            var lastItemSellIn = GetControlAt(DisplayedItemProperties.SellIn, row);

            return new Item(lastItemName.Text) { SellIn = int.Parse(lastItemSellIn.Text) };
        }

        private Control GetControlAt(DisplayedItemProperties property, int row)
        {
            return GetControlFromPosition((int)property, row)
                ?? throw new ArgumentNullException($"Trying to parse non-existent item property: {property}, at item number: {row}");
        }

        private void AddTextBoxControl(string text, DisplayedItemProperties property)
        {
            var textBox = new TextBox
            {
                Text = text
            };

            Controls.Add(textBox, (int)property, RowCount);
        }

        private enum DisplayedItemProperties
        {
            Name = 0,
            SellIn
        }
    }
}
