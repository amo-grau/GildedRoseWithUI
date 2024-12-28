using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace GildedRoseTests.EndToEnd
{
    internal class FormDriver : ApplicationDriver
    {
        private Form form;

        public FormDriver(Form form)
        {
            this.form = form;
            form.Show();
        }

        public void AddItem(string itemName)
        {
            var itemTextBox = FindControl<TextBox>("itemTextBox");

            itemTextBox.Clear();
            itemTextBox.AppendText(itemName);

            var addItemButton = FindControl<Button>("addItemButton");

            addItemButton.PerformClick();
        }

        public void showIsAdded(string itemName)
        {
            var itemTextBox = FindControl<TextBox>("textBox1");
            Assert.Equal(itemName, itemTextBox.Text);
        }

        public void Close()
        {
            form.Close();
        }

        private T FindControl<T>(string name) where T : Control
        {
            return (T)form.Controls.Find(name, true).First();
        }
    }
}
