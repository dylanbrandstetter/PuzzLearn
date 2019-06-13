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
    public partial class DatabaseSettingsForm : Form
    {
        private ISharedManager sharedManager;
        private IDatabaseSettingsFormManager settingsManager;

        public DatabaseSettingsForm(ISharedManager sm, IDatabaseSettingsFormManager setm, DatabaseSettings ds)
        {
            InitializeComponent();

            sharedManager = sm;
            settingsManager = setm;

            EndAddressTextBox.Text = ds.EndAddress.ToString("X");
            EndValueUpDown.Value = ds.EndValue;
            PopulationUpDown.Value = ds.Population;
            StagnantGenerationUpDown.Value = ds.StagnantGeneration;
            TimeoutUpDown.Value = ds.Timeout;
            StagnantTimeoutUpDown.Value = ds.StagnantTimeout;
            ReleaseCheckBox.Checked = ds.ReleaseButtons;

            CategoryColorGridView.AutoGenerateColumns = false;
            CategoryColorGridView.DataSource = settingsManager.GetCategoryColors();

            ButtonsDataGridView.AutoGenerateColumns = false;
            ButtonsDataGridView.DataSource = settingsManager.UpdateButtons();

            var validButtons = settingsManager.GetValidButtons();
            foreach (var s in validButtons)
                ButtonNamesComboBox.Items.Add(s);
        }

        private void EditColorButton_Click(object sender, EventArgs e)
        {
            var row = CategoryColorGridView.SelectedRows;
            if (row.Count == 1)
                settingsManager.EditColor(row[0].DataBoundItem, this);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (settingsManager.Confirm(EndAddressTextBox.Text, EndValueUpDown.Value, PopulationUpDown.Value,
                StagnantGenerationUpDown.Value,TimeoutUpDown.Value, StagnantTimeoutUpDown.Value,
                ReleaseCheckBox.Checked))
                Close();
            else
                StaticGameConfig.ShowIncompleteDialog(this);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EndAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.HexPressCheck(e);
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            settingsManager.AddCategory();
        }

        private void ButtonNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.DescriptionPressCheck(e);
        }

        private void AddButtonButton_Click(object sender, EventArgs e)
        {
            if (ButtonNamesComboBox.Text != "")
            {
                settingsManager.AddButton(ButtonNamesComboBox.Text);
                ButtonsDataGridView.DataSource = settingsManager.UpdateButtons();
            }
        }

        private void DeleteButtonButton_Click(object sender, EventArgs e)
        {
            var row = ButtonsDataGridView.SelectedRows;
            if (row.Count == 1)
            {
                settingsManager.RemoveButton(row[0].DataBoundItem);
                ButtonsDataGridView.DataSource = settingsManager.UpdateButtons();
            }
        }

        private void EndAddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sharedManager.HexDownCheck(sender, e);
        }
    }
}
