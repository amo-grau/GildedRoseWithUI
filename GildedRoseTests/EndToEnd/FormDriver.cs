﻿using GuildedRose.Model;
using GuildedRose.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void AddItem(Item itemName)
        {
            var itemTextBox = FindControl<TextBox>("itemTextBox");

            itemTextBox.Clear();
            itemTextBox.AppendText(itemName.Name);

            var addItemButton = FindControl<Button>("addItemButton");

            addItemButton.PerformClick();
        }

        public void RemoveItem(string name)
        {
            var removeButtonName = name + "RemoveButton";
            var removeButton = FindControl<Button>(removeButtonName);
            removeButton.PerformClick();
        }

        public void showIsListed(Item item)
        {
           Assert.Equal(item, TableModel().GetItemAt(TableModel().ItemCount - 1));
        }

        public void showIsNotListed(Item item)
        {
            var items = Enumerable.Range(0, TableModel().ItemCount)
                .Select(TableModel().GetItemAt)
                .ToList();

            Assert.DoesNotContain(item, items);
        }

        public void Close()
        {
            form.Close();
        }

        private InventoryTableModel TableModel()
        {
            var itemTableForm = FindControl<TableLayoutControl>("itemsTable");
            return new InventoryTableModel(itemTableForm);
        }

        private T FindControl<T>(string name) where T : Control
        {
            return (T)form.Controls.Find(name, true).First();
        }
    }
}
