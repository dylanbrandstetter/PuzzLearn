namespace PuzzLearn_Game_Configuration
{
    partial class RegionForm
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
            this.ObjectsPanel = new System.Windows.Forms.Panel();
            this.StructuresGridView = new System.Windows.Forms.DataGridView();
            this.AddRegionButton = new System.Windows.Forms.Button();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ButtonTextBox = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StartAddressLabel = new System.Windows.Forms.Label();
            this.StartAddressTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EndAddressLabel = new System.Windows.Forms.Label();
            this.EndAddressTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AddressIncrementLabel = new System.Windows.Forms.Label();
            this.AddressIncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.AsStringColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StructuresGridView)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            this.DescriptionPanel.SuspendLayout();
            this.ButtonTextBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddressIncrementUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ObjectsPanel
            // 
            this.ObjectsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectsPanel.Controls.Add(this.StructuresGridView);
            this.ObjectsPanel.Location = new System.Drawing.Point(12, 12);
            this.ObjectsPanel.Name = "ObjectsPanel";
            this.ObjectsPanel.Size = new System.Drawing.Size(260, 101);
            this.ObjectsPanel.TabIndex = 0;
            // 
            // StructuresGridView
            // 
            this.StructuresGridView.AllowUserToAddRows = false;
            this.StructuresGridView.AllowUserToDeleteRows = false;
            this.StructuresGridView.AllowUserToResizeColumns = false;
            this.StructuresGridView.AllowUserToResizeRows = false;
            this.StructuresGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StructuresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StructuresGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AsStringColumn});
            this.StructuresGridView.Location = new System.Drawing.Point(3, 3);
            this.StructuresGridView.MultiSelect = false;
            this.StructuresGridView.Name = "StructuresGridView";
            this.StructuresGridView.ReadOnly = true;
            this.StructuresGridView.RowHeadersVisible = false;
            this.StructuresGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StructuresGridView.Size = new System.Drawing.Size(254, 95);
            this.StructuresGridView.TabIndex = 1;
            this.StructuresGridView.TabStop = false;
            // 
            // AddRegionButton
            // 
            this.AddRegionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddRegionButton.Location = new System.Drawing.Point(182, 3);
            this.AddRegionButton.Name = "AddRegionButton";
            this.AddRegionButton.Size = new System.Drawing.Size(75, 23);
            this.AddRegionButton.TabIndex = 1;
            this.AddRegionButton.Text = "Add Region";
            this.AddRegionButton.UseVisualStyleBackColor = true;
            this.AddRegionButton.Click += new System.EventHandler(this.AddRegionButton_Click);
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddObjectButton.Location = new System.Drawing.Point(101, 3);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(75, 23);
            this.AddObjectButton.TabIndex = 0;
            this.AddObjectButton.Text = "Add Object";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(182, 32);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Location = new System.Drawing.Point(101, 32);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.AddObjectButton);
            this.ButtonsPanel.Controls.Add(this.DeleteButton);
            this.ButtonsPanel.Controls.Add(this.EditButton);
            this.ButtonsPanel.Controls.Add(this.AddRegionButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 119);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(260, 60);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Controls.Add(this.DescriptionTextBox);
            this.DescriptionPanel.Location = new System.Drawing.Point(12, 185);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(260, 29);
            this.DescriptionPanel.TabIndex = 2;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(41, 7);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "*Description:";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(114, 4);
            this.DescriptionTextBox.MaxLength = 32;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(143, 20);
            this.DescriptionTextBox.TabIndex = 0;
            this.DescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
            this.DescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionTextBox_KeyPress);
            // 
            // ButtonTextBox
            // 
            this.ButtonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTextBox.Controls.Add(this.CancelButton);
            this.ButtonTextBox.Controls.Add(this.ConfirmButton);
            this.ButtonTextBox.Location = new System.Drawing.Point(12, 325);
            this.ButtonTextBox.Name = "ButtonTextBox";
            this.ButtonTextBox.Size = new System.Drawing.Size(260, 31);
            this.ButtonTextBox.TabIndex = 6;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(182, 3);
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
            this.ConfirmButton.Location = new System.Drawing.Point(101, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.StartAddressLabel);
            this.panel1.Controls.Add(this.StartAddressTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 29);
            this.panel1.TabIndex = 3;
            // 
            // StartAddressLabel
            // 
            this.StartAddressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartAddressLabel.AutoSize = true;
            this.StartAddressLabel.Location = new System.Drawing.Point(3, 7);
            this.StartAddressLabel.Name = "StartAddressLabel";
            this.StartAddressLabel.Size = new System.Drawing.Size(105, 13);
            this.StartAddressLabel.TabIndex = 1;
            this.StartAddressLabel.Text = "*Start Address (Hex):";
            // 
            // StartAddressTextBox
            // 
            this.StartAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartAddressTextBox.Location = new System.Drawing.Point(114, 4);
            this.StartAddressTextBox.MaxLength = 8;
            this.StartAddressTextBox.Name = "StartAddressTextBox";
            this.StartAddressTextBox.Size = new System.Drawing.Size(143, 20);
            this.StartAddressTextBox.TabIndex = 0;
            this.StartAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressTextBox_KeyDown);
            this.StartAddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTextBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.EndAddressLabel);
            this.panel2.Controls.Add(this.EndAddressTextBox);
            this.panel2.Location = new System.Drawing.Point(12, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 29);
            this.panel2.TabIndex = 4;
            // 
            // EndAddressLabel
            // 
            this.EndAddressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndAddressLabel.AutoSize = true;
            this.EndAddressLabel.Location = new System.Drawing.Point(6, 7);
            this.EndAddressLabel.Name = "EndAddressLabel";
            this.EndAddressLabel.Size = new System.Drawing.Size(102, 13);
            this.EndAddressLabel.TabIndex = 1;
            this.EndAddressLabel.Text = "*End Address (Hex):";
            // 
            // EndAddressTextBox
            // 
            this.EndAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndAddressTextBox.Location = new System.Drawing.Point(114, 4);
            this.EndAddressTextBox.MaxLength = 8;
            this.EndAddressTextBox.Name = "EndAddressTextBox";
            this.EndAddressTextBox.Size = new System.Drawing.Size(143, 20);
            this.EndAddressTextBox.TabIndex = 0;
            this.EndAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressTextBox_KeyDown);
            this.EndAddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTextBox_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.AddressIncrementLabel);
            this.panel3.Controls.Add(this.AddressIncrementUpDown);
            this.panel3.Location = new System.Drawing.Point(12, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 29);
            this.panel3.TabIndex = 5;
            // 
            // AddressIncrementLabel
            // 
            this.AddressIncrementLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressIncrementLabel.AutoSize = true;
            this.AddressIncrementLabel.Location = new System.Drawing.Point(10, 6);
            this.AddressIncrementLabel.Name = "AddressIncrementLabel";
            this.AddressIncrementLabel.Size = new System.Drawing.Size(98, 13);
            this.AddressIncrementLabel.TabIndex = 1;
            this.AddressIncrementLabel.Text = "Address Increment:";
            // 
            // AddressIncrementUpDown
            // 
            this.AddressIncrementUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressIncrementUpDown.Location = new System.Drawing.Point(114, 4);
            this.AddressIncrementUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.AddressIncrementUpDown.Name = "AddressIncrementUpDown";
            this.AddressIncrementUpDown.Size = new System.Drawing.Size(143, 20);
            this.AddressIncrementUpDown.TabIndex = 0;
            this.AddressIncrementUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AsStringColumn
            // 
            this.AsStringColumn.DataPropertyName = "AsString";
            this.AsStringColumn.HeaderText = "Structures";
            this.AsStringColumn.Name = "AsStringColumn";
            this.AsStringColumn.ReadOnly = true;
            this.AsStringColumn.Width = 237;
            // 
            // RegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 364);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButtonTextBox);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.ObjectsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 500);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "RegionForm";
            this.Text = "RegionForm";
            this.ObjectsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StructuresGridView)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            this.ButtonTextBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddressIncrementUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ObjectsPanel;
        private System.Windows.Forms.Button AddRegionButton;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Panel DescriptionPanel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Panel ButtonTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.DataGridView StructuresGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label StartAddressLabel;
        private System.Windows.Forms.TextBox StartAddressTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label EndAddressLabel;
        private System.Windows.Forms.TextBox EndAddressTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label AddressIncrementLabel;
        private System.Windows.Forms.NumericUpDown AddressIncrementUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsStringColumn;
    }
}