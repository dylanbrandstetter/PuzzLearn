namespace PuzzLearn_Game_Configuration
{
    partial class PlaneForm
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
            this.StructuresColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddXYRegionButton = new System.Windows.Forms.Button();
            this.AddRegionButton = new System.Windows.Forms.Button();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.DeleteObjectButton = new System.Windows.Forms.Button();
            this.EditObjectButton = new System.Windows.Forms.Button();
            this.XAddressPanel = new System.Windows.Forms.Panel();
            this.XAddressesGridView = new System.Windows.Forms.DataGridView();
            this.XAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.XMinUpDown = new System.Windows.Forms.NumericUpDown();
            this.XMaxLabel = new System.Windows.Forms.Label();
            this.XMinLabel = new System.Windows.Forms.Label();
            this.DeleteXButton = new System.Windows.Forms.Button();
            this.EditXButton = new System.Windows.Forms.Button();
            this.AddXButton = new System.Windows.Forms.Button();
            this.YAddressPanel = new System.Windows.Forms.Panel();
            this.YAddressesGridView = new System.Windows.Forms.DataGridView();
            this.YAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YMaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.YMinUpDown = new System.Windows.Forms.NumericUpDown();
            this.YMaxLabel = new System.Windows.Forms.Label();
            this.DeleteYButton = new System.Windows.Forms.Button();
            this.YMinLabel = new System.Windows.Forms.Label();
            this.EditYButton = new System.Windows.Forms.Button();
            this.AddYButton = new System.Windows.Forms.Button();
            this.ButtonTextBox = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.DefaultValueLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DefaultValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.ObjectsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StructuresGridView)).BeginInit();
            this.XAddressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XAddressesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMinUpDown)).BeginInit();
            this.YAddressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YAddressesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMinUpDown)).BeginInit();
            this.ButtonTextBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ObjectsPanel
            // 
            this.ObjectsPanel.Controls.Add(this.StructuresGridView);
            this.ObjectsPanel.Controls.Add(this.AddXYRegionButton);
            this.ObjectsPanel.Controls.Add(this.AddRegionButton);
            this.ObjectsPanel.Controls.Add(this.AddObjectButton);
            this.ObjectsPanel.Controls.Add(this.DeleteObjectButton);
            this.ObjectsPanel.Controls.Add(this.EditObjectButton);
            this.ObjectsPanel.Location = new System.Drawing.Point(12, 12);
            this.ObjectsPanel.Name = "ObjectsPanel";
            this.ObjectsPanel.Size = new System.Drawing.Size(360, 89);
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
            this.StructuresColumn});
            this.StructuresGridView.Location = new System.Drawing.Point(3, 3);
            this.StructuresGridView.MultiSelect = false;
            this.StructuresGridView.Name = "StructuresGridView";
            this.StructuresGridView.ReadOnly = true;
            this.StructuresGridView.RowHeadersVisible = false;
            this.StructuresGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StructuresGridView.Size = new System.Drawing.Size(176, 83);
            this.StructuresGridView.TabIndex = 5;
            // 
            // StructuresColumn
            // 
            this.StructuresColumn.DataPropertyName = "AsString";
            this.StructuresColumn.HeaderText = "Structures";
            this.StructuresColumn.Name = "StructuresColumn";
            this.StructuresColumn.ReadOnly = true;
            this.StructuresColumn.Width = 172;
            // 
            // AddXYRegionButton
            // 
            this.AddXYRegionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddXYRegionButton.Location = new System.Drawing.Point(185, 61);
            this.AddXYRegionButton.Name = "AddXYRegionButton";
            this.AddXYRegionButton.Size = new System.Drawing.Size(91, 23);
            this.AddXYRegionButton.TabIndex = 4;
            this.AddXYRegionButton.Text = "Add XY Region";
            this.AddXYRegionButton.UseVisualStyleBackColor = true;
            this.AddXYRegionButton.Click += new System.EventHandler(this.AddXYRegionButton_Click);
            // 
            // AddRegionButton
            // 
            this.AddRegionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddRegionButton.Location = new System.Drawing.Point(185, 32);
            this.AddRegionButton.Name = "AddRegionButton";
            this.AddRegionButton.Size = new System.Drawing.Size(91, 23);
            this.AddRegionButton.TabIndex = 3;
            this.AddRegionButton.Text = "Add Region";
            this.AddRegionButton.UseVisualStyleBackColor = true;
            this.AddRegionButton.Click += new System.EventHandler(this.AddRegionButton_Click);
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddObjectButton.Location = new System.Drawing.Point(185, 3);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(91, 23);
            this.AddObjectButton.TabIndex = 2;
            this.AddObjectButton.Text = "Add Object";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // DeleteObjectButton
            // 
            this.DeleteObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteObjectButton.Location = new System.Drawing.Point(282, 62);
            this.DeleteObjectButton.Name = "DeleteObjectButton";
            this.DeleteObjectButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteObjectButton.TabIndex = 1;
            this.DeleteObjectButton.Text = "Delete";
            this.DeleteObjectButton.UseVisualStyleBackColor = true;
            this.DeleteObjectButton.Click += new System.EventHandler(this.DeleteObjectButton_Click);
            // 
            // EditObjectButton
            // 
            this.EditObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditObjectButton.Location = new System.Drawing.Point(282, 32);
            this.EditObjectButton.Name = "EditObjectButton";
            this.EditObjectButton.Size = new System.Drawing.Size(75, 23);
            this.EditObjectButton.TabIndex = 0;
            this.EditObjectButton.Text = "Edit";
            this.EditObjectButton.UseVisualStyleBackColor = true;
            this.EditObjectButton.Click += new System.EventHandler(this.EditObjectButton_Click);
            // 
            // XAddressPanel
            // 
            this.XAddressPanel.Controls.Add(this.XAddressesGridView);
            this.XAddressPanel.Controls.Add(this.XMaxUpDown);
            this.XAddressPanel.Controls.Add(this.XMinUpDown);
            this.XAddressPanel.Controls.Add(this.XMaxLabel);
            this.XAddressPanel.Controls.Add(this.XMinLabel);
            this.XAddressPanel.Controls.Add(this.DeleteXButton);
            this.XAddressPanel.Controls.Add(this.EditXButton);
            this.XAddressPanel.Controls.Add(this.AddXButton);
            this.XAddressPanel.Location = new System.Drawing.Point(12, 107);
            this.XAddressPanel.Name = "XAddressPanel";
            this.XAddressPanel.Size = new System.Drawing.Size(360, 89);
            this.XAddressPanel.TabIndex = 1;
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
            this.XAddressesGridView.Size = new System.Drawing.Size(176, 83);
            this.XAddressesGridView.TabIndex = 8;
            // 
            // XAddressColumn
            // 
            this.XAddressColumn.DataPropertyName = "AsString";
            this.XAddressColumn.HeaderText = "X Addresses";
            this.XAddressColumn.Name = "XAddressColumn";
            this.XAddressColumn.ReadOnly = true;
            this.XAddressColumn.Width = 172;
            // 
            // XMaxUpDown
            // 
            this.XMaxUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XMaxUpDown.Location = new System.Drawing.Point(218, 63);
            this.XMaxUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.XMaxUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.XMaxUpDown.Name = "XMaxUpDown";
            this.XMaxUpDown.Size = new System.Drawing.Size(58, 20);
            this.XMaxUpDown.TabIndex = 7;
            this.XMaxUpDown.ValueChanged += new System.EventHandler(this.XMaxUpDown_ValueChanged);
            // 
            // XMinUpDown
            // 
            this.XMinUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XMinUpDown.Location = new System.Drawing.Point(218, 33);
            this.XMinUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.XMinUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.XMinUpDown.Name = "XMinUpDown";
            this.XMinUpDown.Size = new System.Drawing.Size(58, 20);
            this.XMinUpDown.TabIndex = 6;
            this.XMinUpDown.ValueChanged += new System.EventHandler(this.XMinUpDown_ValueChanged);
            // 
            // XMaxLabel
            // 
            this.XMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XMaxLabel.AutoSize = true;
            this.XMaxLabel.Location = new System.Drawing.Point(185, 65);
            this.XMaxLabel.Name = "XMaxLabel";
            this.XMaxLabel.Size = new System.Drawing.Size(30, 13);
            this.XMaxLabel.TabIndex = 6;
            this.XMaxLabel.Text = "Max:";
            // 
            // XMinLabel
            // 
            this.XMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XMinLabel.AutoSize = true;
            this.XMinLabel.Location = new System.Drawing.Point(185, 38);
            this.XMinLabel.Name = "XMinLabel";
            this.XMinLabel.Size = new System.Drawing.Size(27, 13);
            this.XMinLabel.TabIndex = 5;
            this.XMinLabel.Text = "Min:";
            // 
            // DeleteXButton
            // 
            this.DeleteXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteXButton.Location = new System.Drawing.Point(282, 63);
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
            this.EditXButton.Location = new System.Drawing.Point(282, 33);
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
            this.AddXButton.Location = new System.Drawing.Point(282, 3);
            this.AddXButton.Name = "AddXButton";
            this.AddXButton.Size = new System.Drawing.Size(75, 23);
            this.AddXButton.TabIndex = 0;
            this.AddXButton.Text = "Add";
            this.AddXButton.UseVisualStyleBackColor = true;
            this.AddXButton.Click += new System.EventHandler(this.AddXButton_Click);
            // 
            // YAddressPanel
            // 
            this.YAddressPanel.Controls.Add(this.YAddressesGridView);
            this.YAddressPanel.Controls.Add(this.YMaxUpDown);
            this.YAddressPanel.Controls.Add(this.YMinUpDown);
            this.YAddressPanel.Controls.Add(this.YMaxLabel);
            this.YAddressPanel.Controls.Add(this.DeleteYButton);
            this.YAddressPanel.Controls.Add(this.YMinLabel);
            this.YAddressPanel.Controls.Add(this.EditYButton);
            this.YAddressPanel.Controls.Add(this.AddYButton);
            this.YAddressPanel.Location = new System.Drawing.Point(12, 202);
            this.YAddressPanel.Name = "YAddressPanel";
            this.YAddressPanel.Size = new System.Drawing.Size(360, 89);
            this.YAddressPanel.TabIndex = 2;
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
            this.YAddressesGridView.Size = new System.Drawing.Size(176, 83);
            this.YAddressesGridView.TabIndex = 13;
            // 
            // YAddressColumn
            // 
            this.YAddressColumn.DataPropertyName = "AsString";
            this.YAddressColumn.HeaderText = "Y Addresses";
            this.YAddressColumn.Name = "YAddressColumn";
            this.YAddressColumn.ReadOnly = true;
            this.YAddressColumn.Width = 172;
            // 
            // YMaxUpDown
            // 
            this.YMaxUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YMaxUpDown.Location = new System.Drawing.Point(221, 63);
            this.YMaxUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.YMaxUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.YMaxUpDown.Name = "YMaxUpDown";
            this.YMaxUpDown.Size = new System.Drawing.Size(55, 20);
            this.YMaxUpDown.TabIndex = 12;
            this.YMaxUpDown.ValueChanged += new System.EventHandler(this.YMaxUpDown_ValueChanged);
            // 
            // YMinUpDown
            // 
            this.YMinUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YMinUpDown.Location = new System.Drawing.Point(221, 33);
            this.YMinUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.YMinUpDown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.YMinUpDown.Name = "YMinUpDown";
            this.YMinUpDown.Size = new System.Drawing.Size(55, 20);
            this.YMinUpDown.TabIndex = 11;
            this.YMinUpDown.ValueChanged += new System.EventHandler(this.YMinUpDown_ValueChanged);
            // 
            // YMaxLabel
            // 
            this.YMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YMaxLabel.AutoSize = true;
            this.YMaxLabel.Location = new System.Drawing.Point(185, 68);
            this.YMaxLabel.Name = "YMaxLabel";
            this.YMaxLabel.Size = new System.Drawing.Size(30, 13);
            this.YMaxLabel.TabIndex = 10;
            this.YMaxLabel.Text = "Max:";
            // 
            // DeleteYButton
            // 
            this.DeleteYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteYButton.Location = new System.Drawing.Point(282, 63);
            this.DeleteYButton.Name = "DeleteYButton";
            this.DeleteYButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteYButton.TabIndex = 2;
            this.DeleteYButton.Text = "Delete";
            this.DeleteYButton.UseVisualStyleBackColor = true;
            this.DeleteYButton.Click += new System.EventHandler(this.DeleteYButton_Click);
            // 
            // YMinLabel
            // 
            this.YMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YMinLabel.AutoSize = true;
            this.YMinLabel.Location = new System.Drawing.Point(185, 38);
            this.YMinLabel.Name = "YMinLabel";
            this.YMinLabel.Size = new System.Drawing.Size(27, 13);
            this.YMinLabel.TabIndex = 9;
            this.YMinLabel.Text = "Min:";
            // 
            // EditYButton
            // 
            this.EditYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditYButton.Location = new System.Drawing.Point(282, 33);
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
            this.AddYButton.Location = new System.Drawing.Point(282, 4);
            this.AddYButton.Name = "AddYButton";
            this.AddYButton.Size = new System.Drawing.Size(75, 23);
            this.AddYButton.TabIndex = 0;
            this.AddYButton.Text = "Add";
            this.AddYButton.UseVisualStyleBackColor = true;
            this.AddYButton.Click += new System.EventHandler(this.AddYButton_Click);
            // 
            // ButtonTextBox
            // 
            this.ButtonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTextBox.Controls.Add(this.CancelButton);
            this.ButtonTextBox.Controls.Add(this.ConfirmButton);
            this.ButtonTextBox.Location = new System.Drawing.Point(12, 334);
            this.ButtonTextBox.Name = "ButtonTextBox";
            this.ButtonTextBox.Size = new System.Drawing.Size(360, 31);
            this.ButtonTextBox.TabIndex = 15;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(282, 3);
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
            this.ConfirmButton.Location = new System.Drawing.Point(201, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DefaultValueLabel
            // 
            this.DefaultValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultValueLabel.AutoSize = true;
            this.DefaultValueLabel.Location = new System.Drawing.Point(203, 7);
            this.DefaultValueLabel.Name = "DefaultValueLabel";
            this.DefaultValueLabel.Size = new System.Drawing.Size(73, 13);
            this.DefaultValueLabel.TabIndex = 1;
            this.DefaultValueLabel.Text = "Default value:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 6);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "*Description:";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(76, 4);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(102, 20);
            this.DescriptionTextBox.TabIndex = 3;
            this.DescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionTextBox_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DefaultValueUpDown);
            this.panel1.Controls.Add(this.DescriptionTextBox);
            this.panel1.Controls.Add(this.DescriptionLabel);
            this.panel1.Controls.Add(this.DefaultValueLabel);
            this.panel1.Location = new System.Drawing.Point(12, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 28);
            this.panel1.TabIndex = 3;
            // 
            // DefaultValueUpDown
            // 
            this.DefaultValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultValueUpDown.Location = new System.Drawing.Point(282, 3);
            this.DefaultValueUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.DefaultValueUpDown.Name = "DefaultValueUpDown";
            this.DefaultValueUpDown.Size = new System.Drawing.Size(38, 20);
            this.DefaultValueUpDown.TabIndex = 6;
            // 
            // PlaneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 371);
            this.Controls.Add(this.ButtonTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.YAddressPanel);
            this.Controls.Add(this.XAddressPanel);
            this.Controls.Add(this.ObjectsPanel);
            this.MaximumSize = new System.Drawing.Size(400, 410);
            this.MinimumSize = new System.Drawing.Size(400, 410);
            this.Name = "PlaneForm";
            this.Text = "Address Plane";
            this.ObjectsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StructuresGridView)).EndInit();
            this.XAddressPanel.ResumeLayout(false);
            this.XAddressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XAddressesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMinUpDown)).EndInit();
            this.YAddressPanel.ResumeLayout(false);
            this.YAddressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YAddressesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMinUpDown)).EndInit();
            this.ButtonTextBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultValueUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ObjectsPanel;
        private System.Windows.Forms.Button AddXYRegionButton;
        private System.Windows.Forms.Button AddRegionButton;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.Button DeleteObjectButton;
        private System.Windows.Forms.Button EditObjectButton;
        private System.Windows.Forms.Panel XAddressPanel;
        private System.Windows.Forms.Panel YAddressPanel;
        private System.Windows.Forms.Button DeleteXButton;
        private System.Windows.Forms.Button EditXButton;
        private System.Windows.Forms.Button AddXButton;
        private System.Windows.Forms.Button DeleteYButton;
        private System.Windows.Forms.Button EditYButton;
        private System.Windows.Forms.Button AddYButton;
        private System.Windows.Forms.Label XMaxLabel;
        private System.Windows.Forms.Label XMinLabel;
        private System.Windows.Forms.Label YMaxLabel;
        private System.Windows.Forms.Label YMinLabel;
        private System.Windows.Forms.Panel ButtonTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.NumericUpDown XMaxUpDown;
        private System.Windows.Forms.NumericUpDown XMinUpDown;
        private System.Windows.Forms.NumericUpDown YMaxUpDown;
        private System.Windows.Forms.NumericUpDown YMinUpDown;
        private System.Windows.Forms.Label DefaultValueLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown DefaultValueUpDown;
        private System.Windows.Forms.DataGridView StructuresGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn StructuresColumn;
        private System.Windows.Forms.DataGridView XAddressesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn XAddressColumn;
        private System.Windows.Forms.DataGridView YAddressesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn YAddressColumn;
    }
}