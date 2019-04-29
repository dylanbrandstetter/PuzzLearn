﻿namespace PuzzLearn_Game_Configuration
{
    partial class DatabaseSettingsForm
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
            this.EndAddressPanel = new System.Windows.Forms.Panel();
            this.EndAddressTextBox = new System.Windows.Forms.TextBox();
            this.EndAddressLabel = new System.Windows.Forms.Label();
            this.EndValuePanel = new System.Windows.Forms.Panel();
            this.EndValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.EndValueLabeL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddCategoryButton = new System.Windows.Forms.Button();
            this.EditColorButton = new System.Windows.Forms.Button();
            this.CategoryColorGridView = new System.Windows.Forms.DataGridView();
            this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StaleGenerationUpDown = new System.Windows.Forms.NumericUpDown();
            this.StaleGenerationLabel = new System.Windows.Forms.Label();
            this.PopulationUpDown = new System.Windows.Forms.NumericUpDown();
            this.PopulationLabel = new System.Windows.Forms.Label();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonsDataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonNameLabel = new System.Windows.Forms.Label();
            this.AddButtonButton = new System.Windows.Forms.Button();
            this.DeleteButtonButton = new System.Windows.Forms.Button();
            this.ButtonNamesComboBox = new System.Windows.Forms.ComboBox();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.TimeoutUpDown = new System.Windows.Forms.NumericUpDown();
            this.StaleTimeoutLabel = new System.Windows.Forms.Label();
            this.StaleTimeoutUpDown = new System.Windows.Forms.NumericUpDown();
            this.ButtonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndAddressPanel.SuspendLayout();
            this.EndValuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndValueUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryColorGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaleGenerationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationUpDown)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaleTimeoutUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // EndAddressPanel
            // 
            this.EndAddressPanel.Controls.Add(this.EndAddressTextBox);
            this.EndAddressPanel.Controls.Add(this.EndAddressLabel);
            this.EndAddressPanel.Location = new System.Drawing.Point(12, 12);
            this.EndAddressPanel.Name = "EndAddressPanel";
            this.EndAddressPanel.Size = new System.Drawing.Size(260, 28);
            this.EndAddressPanel.TabIndex = 11;
            // 
            // EndAddressTextBox
            // 
            this.EndAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndAddressTextBox.Location = new System.Drawing.Point(135, 4);
            this.EndAddressTextBox.MaxLength = 8;
            this.EndAddressTextBox.Name = "EndAddressTextBox";
            this.EndAddressTextBox.Size = new System.Drawing.Size(122, 20);
            this.EndAddressTextBox.TabIndex = 2;
            this.EndAddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndAddressTextBox_KeyPress);
            // 
            // EndAddressLabel
            // 
            this.EndAddressLabel.AutoSize = true;
            this.EndAddressLabel.Location = new System.Drawing.Point(29, 7);
            this.EndAddressLabel.Name = "EndAddressLabel";
            this.EndAddressLabel.Size = new System.Drawing.Size(100, 13);
            this.EndAddressLabel.TabIndex = 1;
            this.EndAddressLabel.Text = "*End Address (hex):";
            this.EndAddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EndValuePanel
            // 
            this.EndValuePanel.Controls.Add(this.EndValueUpDown);
            this.EndValuePanel.Controls.Add(this.EndValueLabeL);
            this.EndValuePanel.Location = new System.Drawing.Point(12, 46);
            this.EndValuePanel.Name = "EndValuePanel";
            this.EndValuePanel.Size = new System.Drawing.Size(260, 28);
            this.EndValuePanel.TabIndex = 12;
            // 
            // EndValueUpDown
            // 
            this.EndValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndValueUpDown.Location = new System.Drawing.Point(135, 3);
            this.EndValueUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.EndValueUpDown.Name = "EndValueUpDown";
            this.EndValueUpDown.Size = new System.Drawing.Size(122, 20);
            this.EndValueUpDown.TabIndex = 13;
            // 
            // EndValueLabeL
            // 
            this.EndValueLabeL.AutoSize = true;
            this.EndValueLabeL.Location = new System.Drawing.Point(70, 5);
            this.EndValueLabeL.Name = "EndValueLabeL";
            this.EndValueLabeL.Size = new System.Drawing.Size(59, 13);
            this.EndValueLabeL.TabIndex = 1;
            this.EndValueLabeL.Text = "End Value:";
            this.EndValueLabeL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddCategoryButton);
            this.panel1.Controls.Add(this.EditColorButton);
            this.panel1.Controls.Add(this.CategoryColorGridView);
            this.panel1.Location = new System.Drawing.Point(12, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 169);
            this.panel1.TabIndex = 14;
            // 
            // AddCategoryButton
            // 
            this.AddCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCategoryButton.Location = new System.Drawing.Point(177, 3);
            this.AddCategoryButton.Name = "AddCategoryButton";
            this.AddCategoryButton.Size = new System.Drawing.Size(79, 23);
            this.AddCategoryButton.TabIndex = 11;
            this.AddCategoryButton.Text = "Add Category";
            this.AddCategoryButton.UseVisualStyleBackColor = true;
            this.AddCategoryButton.Click += new System.EventHandler(this.AddCategoryButton_Click);
            // 
            // EditColorButton
            // 
            this.EditColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditColorButton.Location = new System.Drawing.Point(177, 32);
            this.EditColorButton.Name = "EditColorButton";
            this.EditColorButton.Size = new System.Drawing.Size(79, 23);
            this.EditColorButton.TabIndex = 10;
            this.EditColorButton.Text = "Edit Color";
            this.EditColorButton.UseVisualStyleBackColor = true;
            this.EditColorButton.Click += new System.EventHandler(this.EditColorButton_Click);
            // 
            // CategoryColorGridView
            // 
            this.CategoryColorGridView.AllowUserToAddRows = false;
            this.CategoryColorGridView.AllowUserToDeleteRows = false;
            this.CategoryColorGridView.AllowUserToResizeColumns = false;
            this.CategoryColorGridView.AllowUserToResizeRows = false;
            this.CategoryColorGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryColorGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryColumn,
            this.ColorColumn});
            this.CategoryColorGridView.Location = new System.Drawing.Point(3, 3);
            this.CategoryColorGridView.MultiSelect = false;
            this.CategoryColorGridView.Name = "CategoryColorGridView";
            this.CategoryColorGridView.RowHeadersVisible = false;
            this.CategoryColorGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CategoryColorGridView.Size = new System.Drawing.Size(168, 162);
            this.CategoryColorGridView.TabIndex = 9;
            // 
            // CategoryColumn
            // 
            this.CategoryColumn.DataPropertyName = "Category";
            this.CategoryColumn.HeaderText = "Category";
            this.CategoryColumn.Name = "CategoryColumn";
            this.CategoryColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryColumn.Width = 74;
            // 
            // ColorColumn
            // 
            this.ColorColumn.DataPropertyName = "ColorString";
            this.ColorColumn.HeaderText = "Color";
            this.ColorColumn.Name = "ColorColumn";
            this.ColorColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColorColumn.Width = 74;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.StaleTimeoutUpDown);
            this.panel2.Controls.Add(this.StaleTimeoutLabel);
            this.panel2.Controls.Add(this.TimeoutUpDown);
            this.panel2.Controls.Add(this.TimeoutLabel);
            this.panel2.Controls.Add(this.StaleGenerationUpDown);
            this.panel2.Controls.Add(this.StaleGenerationLabel);
            this.panel2.Controls.Add(this.PopulationUpDown);
            this.panel2.Controls.Add(this.PopulationLabel);
            this.panel2.Location = new System.Drawing.Point(12, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 28);
            this.panel2.TabIndex = 15;
            // 
            // StaleGenerationUpDown
            // 
            this.StaleGenerationUpDown.Location = new System.Drawing.Point(195, 3);
            this.StaleGenerationUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StaleGenerationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StaleGenerationUpDown.Name = "StaleGenerationUpDown";
            this.StaleGenerationUpDown.Size = new System.Drawing.Size(50, 20);
            this.StaleGenerationUpDown.TabIndex = 15;
            this.StaleGenerationUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StaleGenerationLabel
            // 
            this.StaleGenerationLabel.AutoSize = true;
            this.StaleGenerationLabel.Location = new System.Drawing.Point(129, 5);
            this.StaleGenerationLabel.Name = "StaleGenerationLabel";
            this.StaleGenerationLabel.Size = new System.Drawing.Size(60, 13);
            this.StaleGenerationLabel.TabIndex = 14;
            this.StaleGenerationLabel.Text = "Stale Gen.:";
            this.StaleGenerationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PopulationUpDown
            // 
            this.PopulationUpDown.Location = new System.Drawing.Point(73, 3);
            this.PopulationUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PopulationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PopulationUpDown.Name = "PopulationUpDown";
            this.PopulationUpDown.Size = new System.Drawing.Size(50, 20);
            this.PopulationUpDown.TabIndex = 13;
            this.PopulationUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PopulationLabel
            // 
            this.PopulationLabel.AutoSize = true;
            this.PopulationLabel.Location = new System.Drawing.Point(7, 5);
            this.PopulationLabel.Name = "PopulationLabel";
            this.PopulationLabel.Size = new System.Drawing.Size(60, 13);
            this.PopulationLabel.TabIndex = 1;
            this.PopulationLabel.Text = "Population:";
            this.PopulationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.CancelButton);
            this.ButtonsPanel.Controls.Add(this.ConfirmButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 289);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(516, 31);
            this.ButtonsPanel.TabIndex = 16;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(438, 3);
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
            this.ConfirmButton.Location = new System.Drawing.Point(357, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.ButtonNamesComboBox);
            this.panel3.Controls.Add(this.DeleteButtonButton);
            this.panel3.Controls.Add(this.AddButtonButton);
            this.panel3.Controls.Add(this.ButtonNameLabel);
            this.panel3.Controls.Add(this.ButtonsDataGridView);
            this.panel3.Location = new System.Drawing.Point(276, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 236);
            this.panel3.TabIndex = 17;
            // 
            // ButtonsDataGridView
            // 
            this.ButtonsDataGridView.AllowUserToAddRows = false;
            this.ButtonsDataGridView.AllowUserToDeleteRows = false;
            this.ButtonsDataGridView.AllowUserToResizeColumns = false;
            this.ButtonsDataGridView.AllowUserToResizeRows = false;
            this.ButtonsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtonColumn});
            this.ButtonsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ButtonsDataGridView.MultiSelect = false;
            this.ButtonsDataGridView.Name = "ButtonsDataGridView";
            this.ButtonsDataGridView.RowHeadersVisible = false;
            this.ButtonsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ButtonsDataGridView.Size = new System.Drawing.Size(162, 230);
            this.ButtonsDataGridView.TabIndex = 10;
            // 
            // ButtonNameLabel
            // 
            this.ButtonNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNameLabel.AutoSize = true;
            this.ButtonNameLabel.Location = new System.Drawing.Point(172, 5);
            this.ButtonNameLabel.Name = "ButtonNameLabel";
            this.ButtonNameLabel.Size = new System.Drawing.Size(72, 13);
            this.ButtonNameLabel.TabIndex = 11;
            this.ButtonNameLabel.Text = "Button Name:";
            // 
            // AddButtonButton
            // 
            this.AddButtonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButtonButton.Location = new System.Drawing.Point(168, 47);
            this.AddButtonButton.Name = "AddButtonButton";
            this.AddButtonButton.Size = new System.Drawing.Size(81, 23);
            this.AddButtonButton.TabIndex = 12;
            this.AddButtonButton.Text = "Add Button";
            this.AddButtonButton.UseVisualStyleBackColor = true;
            this.AddButtonButton.Click += new System.EventHandler(this.AddButtonButton_Click);
            // 
            // DeleteButtonButton
            // 
            this.DeleteButtonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButtonButton.Location = new System.Drawing.Point(168, 76);
            this.DeleteButtonButton.Name = "DeleteButtonButton";
            this.DeleteButtonButton.Size = new System.Drawing.Size(81, 23);
            this.DeleteButtonButton.TabIndex = 13;
            this.DeleteButtonButton.Text = "Delete Button";
            this.DeleteButtonButton.UseVisualStyleBackColor = true;
            this.DeleteButtonButton.Click += new System.EventHandler(this.DeleteButtonButton_Click);
            // 
            // ButtonNamesComboBox
            // 
            this.ButtonNamesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNamesComboBox.FormattingEnabled = true;
            this.ButtonNamesComboBox.Location = new System.Drawing.Point(168, 20);
            this.ButtonNamesComboBox.Name = "ButtonNamesComboBox";
            this.ButtonNamesComboBox.Size = new System.Drawing.Size(81, 21);
            this.ButtonNamesComboBox.TabIndex = 15;
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Location = new System.Drawing.Point(251, 5);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(48, 13);
            this.TimeoutLabel.TabIndex = 16;
            this.TimeoutLabel.Text = "Timeout:";
            // 
            // TimeoutUpDown
            // 
            this.TimeoutUpDown.DecimalPlaces = 2;
            this.TimeoutUpDown.Location = new System.Drawing.Point(305, 3);
            this.TimeoutUpDown.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.TimeoutUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeoutUpDown.Name = "TimeoutUpDown";
            this.TimeoutUpDown.Size = new System.Drawing.Size(60, 20);
            this.TimeoutUpDown.TabIndex = 17;
            this.TimeoutUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StaleTimeoutLabel
            // 
            this.StaleTimeoutLabel.AutoSize = true;
            this.StaleTimeoutLabel.Location = new System.Drawing.Point(371, 5);
            this.StaleTimeoutLabel.Name = "StaleTimeoutLabel";
            this.StaleTimeoutLabel.Size = new System.Drawing.Size(75, 13);
            this.StaleTimeoutLabel.TabIndex = 18;
            this.StaleTimeoutLabel.Text = "Stale Timeout:";
            // 
            // StaleTimeoutUpDown
            // 
            this.StaleTimeoutUpDown.DecimalPlaces = 2;
            this.StaleTimeoutUpDown.Location = new System.Drawing.Point(452, 3);
            this.StaleTimeoutUpDown.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.StaleTimeoutUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StaleTimeoutUpDown.Name = "StaleTimeoutUpDown";
            this.StaleTimeoutUpDown.Size = new System.Drawing.Size(60, 20);
            this.StaleTimeoutUpDown.TabIndex = 19;
            this.StaleTimeoutUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ButtonColumn
            // 
            this.ButtonColumn.DataPropertyName = "Item1";
            this.ButtonColumn.HeaderText = "Button";
            this.ButtonColumn.Name = "ButtonColumn";
            this.ButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ButtonColumn.Width = 142;
            // 
            // DatabaseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 330);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EndValuePanel);
            this.Controls.Add(this.EndAddressPanel);
            this.Name = "DatabaseSettingsForm";
            this.Text = "PuzzLearn - Database Settings";
            this.EndAddressPanel.ResumeLayout(false);
            this.EndAddressPanel.PerformLayout();
            this.EndValuePanel.ResumeLayout(false);
            this.EndValuePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndValueUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CategoryColorGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaleGenerationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationUpDown)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaleTimeoutUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EndAddressPanel;
        private System.Windows.Forms.TextBox EndAddressTextBox;
        private System.Windows.Forms.Label EndAddressLabel;
        private System.Windows.Forms.Panel EndValuePanel;
        private System.Windows.Forms.Label EndValueLabeL;
        private System.Windows.Forms.NumericUpDown EndValueUpDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EditColorButton;
        private System.Windows.Forms.DataGridView CategoryColorGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown StaleGenerationUpDown;
        private System.Windows.Forms.Label StaleGenerationLabel;
        private System.Windows.Forms.NumericUpDown PopulationUpDown;
        private System.Windows.Forms.Label PopulationLabel;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button AddCategoryButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorColumn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button DeleteButtonButton;
        private System.Windows.Forms.Button AddButtonButton;
        private System.Windows.Forms.Label ButtonNameLabel;
        private System.Windows.Forms.DataGridView ButtonsDataGridView;
        private System.Windows.Forms.ComboBox ButtonNamesComboBox;
        private System.Windows.Forms.NumericUpDown StaleTimeoutUpDown;
        private System.Windows.Forms.Label StaleTimeoutLabel;
        private System.Windows.Forms.NumericUpDown TimeoutUpDown;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonColumn;
    }
}