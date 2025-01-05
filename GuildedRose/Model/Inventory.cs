using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.Model
{
    public class Inventory : UserRequestListener
    {
        private List<Item> items = new List<Item>();
        private List<InventoryListener> listeners = new List<InventoryListener>();

        public void AddItemToInventory(Item item)
        {
            items.Add(item);
            listeners.ForEach(listener => listener.NewItemAdded(item));
        }

        public void AddInventoryListener(InventoryListener listener) 
        {
            listeners.Add(listener);
        }

        public Item GetItemByName(string name)
        {
            return items.Find(item => item.Name == name) 
                ?? throw new ArgumentNullException("Could not find item with name: " + name);
        }

        public void RemovedItemFromInventory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
