using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildedRose.UI
{
    public class TableLayoutControl : TableLayoutPanel
    {
        public TableLayoutControl(int columns)
        {
            ColumnCount = columns;
        }

        public void AddRow(IDictionary<int, Control> controls)
        {
            foreach ((var displayedProperty, var control) in controls)
            {
                Controls.Add(control, displayedProperty, RowCount);
            }

            RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
            RowCount++;
        }

        public IEnumerable<Control> GetControlsAt(int row)
        {
            foreach (Control control in Controls)
            {
                if (GetRow(control) == row)
                {
                    yield return control;
                }
            }
        }

        public int GetRow(string controlName)
        {
            var itemNameControl = Controls.Find(controlName, false).First();
            return GetRow(itemNameControl);
        }

        public void RemoveRowAt(int row)
        {
            RemoveControlsAt(row);
            ShiftFollowingControls(row);
            RemoveLastRow(row);
            RowCount--;
        }

        private void RemoveLastRow(int row)
        {
            if (RowStyles.Count > row)
            {
                RowStyles.RemoveAt(row);
            }
        }

        private void ShiftFollowingControls(int row)
        {
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
        }

        private void RemoveControlsAt(int row)
        {
            for (int i = ColumnCount - 1; i >= 0; i--)
            {
                var control = GetControlFromPosition(i, row);

                if (control != null)
                {
                    Controls.Remove(control);
                    control.Dispose();
                }
            }
        }
    }
}
