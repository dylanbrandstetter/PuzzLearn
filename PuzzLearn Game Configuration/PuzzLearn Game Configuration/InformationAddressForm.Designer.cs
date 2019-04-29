namespace PuzzLearn_Game_Configuration
{
    partial class InformationAddressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonTextBox = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.AddressPanel = new System.Windows.Forms.Panel();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.CategoryValuePanel = new System.Windows.Forms.Panel();
            this.DefaultValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.CategoryUpDown = new System.Windows.Forms.NumericUpDown();
            this.ValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.ValueCategoryDataGrid = new System.Windows.Forms.DataGridView();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultValueLabel = new System.Windows.Forms.Label();
            this.AddressValueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddOrUpdateButton = new System.Windows.Forms.Button();
            this.ButtonTextBox.SuspendLayout();
            this.DescriptionPanel.SuspendLayout();
            this.AddressPanel.SuspendLayout();
            this.CategoryValuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueCategoryDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonTextBox
            // 
            this.ButtonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTextBox.Controls.Add(this.CancelButton);
            this.ButtonTextBox.Controls.Add(this.ConfirmButton);
            this.ButtonTextBox.Location = new System.Drawing.Point(12, 228);
            this.ButtonTextBox.Name = "ButtonTextBox";
            this.ButtonTextBox.Size = new System.Drawing.Size(279, 31);
            this.ButtonTextBox.TabIndex = 11;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(201, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmButton.Location = new System.Drawing.Point(120, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionPanel.Controls.Add(this.DescriptionTextBox);
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Location = new System.Drawing.Point(12, 46);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(279, 28);
            this.DescriptionPanel.TabIndex = 9;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(154, 4);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(122, 20);
            this.DescriptionTextBox.TabIndex = 2;
            this.DescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionTextBox_KeyPress);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(81, 7);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "*Description:";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AddressPanel
            // 
            this.AddressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressPanel.Controls.Add(this.AddressTextBox);
            this.AddressPanel.Controls.Add(this.AddressLabel);
            this.AddressPanel.Location = new System.Drawing.Point(12, 12);
            this.AddressPanel.Name = "AddressPanel";
            this.AddressPanel.Size = new System.Drawing.Size(279, 28);
            this.AddressPanel.TabIndex = 8;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressTextBox.Location = new System.Drawing.Point(154, 4);
            this.AddressTextBox.MaxLength = 8;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(122, 20);
            this.AddressTextBox.TabIndex = 2;
            this.AddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTextBox_KeyPress);
            // 
            // AddressLabel
            // 
            this.AddressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(70, 7);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(78, 13);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "*Address (hex):";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CategoryValuePanel
            // 
            this.CategoryValuePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryValuePanel.Controls.Add(this.DefaultValueUpDown);
            this.CategoryValuePanel.Controls.Add(this.CategoryUpDown);
            this.CategoryValuePanel.Controls.Add(this.ValueUpDown);
            this.CategoryValuePanel.Controls.Add(this.ValueCategoryDataGrid);
            this.CategoryValuePanel.Controls.Add(this.DefaultValueLabel);
            this.CategoryValuePanel.Controls.Add(this.AddressValueLabel);
            this.CategoryValuePanel.Controls.Add(this.label1);
            this.CategoryValuePanel.Controls.Add(this.DeleteButton);
            this.CategoryValuePanel.Controls.Add(this.AddOrUpdateButton);
            this.CategoryValuePanel.Location = new System.Drawing.Point(12, 80);
            this.CategoryValuePanel.Name = "CategoryValuePanel";
            this.CategoryValuePanel.Size = new System.Drawing.Size(279, 142);
            this.CategoryValuePanel.TabIndex = 10;
            // 
            // DefaultValueUpDown
            // 
            this.DefaultValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultValueUpDown.Location = new System.Drawing.Point(234, 113);
            this.DefaultValueUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.DefaultValueUpDown.Name = "DefaultValueUpDown";
            this.DefaultValueUpDown.Size = new System.Drawing.Size(42, 20);
            this.DefaultValueUpDown.TabIndex = 11;
            // 
            // CategoryUpDown
            // 
            this.CategoryUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryUpDown.Location = new System.Drawing.Point(234, 29);
            this.CategoryUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.CategoryUpDown.Name = "CategoryUpDown";
            this.CategoryUpDown.Size = new System.Drawing.Size(42, 20);
            this.CategoryUpDown.TabIndex = 10;
            // 
            // ValueUpDown
            // 
            this.ValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueUpDown.Location = new System.Drawing.Point(234, 3);
            this.ValueUpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.ValueUpDown.Name = "ValueUpDown";
            this.ValueUpDown.Size = new System.Drawing.Size(42, 20);
            this.ValueUpDown.TabIndex = 9;
            // 
            // ValueCategoryDataGrid
            // 
            this.ValueCategoryDataGrid.AllowUserToAddRows = false;
            this.ValueCategoryDataGrid.AllowUserToDeleteRows = false;
            this.ValueCategoryDataGrid.AllowUserToResizeColumns = false;
            this.ValueCategoryDataGrid.AllowUserToResizeRows = false;
            this.ValueCategoryDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueCategoryDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Value,
            this.Category});
            this.ValueCategoryDataGrid.Location = new System.Drawing.Point(3, 3);
            this.ValueCategoryDataGrid.MultiSelect = false;
            this.ValueCategoryDataGrid.Name = "ValueCategoryDataGrid";
            this.ValueCategoryDataGrid.RowHeadersVisible = false;
            this.ValueCategoryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ValueCategoryDataGrid.Size = new System.Drawing.Size(142, 136);
            this.ValueCategoryDataGrid.TabIndex = 8;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Item1";
            this.Value.HeaderText = "Address Value";
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value.Width = 82;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Item2";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Category.Width = 56;
            // 
            // DefaultValueLabel
            // 
            this.DefaultValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultValueLabel.AutoSize = true;
            this.DefaultValueLabel.Location = new System.Drawing.Point(155, 115);
            this.DefaultValueLabel.Name = "DefaultValueLabel";
            this.DefaultValueLabel.Size = new System.Drawing.Size(73, 13);
            this.DefaultValueLabel.TabIndex = 6;
            this.DefaultValueLabel.Text = "Default value:";
            // 
            // AddressValueLabel
            // 
            this.AddressValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressValueLabel.AutoSize = true;
            this.AddressValueLabel.Location = new System.Drawing.Point(151, 5);
            this.AddressValueLabel.Name = "AddressValueLabel";
            this.AddressValueLabel.Size = new System.Drawing.Size(77, 13);
            this.AddressValueLabel.TabIndex = 5;
            this.AddressValueLabel.Text = "Address value:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Category:";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(154, 84);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(122, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddOrUpdateButton
            // 
            this.AddOrUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddOrUpdateButton.Location = new System.Drawing.Point(154, 55);
            this.AddOrUpdateButton.Name = "AddOrUpdateButton";
            this.AddOrUpdateButton.Size = new System.Drawing.Size(122, 23);
            this.AddOrUpdateButton.TabIndex = 0;
            this.AddOrUpdateButton.Text = "Add/Update";
            this.AddOrUpdateButton.UseVisualStyleBackColor = true;
            this.AddOrUpdateButton.Click += new System.EventHandler(this.AddOrUpdateButton_Click);
            // 
            // InformationAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 261);
            this.Controls.Add(this.CategoryValuePanel);
            this.Controls.Add(this.ButtonTextBox);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.AddressPanel);
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "InformationAddressForm";
            this.Text = "InformationAddressForm";
            this.ButtonTextBox.ResumeLayout(false);
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            this.AddressPanel.ResumeLayout(false);
            this.AddressPanel.PerformLayout();
            this.CategoryValuePanel.ResumeLayout(false);
            this.CategoryValuePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueCategoryDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ButtonTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Panel DescriptionPanel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel AddressPanel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Panel CategoryValuePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddOrUpdateButton;
        private System.Windows.Forms.Label AddressValueLabel;
        private System.Windows.Forms.DataGridView ValueCategoryDataGrid;
        private System.Windows.Forms.Label DefaultValueLabel;
        private System.Windows.Forms.NumericUpDown DefaultValueUpDown;
        private System.Windows.Forms.NumericUpDown CategoryUpDown;
        private System.Windows.Forms.NumericUpDown ValueUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
    }
}