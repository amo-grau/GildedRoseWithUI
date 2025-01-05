using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.UI
{
    public class InventoryTableModel : TableLayoutPanel, InventoryListener
    {
        public IReadOnlyList<Item> Items { get; }

        public void NewItemAdded(Item item)
        {
            foreach ((var type, var text) in ItemModel.From(item).displayedProperties) // todo: replace ItemModel by creating controls individually
            {
                AddTextBoxControl(text, type);
            }

            RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
            RowCount++;
        }

        public Item GetItemAt(int row)
        {
            var controlsText = GetControlsAt(row).Select(control => control.Text).ToList();

            return new Item(controlsText[(int)DisplayedItemProperties.Name])
                    with { SellIn = int.Parse(controlsText[(int)DisplayedItemProperties.SellIn]) };
        }

        private IEnumerable<Control> GetControlsAt(int rowIndex)
        {
            foreach (Control control in Controls)
            {
                if (GetRow(control) == rowIndex)
                {
                    yield return control;
                }
            }
        }

        private void AddTextBoxControl(string text, DisplayedItemProperties propertyIndex)
        {
            var textBox = new TextBox
            {
                Text = text
            };

            Controls.Add(textBox, (int)propertyIndex, RowCount);
        }

        private enum DisplayedItemProperties
        {
            Name = 0,
            SellIn
        }

        private record ItemModel
        {
            public readonly IReadOnlyDictionary<DisplayedItemProperties, string> displayedProperties;

            private ItemModel(string name, string sellIn)
            {
                 displayedProperties =
                    new Dictionary<DisplayedItemProperties, string>()
                    {
                        { DisplayedItemProperties.Name, name},
                        { DisplayedItemProperties.SellIn, sellIn }
                    };
            }

            private ItemModel(Item item) : this(item.Name, item.SellIn.ToString()) { }

            public static ItemModel From(Item item)
            {
                return new ItemModel(item);
            }
        }
    }
}
