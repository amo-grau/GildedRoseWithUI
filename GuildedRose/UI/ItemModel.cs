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
        private Item modeledItem;

        private ItemModel(string name, string sellIn)
        {
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

        public IReadOnlyCollection<UserRequestListener> RemoveButtonListeners { private get;  set; } = new List<UserRequestListener>();

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
