﻿using System;
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

        public IReadOnlyList<Item> Items { get => items; }

        public void AddItemToInventory(Item item)
        {
            items.Add(item);
            listeners.ForEach(listener => listener.ItemAdded(item));
        }

        public void RemoveItemFromInventory(Item item)
        {
            items.Remove(item);
            listeners.ForEach(listener => listener.ItemRemoved(item));
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
    }
}
