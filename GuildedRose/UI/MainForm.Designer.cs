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
            itemsTable = new InventoryTableModel();
            SuspendLayout();
            // 
            // itemTextBox
            // 
            itemTextBox.Location = new Point(26, 51);
            itemTextBox.Name = "itemTextBox";
            itemTextBox.Size = new Size(261, 27);
            itemTextBox.TabIndex = 0;
            // 
            // addItemButton
            // 
            addItemButton.Location = new Point(356, 49);
            addItemButton.Name = "addItemButton";
            addItemButton.Size = new Size(94, 29);
            addItemButton.TabIndex = 2;
            addItemButton.Text = "Add Item";
            addItemButton.UseVisualStyleBackColor = true;
            addItemButton.Click += addItemButton_Click;
            // 
            // itemsTable
            // 
            itemsTable.ColumnCount = 1;
            itemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            itemsTable.ForeColor = SystemColors.ControlText;
            itemsTable.Location = new Point(242, 181);
            itemsTable.Name = "itemsTable";
            itemsTable.RowCount = 1;
            itemsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            itemsTable.Size = new Size(250, 125);
            itemsTable.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
