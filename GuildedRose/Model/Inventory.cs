using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.Model
{
    public class Inventory : UserRequestListener
    {
        private List<string> items = new List<string>();
        private List<InventoryListener> listeners = new List<InventoryListener>();

        public void AddItemToInventory(string item)
        {
            items.Add(item);
            listeners.ForEach(listener => listener.NewItemAdded(item));
        }

        public void AddInventoryListener(InventoryListener listener) 
        {
            listeners.Add(listener);
        }

        public string GetItemByName(string name)
        {
            return items.Find(item => item == name) 
                ?? throw new ArgumentNullException("Could not find item with name: " + name);
        }
    }
}
