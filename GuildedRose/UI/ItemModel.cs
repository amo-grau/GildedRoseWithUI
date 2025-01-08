using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.UI
{
    internal class ItemModel
    {
        public readonly IReadOnlyDictionary<DisplayedProperties, Control> displayedProperties;
        private IReadOnlyCollection<UserRequestListener> listeners = new List<UserRequestListener>();
        private Item modeledItem;

        private ItemModel(string name, string sellIn, IReadOnlyCollection<UserRequestListener> listeners)
        {
            this.listeners = listeners;
            var removeButton = new Button() { Name = name + "RemoveButton", Text = "Remove", AutoSize = true };
            removeButton.Click += (_, _) => NotifyListeners();

            displayedProperties =
                new Dictionary<DisplayedProperties, Control>()
                {
                        { DisplayedProperties.Name, new TextBox { Name = name, Text = name, ReadOnly = true } },
                        { DisplayedProperties.SellIn, new TextBox { Text = sellIn, ReadOnly = true } },
                        { DisplayedProperties.RemoveButton, removeButton }
                };

            modeledItem = new Item(name) with { SellIn = int.Parse(sellIn) };
        }

        private ItemModel(Item item, IReadOnlyCollection<UserRequestListener> listeners) : this(item.Name, item.SellIn.ToString(), listeners) { }

        public static ItemModel From(Item item, IReadOnlyCollection<UserRequestListener> listeners)
        {
            return new ItemModel(item, listeners);
        }

        public void NotifyListeners()
        {
            foreach (var listener in listeners)
            {
                listener.RemoveItemFromInventory(modeledItem);
            }
        }
    }
}
