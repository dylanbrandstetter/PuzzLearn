namespace PuzzLearn_Game_Configuration
{
    partial class ObjectForm
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
            this.YAddressPanel = new System.Windows.Forms.Panel();
            this.YAddressesGridView = new System.Windows.Forms.DataGridView();
            this.DeleteYButton = new System.Windows.Forms.Button();
            this.EditYButton = new System.Windows.Forms.Button();
            this.AddYButton = new System.Windows.Forms.Button();
            this.XAddressPanel = new System.Windows.Forms.Panel();
            this.XAddressesGridView = new System.Windows.Forms.DataGridView();
            this.DeleteXButton = new System.Windows.Forms.Button();
            this.EditXButton = new System.Windows.Forms.Button();
            this.AddXButton = new System.Windows.Forms.Button();
            this.InformationAddressPanel = new System.Windows.Forms.Panel();
            this.DeleteAddressButton = new System.Windows.Forms.Button();
            this.AddEditAddressButton = new System.Windows.Forms.Button();
            this.InformationAddressLabel = new System.Windows.Forms.Label();
            this.InformationAddressTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FixedValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.FixedValueLabel = new System.Windows.Forms.Label();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.YAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YAddressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YAddressesGridView)).BeginInit();
            this.XAddressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XAddressesGridView)).BeginInit();
            this.InformationAddressPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FixedValueUpDown)).BeginInit();
            this.DescriptionPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // YAddressPanel
            // 
            this.YAddressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YAddressPanel.Controls.Add(this.YAddressesGridView);
            this.YAddressPanel.Controls.Add(this.DeleteYButton);
            this.YAddressPanel.Controls.Add(this.EditYButton);
            this.YAddressPanel.Controls.Add(this.AddYButton);
            this.YAddressPanel.Location = new System.Drawing.Point(12, 107);
            this.YAddressPanel.Name = "YAddressPanel";
            this.YAddressPanel.Size = new System.Drawing.Size(310, 89);
            this.YAddressPanel.TabIndex = 1;
            // 
            // YAddressesGridView
            // 
            this.YAddressesGridView.AllowUserToAddRows = false;
            this.YAddressesGridView.AllowUserToDeleteRows = false;
            this.YAddressesGridView.AllowUserToResizeColumns = false;
            this.YAddressesGridView.AllowUserToResizeRows = false;
            this.YAddressesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YAddressesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.YAddressesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YAddressColumn});
            this.YAddressesGridView.Location = new System.Drawing.Point(3, 3);
            this.YAddressesGridView.MultiSelect = false;
            this.YAddressesGridView.Name = "YAddressesGridView";
            this.YAddressesGridView.ReadOnly = true;
            this.YAddressesGridView.RowHeadersVisible = false;
            this.YAddressesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.YAddressesGridView.Size = new System.Drawing.Size(223, 83);
            this.YAddressesGridView.TabIndex = 13;
            this.YAddressesGridView.TabStop = false;
            // 
            // DeleteYButton
            // 
            this.DeleteYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteYButton.Location = new System.Drawing.Point(232, 63);
            this.DeleteYButton.Name = "DeleteYButton";
            this.DeleteYButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteYButton.TabIndex = 2;
            this.DeleteYButton.Text = "Delete";
            this.DeleteYButton.UseVisualStyleBackColor = true;
            this.DeleteYButton.Click += new System.EventHandler(this.DeleteYButton_Click);
            // 
            // EditYButton
            // 
            this.EditYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditYButton.Location = new System.Drawing.Point(232, 33);
            this.EditYButton.Name = "EditYButton";
            this.EditYButton.Size = new System.Drawing.Size(75, 23);
            this.EditYButton.TabIndex = 1;
            this.EditYButton.Text = "Edit";
            this.EditYButton.UseVisualStyleBackColor = true;
            this.EditYButton.Click += new System.EventHandler(this.EditYButton_Click);
            // 
            // AddYButton
            // 
            this.AddYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddYButton.Location = new System.Drawing.Point(232, 4);
            this.AddYButton.Name = "AddYButton";
            this.AddYButton.Size = new System.Drawing.Size(75, 23);
            this.AddYButton.TabIndex = 0;
            this.AddYButton.Text = "Add";
            this.AddYButton.UseVisualStyleBackColor = true;
            this.AddYButton.Click += new System.EventHandler(this.AddYButton_Click);
            // 
            // XAddressPanel
            // 
            this.XAddressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XAddressPanel.Controls.Add(this.XAddressesGridView);
            this.XAddressPanel.Controls.Add(this.DeleteXButton);
            this.XAddressPanel.Controls.Add(this.EditXButton);
            this.XAddressPanel.Controls.Add(this.AddXButton);
            this.XAddressPanel.Location = new System.Drawing.Point(12, 12);
            this.XAddressPanel.Name = "XAddressPanel";
            this.XAddressPanel.Size = new System.Drawing.Size(310, 89);
            this.XAddressPanel.TabIndex = 0;
            // 
            // XAddressesGridView
            // 
            this.XAddressesGridView.AllowUserToAddRows = false;
            this.XAddressesGridView.AllowUserToDeleteRows = false;
            this.XAddressesGridView.AllowUserToResizeColumns = false;
            this.XAddressesGridView.AllowUserToResizeRows = false;
            this.XAddressesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XAddressesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XAddressesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XAddressColumn});
            this.XAddressesGridView.Location = new System.Drawing.Point(3, 3);
            this.XAddressesGridView.MultiSelect = false;
            this.XAddressesGridView.Name = "XAddressesGridView";
            this.XAddressesGridView.ReadOnly = true;
            this.XAddressesGridView.RowHeadersVisible = false;
            this.XAddressesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.XAddressesGridView.Size = new System.Drawing.Size(223, 83);
            this.XAddressesGridView.TabIndex = 8;
            this.XAddressesGridView.TabStop = false;
            // 
            // DeleteXButton
            // 
            this.DeleteXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteXButton.Location = new System.Drawing.Point(232, 63);
            this.DeleteXButton.Name = "DeleteXButton";
            this.DeleteXButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteXButton.TabIndex = 2;
            this.DeleteXButton.Text = "Delete";
            this.DeleteXButton.UseVisualStyleBackColor = true;
            this.DeleteXButton.Click += new System.EventHandler(this.DeleteXButton_Click);
            // 
            // EditXButton
            // 
            this.EditXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditXButton.Location = new System.Drawing.Point(232, 33);
            this.EditXButton.Name = "EditXButton";
            this.EditXButton.Size = new System.Drawing.Size(75, 23);
            this.EditXButton.TabIndex = 1;
            this.EditXButton.Text = "Edit";
            this.EditXButton.UseVisualStyleBackColor = true;
            this.EditXButton.Click += new System.EventHandler(this.EditXButton_Click);
            // 
            // AddXButton
            // 
            this.AddXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddXButton.Location = new System.Drawing.Point(232, 3);
            this.AddXButton.Name = "AddXButton";
            this.AddXButton.Size = new System.Drawing.Size(75, 23);
            this.AddXButton.TabIndex = 0;
            this.AddXButton.Text = "Add";
            this.AddXButton.UseVisualStyleBackColor = true;
            this.AddXButton.Click += new System.EventHandler(this.AddXButton_Click);
            // 
            // InformationAddressPanel
            // 
            this.InformationAddressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationAddressPanel.Controls.Add(this.DeleteAddressButton);
            this.InformationAddressPanel.Controls.Add(this.AddEditAddressButton);
            this.InformationAddressPanel.Controls.Add(this.InformationAddressLabel);
            this.InformationAddressPanel.Controls.Add(this.InformationAddressTextBox);
            this.InformationAddressPanel.Location = new System.Drawing.Point(12, 203);
            this.InformationAddressPanel.Name = "InformationAddressPanel";
            this.InformationAddressPanel.Size = new System.Drawing.Size(310, 61);
            this.InformationAddressPanel.TabIndex = 2;
            // 
            // DeleteAddressButton
            // 
            this.DeleteAddressButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteAddressButton.Location = new System.Drawing.Point(232, 32);
            this.DeleteAddressButton.Name = "DeleteAddressButton";
            this.DeleteAddressButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteAddressButton.TabIndex = 1;
            this.DeleteAddressButton.Text = "Delete";
            this.DeleteAddressButton.UseVisualStyleBackColor = true;
            this.DeleteAddressButton.Click += new System.EventHandler(this.DeleteAddressButton_Click);
            // 
            // AddEditAddressButton
            // 
            this.AddEditAddressButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEditAddressButton.Location = new System.Drawing.Point(232, 3);
            this.AddEditAddressButton.Name = "AddEditAddressButton";
            this.AddEditAddressButton.Size = new System.Drawing.Size(75, 23);
            this.AddEditAddressButton.TabIndex = 0;
            this.AddEditAddressButton.Text = "Add/Edit";
            this.AddEditAddressButton.UseVisualStyleBackColor = true;
            this.AddEditAddressButton.Click += new System.EventHandler(this.AddEditAddressButton_Click);
            // 
            // InformationAddressLabel
            // 
            this.InformationAddressLabel.AutoSize = true;
            this.InformationAddressLabel.Location = new System.Drawing.Point(3, 8);
            this.InformationAddressLabel.Name = "InformationAddressLabel";
            this.InformationAddressLabel.Size = new System.Drawing.Size(100, 13);
            this.InformationAddressLabel.TabIndex = 1;
            this.InformationAddressLabel.Text = "Information Address";
            // 
            // InformationAddressTextBox
            // 
            this.InformationAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationAddressTextBox.Location = new System.Drawing.Point(3, 34);
            this.InformationAddressTextBox.Name = "InformationAddressTextBox";
            this.InformationAddressTextBox.ReadOnly = true;
            this.InformationAddressTextBox.Size = new System.Drawing.Size(223, 20);
            this.InformationAddressTextBox.TabIndex = 0;
            this.InformationAddressTextBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.FixedValueUpDown);
            this.panel1.Controls.Add(this.FixedValueLabel);
            this.panel1.Location = new System.Drawing.Point(12, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 27);
            this.panel1.TabIndex = 3;
            // 
            // FixedValueUpDown
            // 
            this.FixedValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FixedValueUpDown.Location = new System.Drawing.Point(232, 3);
            this.FixedValueUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.FixedValueUpDown.Name = "FixedValueUpDown";
            this.FixedValueUpDown.Size = new System.Drawing.Size(75, 20);
            this.FixedValueUpDown.TabIndex = 0;
            // 
            // FixedValueLabel
            // 
            this.FixedValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FixedValueLabel.AutoSize = true;
            this.FixedValueLabel.Location = new System.Drawing.Point(162, 5);
            this.FixedValueLabel.Name = "FixedValueLabel";
            this.FixedValueLabel.Size = new System.Drawing.Size(64, 13);
            this.FixedValueLabel.TabIndex = 7;
            this.FixedValueLabel.Text = "Fixed value:";
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionPanel.Controls.Add(this.DescriptionTextBox);
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Location = new System.Drawing.Point(12, 303);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(310, 28);
            this.DescriptionPanel.TabIndex = 4;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(151, 4);
            this.DescriptionTextBox.MaxLength = 32;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(156, 20);
            this.DescriptionTextBox.TabIndex = 0;
            this.DescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
            this.DescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionTextBox_KeyPress);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(78, 7);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "*Description:";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.CancelButton);
            this.ButtonsPanel.Controls.Add(this.ConfirmButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 337);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(310, 31);
            this.ButtonsPanel.TabIndex = 5;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(232, 3);
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
            this.ConfirmButton.Location = new System.Drawing.Point(151, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // YAddressColumn
            // 
            this.YAddressColumn.DataPropertyName = "AsString";
            this.YAddressColumn.HeaderText = "Y Addresses";
            this.YAddressColumn.Name = "YAddressColumn";
            this.YAddressColumn.ReadOnly = true;
            this.YAddressColumn.Width = 206;
            // 
            // XAddressColumn
            // 
            this.XAddressColumn.DataPropertyName = "AsString";
            this.XAddressColumn.HeaderText = "X Addresses";
            this.XAddressColumn.Name = "XAddressColumn";
            this.XAddressColumn.ReadOnly = true;
            this.XAddressColumn.Width = 206;
            // 
            // ObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 374);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InformationAddressPanel);
            this.Controls.Add(this.YAddressPanel);
            this.Controls.Add(this.XAddressPanel);
            this.MaximizeBox = false;
            this.Name = "ObjectForm";
            this.Text = "ObjectBlockForm";
            this.YAddressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YAddressesGridView)).EndInit();
            this.XAddressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XAddressesGridView)).EndInit();
            this.InformationAddressPanel.ResumeLayout(false);
            this.InformationAddressPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FixedValueUpDown)).EndInit();
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel YAddressPanel;
        private System.Windows.Forms.DataGridView YAddressesGridView;
        private System.Windows.Forms.Button DeleteYButton;
        private System.Windows.Forms.Button EditYButton;
        private System.Windows.Forms.Button AddYButton;
        private System.Windows.Forms.Panel XAddressPanel;
        private System.Windows.Forms.DataGridView XAddressesGridView;
        private System.Windows.Forms.Button DeleteXButton;
        private System.Windows.Forms.Button EditXButton;
        private System.Windows.Forms.Button AddXButton;
        private System.Windows.Forms.Panel InformationAddressPanel;
        private System.Windows.Forms.Label InformationAddressLabel;
        private System.Windows.Forms.TextBox InformationAddressTextBox;
        private System.Windows.Forms.Button DeleteAddressButton;
        private System.Windows.Forms.Button AddEditAddressButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown FixedValueUpDown;
        private System.Windows.Forms.Label FixedValueLabel;
        private System.Windows.Forms.Panel DescriptionPanel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn YAddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn XAddressColumn;
    }
}