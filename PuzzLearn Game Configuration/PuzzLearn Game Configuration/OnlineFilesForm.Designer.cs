namespace PuzzLearn_Game_Configuration
{
    partial class OnlineFilesForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.FilenamesPanel = new System.Windows.Forms.Panel();
            this.FileNamesDataGridView = new System.Windows.Forms.DataGridView();
            this.FilenameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.UploadFilenamePanel = new System.Windows.Forms.Panel();
            this.UploadFileNameLabel = new System.Windows.Forms.Label();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.SignOutButton = new System.Windows.Forms.Button();
            this.ExitPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.FilenamesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileNamesDataGridView)).BeginInit();
            this.SearchPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.UploadFilenamePanel.SuspendLayout();
            this.ExitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(135, 31);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Download";
            // 
            // FilenamesPanel
            // 
            this.FilenamesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilenamesPanel.Controls.Add(this.FileNamesDataGridView);
            this.FilenamesPanel.Location = new System.Drawing.Point(12, 78);
            this.FilenamesPanel.Name = "FilenamesPanel";
            this.FilenamesPanel.Size = new System.Drawing.Size(360, 275);
            this.FilenamesPanel.TabIndex = 1;
            // 
            // FileNamesDataGridView
            // 
            this.FileNamesDataGridView.AllowUserToAddRows = false;
            this.FileNamesDataGridView.AllowUserToDeleteRows = false;
            this.FileNamesDataGridView.AllowUserToResizeColumns = false;
            this.FileNamesDataGridView.AllowUserToResizeRows = false;
            this.FileNamesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNamesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileNamesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FilenameColumn});
            this.FileNamesDataGridView.Location = new System.Drawing.Point(4, 4);
            this.FileNamesDataGridView.MultiSelect = false;
            this.FileNamesDataGridView.Name = "FileNamesDataGridView";
            this.FileNamesDataGridView.ReadOnly = true;
            this.FileNamesDataGridView.RowHeadersVisible = false;
            this.FileNamesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FileNamesDataGridView.Size = new System.Drawing.Size(353, 268);
            this.FileNamesDataGridView.TabIndex = 0;
            this.FileNamesDataGridView.TabStop = false;
            // 
            // FilenameColumn
            // 
            this.FilenameColumn.DataPropertyName = "Filename";
            this.FilenameColumn.HeaderText = "File name";
            this.FilenameColumn.Name = "FilenameColumn";
            this.FilenameColumn.ReadOnly = true;
            this.FilenameColumn.Width = 336;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchPanel.Controls.Add(this.SearchButton);
            this.SearchPanel.Controls.Add(this.SearchTextBox);
            this.SearchPanel.Location = new System.Drawing.Point(12, 43);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(360, 29);
            this.SearchPanel.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(246, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(3, 5);
            this.SearchTextBox.MaxLength = 64;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(237, 20);
            this.SearchTextBox.TabIndex = 0;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.DeleteButton);
            this.ButtonsPanel.Controls.Add(this.UpdateButton);
            this.ButtonsPanel.Controls.Add(this.UploadButton);
            this.ButtonsPanel.Controls.Add(this.DownloadButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 394);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(360, 29);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(246, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(165, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(84, 3);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 23);
            this.UploadButton.TabIndex = 1;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Visible = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(3, 3);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 0;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // UploadFilenamePanel
            // 
            this.UploadFilenamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UploadFilenamePanel.Controls.Add(this.UploadFileNameLabel);
            this.UploadFilenamePanel.Controls.Add(this.filenameTextBox);
            this.UploadFilenamePanel.Location = new System.Drawing.Point(12, 359);
            this.UploadFilenamePanel.Name = "UploadFilenamePanel";
            this.UploadFilenamePanel.Size = new System.Drawing.Size(360, 29);
            this.UploadFilenamePanel.TabIndex = 2;
            this.UploadFilenamePanel.Visible = false;
            // 
            // UploadFileNameLabel
            // 
            this.UploadFileNameLabel.AutoSize = true;
            this.UploadFileNameLabel.Location = new System.Drawing.Point(3, 9);
            this.UploadFileNameLabel.Name = "UploadFileNameLabel";
            this.UploadFileNameLabel.Size = new System.Drawing.Size(89, 13);
            this.UploadFileNameLabel.TabIndex = 1;
            this.UploadFileNameLabel.Text = "Upload file name:";
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTextBox.Location = new System.Drawing.Point(98, 6);
            this.filenameTextBox.MaxLength = 64;
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(223, 20);
            this.filenameTextBox.TabIndex = 0;
            this.filenameTextBox.TextChanged += new System.EventHandler(this.filenameTextBox_TextChanged);
            // 
            // SignOutButton
            // 
            this.SignOutButton.Location = new System.Drawing.Point(84, 3);
            this.SignOutButton.Name = "SignOutButton";
            this.SignOutButton.Size = new System.Drawing.Size(75, 23);
            this.SignOutButton.TabIndex = 1;
            this.SignOutButton.Text = "Sign Out";
            this.SignOutButton.UseVisualStyleBackColor = true;
            this.SignOutButton.Visible = false;
            this.SignOutButton.Click += new System.EventHandler(this.SignOutButton_Click);
            // 
            // ExitPanel
            // 
            this.ExitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitPanel.Controls.Add(this.BackButton);
            this.ExitPanel.Controls.Add(this.SignOutButton);
            this.ExitPanel.Location = new System.Drawing.Point(12, 429);
            this.ExitPanel.Name = "ExitPanel";
            this.ExitPanel.Size = new System.Drawing.Size(360, 29);
            this.ExitPanel.TabIndex = 4;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(3, 3);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // OnlineFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 467);
            this.Controls.Add(this.ExitPanel);
            this.Controls.Add(this.UploadFilenamePanel);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.SearchPanel);
            this.Controls.Add(this.FilenamesPanel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OnlineFilesForm";
            this.Text = "PuzzLearn - Download";
            this.FilenamesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileNamesDataGridView)).EndInit();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.UploadFilenamePanel.ResumeLayout(false);
            this.UploadFilenamePanel.PerformLayout();
            this.ExitPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel FilenamesPanel;
        private System.Windows.Forms.DataGridView FileNamesDataGridView;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Panel UploadFilenamePanel;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Label UploadFileNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilenameColumn;
        private System.Windows.Forms.Button SignOutButton;
        private System.Windows.Forms.Panel ExitPanel;
        private System.Windows.Forms.Button BackButton;
    }
}