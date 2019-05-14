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
    public partial class MainMenuForm : Form
    {
        IMainMenuFormManager manager;

        public MainMenuForm(IMainMenuFormManager manager)
        {
            this.manager = manager;
            InitializeComponent();

            DatabaseDataGridView.AutoGenerateColumns = false;
            DatabaseDataGridView.DataSource = manager.GetDataSource();

            ScoreAddressDataGridView.AutoGenerateColumns = false;
            ScoreAddressDataGridView.DataSource = manager.GetScoreSource();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void AddPlaneButton_Click(object sender, EventArgs e)
        {
            manager.AddPlane(this);
        }

        private void AddInfoButton_Click(object sender, EventArgs e)
        {
            manager.AddInfo(this);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var dataRow = DatabaseDataGridView.SelectedRows;
            if (dataRow.Count == 1)
            {
                manager.EditStruct((MemStructObject)dataRow[0].DataBoundItem, this);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var dataRow = DatabaseDataGridView.SelectedRows;
            if (dataRow.Count == 1)
            {
                manager.DeleteStruct((MemStructObject)dataRow[0].DataBoundItem);
            }
        }

        private void AddScoreButton_Click(object sender, EventArgs e)
        {
            manager.AddScore(this);
        }

        private void EditScoreButton_Click(object sender, EventArgs e)
        {
            var dataRow = ScoreAddressDataGridView.SelectedRows;
            if (dataRow.Count == 1)
            {
                manager.EditScore((IntegerAddress)dataRow[0].DataBoundItem, this);
            }
        }

        private void DeleteScoreButton_Click(object sender, EventArgs e)
        {
            var dataRow = ScoreAddressDataGridView.SelectedRows;
            if (dataRow.Count == 1)
            {
                manager.DeleteScore((IntegerAddress)dataRow[0].DataBoundItem);
            }
        }

        private void DatabaseSettingsButton_Click(object sender, EventArgs e)
        {
            manager.EditDatabaseSettings(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.New(this);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Open(this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Save(this);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.SaveAs(this);
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!manager.SaveCheck(this))
                e.Cancel = true;
        }

        private void myFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.MyFiles(this);
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Download(this);
        }
    }
}
