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
    }
}
