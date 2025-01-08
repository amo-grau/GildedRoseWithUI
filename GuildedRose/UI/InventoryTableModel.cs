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
    public class InventoryTableModel : TableLayoutControl, InventoryListener
    {       
        private IReadOnlyCollection<UserRequestListener> listeners = new List<UserRequestListener>();

        public InventoryTableModel() : base(Enum.GetNames(typeof(ItemProperties)).Length) { }

        public void ItemAdded(Item item)
        {
            var itemModel = ItemModel.From(item);
            itemModel.RemoveButtonListeners = listeners;
            var controls = itemModel.DisplayedProperties.ToDictionary(
                        kvp => (int)kvp.Key, // Convert the key (ItemProperties) to an int
                        kvp => kvp.Value     // Keep the value (Control) as is
                );

            AddRow(controls);
        }

        public Item GetItemAt(int row)
        {
            var controlsText = GetControlsAt(row).Select(control => control.Text).ToList();

            return new Item(controlsText[(int)ItemProperties.Name])
                    with { SellIn = int.Parse(controlsText[(int)ItemProperties.SellIn]) };
        }

        public void AddListener(UserRequestListener listener) 
        {
            listeners = listeners.Append(listener).ToArray();
        }

        public void ItemRemoved(Item item)
        {
            int itemRow = GetRow(item.Name);
            RemoveRowAt(itemRow);
        }
    }
}
