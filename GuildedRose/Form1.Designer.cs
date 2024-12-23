namespace GuildedRose
{
    partial class Form1
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
            itemLabel = new Label();
            addItemButton = new Button();
            SuspendLayout();
            // 
            // itemTextBox
            // 
            itemTextBox.Location = new Point(62, 65);
            itemTextBox.Name = "itemTextBox";
            itemTextBox.Size = new Size(125, 27);
            itemTextBox.TabIndex = 0;
            // 
            // itemLabel
            // 
            itemLabel.AutoSize = true;
            itemLabel.Location = new Point(470, 68);
            itemLabel.Name = "itemLabel";
            itemLabel.Size = new Size(93, 20);
            itemLabel.TabIndex = 1;
            itemLabel.Text = "Hello World!";
            itemLabel.Click += itemLabel_Click;
            // 
            // addItemButton
            // 
            addItemButton.Location = new Point(237, 63);
            addItemButton.Name = "addItemButton";
            addItemButton.Size = new Size(94, 29);
            addItemButton.TabIndex = 2;
            addItemButton.Text = "Add Item";
            addItemButton.UseVisualStyleBackColor = true;
            addItemButton.Click += addItemButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addItemButton);
            Controls.Add(itemLabel);
            Controls.Add(itemTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox itemTextBox;
        private Label itemLabel;
        private Button addItemButton;
    }
}
