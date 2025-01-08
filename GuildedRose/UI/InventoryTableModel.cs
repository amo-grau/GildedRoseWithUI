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
            ColumnCount = Enum.GetNames(typeof(DisplayedProperties)).Length;
        }

        public void ItemAdded(Item item)
        {
            var itemModel = ItemModel.From(item);
            itemModel.Listeners = listeners;

            foreach ((var displayedProperty, var control) in itemModel.displayedProperties)
            {
                Controls.Add(control, (int)displayedProperty, RowCount); // todo: it could maybe be done with a list without using the enum
            }

            RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
            RowCount++;
        }

        public Item GetItemAt(int row)
        {
            var controlsText = GetControlsAt(row).Select(control => control.Text).ToList();

            return new Item(controlsText[(int)DisplayedProperties.Name])
                    with { SellIn = int.Parse(controlsText[(int)DisplayedProperties.SellIn]) };
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
    }
}
