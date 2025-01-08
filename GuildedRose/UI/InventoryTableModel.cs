using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GuildedRose.UI
{
    public class InventoryTableModel : InventoryListener
    {       
        private IReadOnlyCollection<UserRequestListener> listeners = new List<UserRequestListener>();
        private TableLayoutControl table;

        public InventoryTableModel(TableLayoutControl table)
        {
            this.table = table;
        }

        public int ItemCount { get => table.RowCount; }

        public void ItemAdded(Item item)
        {
            var itemModel = ItemModel.From(item);
            itemModel.RemoveButtonListeners = listeners;
            var controls = itemModel.DisplayedProperties.ToDictionary(
                        kvp => (int)kvp.Key, // Convert the key (ItemProperties) to an int
                        kvp => kvp.Value     // Keep the value (Control) as is
                );

            table.AddRow(controls);
        }

        public Item GetItemAt(int row)
        {
            var controlsText = table.GetControlsAt(row).Select(control => control.Text).ToList();

            return new Item(controlsText[(int)ItemProperties.Name])
                    with { SellIn = int.Parse(controlsText[(int)ItemProperties.SellIn]) };
        }

        public Button RemoveButtonFor(Item item)
        {
            return table.Controls.Find($"{item.Name}RemoveButton", false).First() as Button
                ?? throw new ArgumentNullException();
        }

        public void AddListener(UserRequestListener listener) 
        {
            listeners = listeners.Append(listener).ToArray();
        }

        public void ItemRemoved(Item item)
        {
            int itemRow = table.GetRow(item.Name);
            table.RemoveRowAt(itemRow);
        }
    }
}
