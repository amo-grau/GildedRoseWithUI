using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GuildedRose.UI
{
    internal class ItemModel
    {
        private Item modeledItem;

        private ItemModel(string name, string sellIn)
        {
            DisplayedProperties = new Dictionary<ItemProperties, Control>()
            {
                { ItemProperties.Name, new TextBox { Name = name, Text = name, ReadOnly = true } },
                { ItemProperties.SellIn, new TextBox { Text = sellIn, ReadOnly = true } },
                { ItemProperties.RemoveButton, RemoveButton(name) }
            };

            modeledItem = new Item(name) with { SellIn = int.Parse(sellIn) };
        }

        public IReadOnlyDictionary<ItemProperties, Control> DisplayedProperties { get; }

        public IReadOnlyCollection<UserRequestListener> RemoveButtonListeners { private get;  set; } = new List<UserRequestListener>();

        private Button RemoveButton(string itemName)
        {
            var removeButton = new Button() { Name = itemName + "RemoveButton", Text = "Remove", AutoSize = true };
            removeButton.Click += (_, _) => NotifyListeners();
            return removeButton;
        }

        private void NotifyListeners()
        {
            foreach (var listener in RemoveButtonListeners)
            {
                listener.RemoveItemFromInventory(modeledItem);
            }
        }

        public static ItemModel From(Item item)
        {
            return new ItemModel(item.Name, item.SellIn.ToString());
        }
    }
}
