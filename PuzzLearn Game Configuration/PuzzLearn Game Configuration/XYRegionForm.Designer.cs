namespace PuzzLearn_Game_Configuration
{
    partial class XYRegionForm
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
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.AddressPanel = new System.Windows.Forms.Panel();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.StartPanel = new System.Windows.Forms.Panel();
            this.YStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.XStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.YStartLabel = new System.Windows.Forms.Label();
            this.XStartLabel = new System.Windows.Forms.Label();
            this.WidthPanel = new System.Windows.Forms.Panel();
            this.HeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.RowOffsetUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.RowOffsetLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.ButtonTextBox = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
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
            this.DescriptionPanel.SuspendLayout();
            this.AddressPanel.SuspendLayout();
            this.StartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YStartUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XStartUpDown)).BeginInit();
            this.WidthPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowOffsetUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.ButtonTextBox.SuspendLayout();
            this.CategoryValuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueCategoryDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionPanel.Controls.Add(this.DescriptionTextBox);
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Location = new System.Drawing.Point(12, 46);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(296, 28);
            this.DescriptionPanel.TabIndex = 1;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(138, 4);
            this.DescriptionTextBox.MaxLength = 32;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(155, 20);
            this.DescriptionTextBox.TabIndex = 0;
            this.DescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
            this.DescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionTextBox_KeyPress);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(65, 7);
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
            this.AddressPanel.Size = new System.Drawing.Size(296, 28);
            this.AddressPanel.TabIndex = 0;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressTextBox.Location = new System.Drawing.Point(138, 4);
            this.AddressTextBox.MaxLength = 8;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(155, 20);
            this.AddressTextBox.TabIndex = 0;
            this.AddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressTextBox_KeyDown);
            this.AddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTextBox_KeyPress);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(29, 7);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(103, 13);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "*Start Address (hex):";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StartPanel
            // 
            this.StartPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartPanel.Controls.Add(this.YStartUpDown);
            this.StartPanel.Controls.Add(this.XStartUpDown);
            this.StartPanel.Controls.Add(this.YStartLabel);
            this.StartPanel.Controls.Add(this.XStartLabel);
            this.StartPanel.Location = new System.Drawing.Point(12, 114);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(296, 28);
            this.StartPanel.TabIndex = 3;
            // 
            // YStartUpDown
            // 
            this.YStartUpDown.Location = new System.Drawing.Point(138, 3);
            this.YStartUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.YStartUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.YStartUpDown.Name = "YStartUpDown";
            this.YStartUpDown.Size = new System.Drawing.Size(38, 20);
            this.YStartUpDown.TabIndex = 1;
            // 
            // XStartUpDown
            // 
            this.XStartUpDown.Location = new System.Drawing.Point(47, 3);
            this.XStartUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.XStartUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.XStartUpDown.Name = "XStartUpDown";
            this.XStartUpDown.Size = new System.Drawing.Size(38, 20);
            this.XStartUpDown.TabIndex = 0;
            // 
            // YStartLabel
            // 
            this.YStartLabel.AutoSize = true;
            this.YStartLabel.Location = new System.Drawing.Point(90, 6);
            this.YStartLabel.Name = "YStartLabel";
            this.YStartLabel.Size = new System.Drawing.Size(42, 13);
            this.YStartLabel.TabIndex = 3;
            this.YStartLabel.Text = "Y Start:";
            this.YStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // XStartLabel
            // 
            this.XStartLabel.AutoSize = true;
            this.XStartLabel.Location = new System.Drawing.Point(3, 6);
            this.XStartLabel.Name = "XStartLabel";
            this.XStartLabel.Size = new System.Drawing.Size(42, 13);
            this.XStartLabel.TabIndex = 1;
            this.XStartLabel.Text = "X Start:";
            this.XStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WidthPanel
            // 
            this.WidthPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthPanel.Controls.Add(this.HeightUpDown);
            this.WidthPanel.Controls.Add(this.RowOffsetUpDown);
            this.WidthPanel.Controls.Add(this.WidthUpDown);
            this.WidthPanel.Controls.Add(this.RowOffsetLabel);
            this.WidthPanel.Controls.Add(this.HeightLabel);
            this.WidthPanel.Controls.Add(this.WidthLabel);
            this.WidthPanel.Location = new System.Drawing.Point(12, 80);
            this.WidthPanel.Name = "WidthPanel";
            this.WidthPanel.Size = new System.Drawing.Size(296, 28);
            this.WidthPanel.TabIndex = 2;
            // 
            // HeightUpDown
            // 
            this.HeightUpDown.Location = new System.Drawing.Point(138, 3);
            this.HeightUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.HeightUpDown.Name = "HeightUpDown";
            this.HeightUpDown.Size = new System.Drawing.Size(38, 20);
            this.HeightUpDown.TabIndex = 1;
            this.HeightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RowOffsetUpDown
            // 
            this.RowOffsetUpDown.Location = new System.Drawing.Point(251, 3);
            this.RowOffsetUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.RowOffsetUpDown.Name = "RowOffsetUpDown";
            this.RowOffsetUpDown.Size = new System.Drawing.Size(38, 20);
            this.RowOffsetUpDown.TabIndex = 2;
            this.RowOffsetUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Location = new System.Drawing.Point(47, 3);
            this.WidthUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(38, 20);
            this.WidthUpDown.TabIndex = 0;
            this.WidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RowOffsetLabel
            // 
            this.RowOffsetLabel.AutoSize = true;
            this.RowOffsetLabel.Location = new System.Drawing.Point(182, 6);
            this.RowOffsetLabel.Name = "RowOffsetLabel";
            this.RowOffsetLabel.Size = new System.Drawing.Size(63, 13);
            this.RowOffsetLabel.TabIndex = 14;
            this.RowOffsetLabel.Text = "Row Offset:";
            this.RowOffsetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(91, 6);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 3;
            this.HeightLabel.Text = "Height:";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(3, 6);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Width:";
            this.WidthLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonTextBox
            // 
            this.ButtonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTextBox.Controls.Add(this.CancelButton);
            this.ButtonTextBox.Controls.Add(this.ConfirmButton);
            this.ButtonTextBox.Location = new System.Drawing.Point(15, 296);
            this.ButtonTextBox.Name = "ButtonTextBox";
            this.ButtonTextBox.Size = new System.Drawing.Size(296, 31);
            this.ButtonTextBox.TabIndex = 5;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(218, 3);
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
            this.ConfirmButton.Location = new System.Drawing.Point(137, 5);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
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
            this.CategoryValuePanel.Location = new System.Drawing.Point(12, 148);
            this.CategoryValuePanel.Name = "CategoryValuePanel";
            this.CategoryValuePanel.Size = new System.Drawing.Size(296, 142);
            this.CategoryValuePanel.TabIndex = 4;
            // 
            // DefaultValueUpDown
            // 
            this.DefaultValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultValueUpDown.Location = new System.Drawing.Point(251, 113);
            this.DefaultValueUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.DefaultValueUpDown.Name = "DefaultValueUpDown";
            this.DefaultValueUpDown.Size = new System.Drawing.Size(42, 20);
            this.DefaultValueUpDown.TabIndex = 4;
            // 
            // CategoryUpDown
            // 
            this.CategoryUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryUpDown.Location = new System.Drawing.Point(251, 29);
            this.CategoryUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.CategoryUpDown.Name = "CategoryUpDown";
            this.CategoryUpDown.Size = new System.Drawing.Size(42, 20);
            this.CategoryUpDown.TabIndex = 1;
            // 
            // ValueUpDown
            // 
            this.ValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueUpDown.Location = new System.Drawing.Point(251, 3);
            this.ValueUpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.ValueUpDown.Name = "ValueUpDown";
            this.ValueUpDown.Size = new System.Drawing.Size(42, 20);
            this.ValueUpDown.TabIndex = 0;
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
            this.ValueCategoryDataGrid.Size = new System.Drawing.Size(159, 136);
            this.ValueCategoryDataGrid.TabIndex = 8;
            this.ValueCategoryDataGrid.TabStop = false;
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
            this.DefaultValueLabel.Location = new System.Drawing.Point(171, 115);
            this.DefaultValueLabel.Name = "DefaultValueLabel";
            this.DefaultValueLabel.Size = new System.Drawing.Size(74, 13);
            this.DefaultValueLabel.TabIndex = 6;
            this.DefaultValueLabel.Text = "Default Value:";
            // 
            // AddressValueLabel
            // 
            this.AddressValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressValueLabel.AutoSize = true;
            this.AddressValueLabel.Location = new System.Drawing.Point(168, 5);
            this.AddressValueLabel.Name = "AddressValueLabel";
            this.AddressValueLabel.Size = new System.Drawing.Size(77, 13);
            this.AddressValueLabel.TabIndex = 5;
            this.AddressValueLabel.Text = "Address value:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Category:";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(171, 84);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(122, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddOrUpdateButton
            // 
            this.AddOrUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddOrUpdateButton.Location = new System.Drawing.Point(171, 55);
            this.AddOrUpdateButton.Name = "AddOrUpdateButton";
            this.AddOrUpdateButton.Size = new System.Drawing.Size(122, 23);
            this.AddOrUpdateButton.TabIndex = 2;
            this.AddOrUpdateButton.Text = "Add/Update";
            this.AddOrUpdateButton.UseVisualStyleBackColor = true;
            this.AddOrUpdateButton.Click += new System.EventHandler(this.AddOrUpdateButton_Click);
            // 
            // XYRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 337);
            this.Controls.Add(this.CategoryValuePanel);
            this.Controls.Add(this.ButtonTextBox);
            this.Controls.Add(this.WidthPanel);
            this.Controls.Add(this.StartPanel);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.AddressPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "XYRegionForm";
            this.Text = "XY Region";
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            this.AddressPanel.ResumeLayout(false);
            this.AddressPanel.PerformLayout();
            this.StartPanel.ResumeLayout(false);
            this.StartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YStartUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XStartUpDown)).EndInit();
            this.WidthPanel.ResumeLayout(false);
            this.WidthPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowOffsetUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.ButtonTextBox.ResumeLayout(false);
            this.CategoryValuePanel.ResumeLayout(false);
            this.CategoryValuePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueCategoryDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DescriptionPanel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel AddressPanel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Panel StartPanel;
        private System.Windows.Forms.Label YStartLabel;
        private System.Windows.Forms.Label XStartLabel;
        private System.Windows.Forms.Panel WidthPanel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label RowOffsetLabel;
        private System.Windows.Forms.Panel ButtonTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.NumericUpDown HeightUpDown;
        private System.Windows.Forms.NumericUpDown RowOffsetUpDown;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.NumericUpDown YStartUpDown;
        private System.Windows.Forms.NumericUpDown XStartUpDown;
        private System.Windows.Forms.Panel CategoryValuePanel;
        private System.Windows.Forms.NumericUpDown DefaultValueUpDown;
        private System.Windows.Forms.NumericUpDown CategoryUpDown;
        private System.Windows.Forms.NumericUpDown ValueUpDown;
        private System.Windows.Forms.DataGridView ValueCategoryDataGrid;
        private System.Windows.Forms.Label DefaultValueLabel;
        private System.Windows.Forms.Label AddressValueLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddOrUpdateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
    }
}