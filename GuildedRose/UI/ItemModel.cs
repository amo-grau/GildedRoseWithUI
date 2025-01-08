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

        private ItemModel(Item item)
        {
            DisplayedProperties = new Dictionary<ItemProperties, Control>()
            {
                { ItemProperties.Name, new TextBox { Name = item.Name, Text = item.Name, ReadOnly = true } },
                { ItemProperties.SellIn, new TextBox { Text = item.SellIn.ToString(), ReadOnly = true } },
                { ItemProperties.RemoveButton, RemoveButton(item.Name) }
            };

            modeledItem = item;
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
            return new ItemModel(item);
        }
    }
}
