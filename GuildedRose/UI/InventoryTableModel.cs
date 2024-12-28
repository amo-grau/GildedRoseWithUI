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
        public void NewItemAdded(string itemName)
        {
            var textBox = new TextBox
            {
                Text = itemName,
                Dock = DockStyle.Fill
            };

            Controls.Add(textBox, RowCount - 1, 0);
            RowCount++;
            RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
        }
    }
}
