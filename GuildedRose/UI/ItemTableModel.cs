using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.UI
{
    internal class ItemTableModel : InventoryListener
    {
        private TextBox items;

        public ItemTableModel(TextBox items)
        {
            this.items = items;
        }

        public void NewItemAdded(string itemName)
        {
            items.AppendText(itemName);
        }
    }
}
