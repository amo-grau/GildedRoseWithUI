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
    public class InventoryTableModel : TableLayoutPanel, InventoryListener
    {       
        private IReadOnlyCollection<UserRequestListener> listeners = new List<UserRequestListener>();

        public InventoryTableModel()
        {
            ColumnCount = Enum.GetNames(typeof(DisplayedItemProperties)).Length;
        }

        public void NewItemAdded(Item item)
        {
            foreach ((var displayedProperty, var control) in ItemModel.From(item, listeners).displayedProperties)
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

        public void AddListener(UserRequestListener listener) 
        {
            listeners = listeners.Append(listener).ToArray();
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

        public void ItemRemoved(Item item)
        {
            var nameControl = Controls.Find(item.Name, false).First();
            var row = GetRow(nameControl);

            // Step 1: Remove controls in the specified row
            for (int i = ColumnCount - 1; i >= 0; i--)
            {
                var control = GetControlFromPosition(i, row);

                if (control != null)
                {
                    Controls.Remove(control);
                    control.Dispose();
                }
            }

            // Step 2: Shift controls in rows below the removed row up by one
            for (int i = row + 1; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    var control = GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        SetRow(control, i - 1);
                    }
                }
            }

            // Step 3: Remove the last row style
            if (RowStyles.Count > row)
            {
                RowStyles.RemoveAt(row);
            }

            // Step 4: Update RowCount
            RowCount--;
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
            private IReadOnlyCollection<UserRequestListener> listeners = new List<UserRequestListener>();
            private Item modeledItem;

            private ItemModel(string name, string sellIn, IReadOnlyCollection<UserRequestListener> listeners)
            {
                this.listeners = listeners;
                var removeButton = new Button() { Name = name + "RemoveButton", Text = "Remove", AutoSize = true };
                removeButton.Click += (_,_) => NotifyListeners();

                displayedProperties =
                    new Dictionary<DisplayedItemProperties, Control>()
                    {
                        { DisplayedItemProperties.Name, new TextBox { Name = name, Text = name, ReadOnly = true } },
                        { DisplayedItemProperties.SellIn, new TextBox { Text = sellIn, ReadOnly = true } },
                        { DisplayedItemProperties.RemoveButton, removeButton }
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
}
