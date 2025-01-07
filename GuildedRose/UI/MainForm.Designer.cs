using GuildedRose.UI;

namespace GuildedRose
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            itemTextBox = new TextBox();
            addItemButton = new Button();
            itemsTable = new InventoryTableModel(null);
            SuspendLayout();
            // 
            // itemTextBox
            // 
            itemTextBox.Location = new Point(126, 48);
            itemTextBox.Name = "itemTextBox";
            itemTextBox.Size = new Size(261, 27);
            itemTextBox.TabIndex = 0;
            // 
            // addItemButton
            // 
            addItemButton.Location = new Point(457, 48);
            addItemButton.Name = "addItemButton";
            addItemButton.Size = new Size(94, 27);
            addItemButton.TabIndex = 2;
            addItemButton.Text = "Add Item";
            addItemButton.UseVisualStyleBackColor = true;
            addItemButton.Click += addItemButton_Click;
            // 
            // itemsTable
            // 
            itemsTable.AutoSize = true;
            itemsTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            itemsTable.ColumnCount = 3;
            itemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            itemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            itemsTable.ForeColor = SystemColors.ControlText;
            itemsTable.Location = new Point(26, 117);
            itemsTable.Name = "itemsTable";
            itemsTable.RowCount = 0;
            itemsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            itemsTable.Size = new Size(75, 0);
            itemsTable.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(itemsTable);
            Controls.Add(addItemButton);
            Controls.Add(itemTextBox);
            Name = "MainForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox itemTextBox;
        private Button addItemButton;
        private InventoryTableModel itemsTable;
    }
}
