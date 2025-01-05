using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GuildedRose.UI
{
    public class InventoryTableModel : TableLayoutPanel, InventoryListener
    {
        public InventoryTableModel() 
        {
            ColumnCount = Enum.GetNames(typeof(DisplayedItemProperties)).Length;
        }

        public void NewItemAdded(Item item)
        {
            foreach ((var displayedProperty, var control) in ItemModel.From(item).displayedProperties)
            {
                Controls.Add(control, (int)displayedProperty, RowCount); // todo: it could maybe be done with a list without using the enum
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

        private enum DisplayedItemProperties
        {
            Name = 0,
            SellIn,
            RemoveButton
        }

        private record ItemModel
        {
            public readonly IReadOnlyDictionary<DisplayedItemProperties, Control> displayedProperties;

            private ItemModel(string name, string sellIn)
            {
                displayedProperties =
                    new Dictionary<DisplayedItemProperties, Control>()
                    {
                        { DisplayedItemProperties.Name, new TextBox { Text = name, ReadOnly = true } },
                        { DisplayedItemProperties.SellIn, new TextBox { Text = sellIn, ReadOnly = true } },
                        { DisplayedItemProperties.RemoveButton, new Button() { Name = name + "RemoveButton", Text = "Remove", AutoSize = true } }
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
