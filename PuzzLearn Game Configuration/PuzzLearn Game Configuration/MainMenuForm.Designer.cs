namespace PuzzLearn_Game_Configuration
{
    partial class MainMenuForm
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
            this.ObjectListPanel = new System.Windows.Forms.Panel();
            this.DatabaseDataGridView = new System.Windows.Forms.DataGridView();
            this.ControlButtonsPanel = new System.Windows.Forms.Panel();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddInfoButton = new System.Windows.Forms.Button();
            this.AddPlaneButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScoreAddressDataGridView = new System.Windows.Forms.DataGridView();
            this.EditScoreButton = new System.Windows.Forms.Button();
            this.DeleteScoreButton = new System.Windows.Forms.Button();
            this.AddScoreButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DatabaseSettingsButton = new System.Windows.Forms.Button();
            this.ScoreAddressesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsStringColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseDataGridView)).BeginInit();
            this.ControlButtonsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreAddressDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectListPanel
            // 
            this.ObjectListPanel.Controls.Add(this.DatabaseDataGridView);
            this.ObjectListPanel.Location = new System.Drawing.Point(12, 27);
            this.ObjectListPanel.Name = "ObjectListPanel";
            this.ObjectListPanel.Size = new System.Drawing.Size(253, 256);
            this.ObjectListPanel.TabIndex = 2;
            // 
            // DatabaseDataGridView
            // 
            this.DatabaseDataGridView.AllowUserToAddRows = false;
            this.DatabaseDataGridView.AllowUserToDeleteRows = false;
            this.DatabaseDataGridView.AllowUserToResizeColumns = false;
            this.DatabaseDataGridView.AllowUserToResizeRows = false;
            this.DatabaseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatabaseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AsStringColumn});
            this.DatabaseDataGridView.Location = new System.Drawing.Point(4, 4);
            this.DatabaseDataGridView.MultiSelect = false;
            this.DatabaseDataGridView.Name = "DatabaseDataGridView";
            this.DatabaseDataGridView.ReadOnly = true;
            this.DatabaseDataGridView.RowHeadersVisible = false;
            this.DatabaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatabaseDataGridView.Size = new System.Drawing.Size(246, 249);
            this.DatabaseDataGridView.TabIndex = 0;
            this.DatabaseDataGridView.TabStop = false;
            // 
            // ControlButtonsPanel
            // 
            this.ControlButtonsPanel.Controls.Add(this.EditButton);
            this.ControlButtonsPanel.Controls.Add(this.DeleteButton);
            this.ControlButtonsPanel.Controls.Add(this.AddInfoButton);
            this.ControlButtonsPanel.Controls.Add(this.AddPlaneButton);
            this.ControlButtonsPanel.Location = new System.Drawing.Point(12, 289);
            this.ControlButtonsPanel.Name = "ControlButtonsPanel";
            this.ControlButtonsPanel.Size = new System.Drawing.Size(253, 60);
            this.ControlButtonsPanel.TabIndex = 0;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(3, 32);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(120, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit struct";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(130, 32);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete struct";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddInfoButton
            // 
            this.AddInfoButton.Location = new System.Drawing.Point(130, 3);
            this.AddInfoButton.Name = "AddInfoButton";
            this.AddInfoButton.Size = new System.Drawing.Size(120, 23);
            this.AddInfoButton.TabIndex = 1;
            this.AddInfoButton.Text = "Add info";
            this.AddInfoButton.UseVisualStyleBackColor = true;
            this.AddInfoButton.Click += new System.EventHandler(this.AddInfoButton_Click);
            // 
            // AddPlaneButton
            // 
            this.AddPlaneButton.Location = new System.Drawing.Point(3, 3);
            this.AddPlaneButton.Name = "AddPlaneButton";
            this.AddPlaneButton.Size = new System.Drawing.Size(120, 23);
            this.AddPlaneButton.TabIndex = 0;
            this.AddPlaneButton.Text = "Add plane";
            this.AddPlaneButton.UseVisualStyleBackColor = true;
            this.AddPlaneButton.Click += new System.EventHandler(this.AddPlaneButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.onlineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "MainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.myFilesToolStripMenuItem});
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.onlineToolStripMenuItem.Text = "Online";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // myFilesToolStripMenuItem
            // 
            this.myFilesToolStripMenuItem.Name = "myFilesToolStripMenuItem";
            this.myFilesToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.myFilesToolStripMenuItem.Text = "My files";
            this.myFilesToolStripMenuItem.Click += new System.EventHandler(this.myFilesToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ScoreAddressDataGridView);
            this.panel1.Location = new System.Drawing.Point(271, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 225);
            this.panel1.TabIndex = 3;
            // 
            // ScoreAddressDataGridView
            // 
            this.ScoreAddressDataGridView.AllowUserToAddRows = false;
            this.ScoreAddressDataGridView.AllowUserToDeleteRows = false;
            this.ScoreAddressDataGridView.AllowUserToResizeColumns = false;
            this.ScoreAddressDataGridView.AllowUserToResizeRows = false;
            this.ScoreAddressDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoreAddressDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScoreAddressesColumn});
            this.ScoreAddressDataGridView.Location = new System.Drawing.Point(4, 4);
            this.ScoreAddressDataGridView.MultiSelect = false;
            this.ScoreAddressDataGridView.Name = "ScoreAddressDataGridView";
            this.ScoreAddressDataGridView.ReadOnly = true;
            this.ScoreAddressDataGridView.RowHeadersVisible = false;
            this.ScoreAddressDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ScoreAddressDataGridView.Size = new System.Drawing.Size(246, 218);
            this.ScoreAddressDataGridView.TabIndex = 0;
            this.ScoreAddressDataGridView.TabStop = false;
            // 
            // EditScoreButton
            // 
            this.EditScoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditScoreButton.Location = new System.Drawing.Point(3, 34);
            this.EditScoreButton.Name = "EditScoreButton";
            this.EditScoreButton.Size = new System.Drawing.Size(120, 23);
            this.EditScoreButton.TabIndex = 1;
            this.EditScoreButton.Text = "Edit score";
            this.EditScoreButton.UseVisualStyleBackColor = true;
            this.EditScoreButton.Click += new System.EventHandler(this.EditScoreButton_Click);
            // 
            // DeleteScoreButton
            // 
            this.DeleteScoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteScoreButton.Location = new System.Drawing.Point(130, 34);
            this.DeleteScoreButton.Name = "DeleteScoreButton";
            this.DeleteScoreButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteScoreButton.TabIndex = 2;
            this.DeleteScoreButton.Text = "Delete score";
            this.DeleteScoreButton.UseVisualStyleBackColor = true;
            this.DeleteScoreButton.Click += new System.EventHandler(this.DeleteScoreButton_Click);
            // 
            // AddScoreButton
            // 
            this.AddScoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddScoreButton.Location = new System.Drawing.Point(130, 5);
            this.AddScoreButton.Name = "AddScoreButton";
            this.AddScoreButton.Size = new System.Drawing.Size(120, 23);
            this.AddScoreButton.TabIndex = 0;
            this.AddScoreButton.Text = "Add score";
            this.AddScoreButton.UseVisualStyleBackColor = true;
            this.AddScoreButton.Click += new System.EventHandler(this.AddScoreButton_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.AddScoreButton);
            this.panel3.Controls.Add(this.DeleteScoreButton);
            this.panel3.Controls.Add(this.EditScoreButton);
            this.panel3.Controls.Add(this.DatabaseSettingsButton);
            this.panel3.Location = new System.Drawing.Point(271, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 91);
            this.panel3.TabIndex = 1;
            // 
            // DatabaseSettingsButton
            // 
            this.DatabaseSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseSettingsButton.Location = new System.Drawing.Point(3, 63);
            this.DatabaseSettingsButton.Name = "DatabaseSettingsButton";
            this.DatabaseSettingsButton.Size = new System.Drawing.Size(247, 23);
            this.DatabaseSettingsButton.TabIndex = 3;
            this.DatabaseSettingsButton.Text = "Edit Database Settings";
            this.DatabaseSettingsButton.UseVisualStyleBackColor = true;
            this.DatabaseSettingsButton.Click += new System.EventHandler(this.DatabaseSettingsButton_Click);
            // 
            // ScoreAddressesColumn
            // 
            this.ScoreAddressesColumn.DataPropertyName = "AsString";
            this.ScoreAddressesColumn.HeaderText = "Score Addresses";
            this.ScoreAddressesColumn.Name = "ScoreAddressesColumn";
            this.ScoreAddressesColumn.ReadOnly = true;
            this.ScoreAddressesColumn.Width = 229;
            // 
            // AsStringColumn
            // 
            this.AsStringColumn.DataPropertyName = "AsString";
            this.AsStringColumn.HeaderText = "Structures";
            this.AsStringColumn.Name = "AsStringColumn";
            this.AsStringColumn.ReadOnly = true;
            this.AsStringColumn.Width = 229;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 361);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ControlButtonsPanel);
            this.Controls.Add(this.ObjectListPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.Text = "PuzzLearn - Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ObjectListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseDataGridView)).EndInit();
            this.ControlButtonsPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreAddressDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ObjectListPanel;
        private System.Windows.Forms.Panel ControlButtonsPanel;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddInfoButton;
        private System.Windows.Forms.Button AddPlaneButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.DataGridView DatabaseDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ScoreAddressDataGridView;
        private System.Windows.Forms.Button EditScoreButton;
        private System.Windows.Forms.Button DeleteScoreButton;
        private System.Windows.Forms.Button AddScoreButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button DatabaseSettingsButton;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myFilesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsStringColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreAddressesColumn;
    }
}