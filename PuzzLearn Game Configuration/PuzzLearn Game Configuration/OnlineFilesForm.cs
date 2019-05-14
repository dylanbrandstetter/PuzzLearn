using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public partial class OnlineFilesForm : Form
    {
        IOnlineFilesManager onlineFileManager;

        public OnlineFilesForm(IOnlineFilesManager ofm, bool myfiles = false)
        {
            onlineFileManager = ofm;
            InitializeComponent();

            FileNamesDataGridView.AutoGenerateColumns = false;
            FileNamesDataGridView.DataSource = onlineFileManager.GetFileSource();

            if (myfiles)
            {
                Text = "PuzzLearn - My Files";
                TitleLabel.Text = "My Files";
                UploadButton.Visible = true;
                UpdateButton.Visible = true;
                DeleteButton.Visible = true;
                SignOutButton.Visible = true;
                UploadFilenamePanel.Visible = true;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FileNamesDataGridView.DataSource = onlineFileManager.SearchResults(SearchTextBox.Text);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            onlineFileManager.Download(this, FileNamesDataGridView);
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            onlineFileManager.Upload(this, filenameTextBox.Text);
            FileNamesDataGridView.DataSource = onlineFileManager.GetFileSource();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            onlineFileManager.UpdateFile(this, FileNamesDataGridView);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            onlineFileManager.Delete(this, FileNamesDataGridView);
        }

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            onlineFileManager.SignOut(this);
        }

        private void filenameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (filenameTextBox.Text.Length > 64)
                filenameTextBox.Text = filenameTextBox.Text.Substring(0, 64);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
