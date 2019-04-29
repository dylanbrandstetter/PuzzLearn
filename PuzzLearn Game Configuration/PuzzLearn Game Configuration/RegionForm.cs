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
    public partial class RegionForm : Form
    {
        private ISharedManager sharedManager;
        private IRegionFormManager rManager;

        public RegionForm(ISharedManager sm, IRegionFormManager rm, string title, AddressRegion r = null)
        {
            sharedManager = sm;
            rManager = rm;

            InitializeComponent();
            Text = title;
            StructuresGridView.AutoGenerateColumns = false;
            StructuresGridView.DataSource = rManager.GetDataSource();

            if (r != null)
            {
                DescriptionTextBox.Text = r.Description;
                StartAddressTextBox.Text = r.StartAddress.ToString("X");
                EndAddressTextBox.Text = r.EndAddress.ToString("X");
                AddressIncrementUpDown.Value = r.Increment;
            }
        }

        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            rManager.AddObject(this);
        }

        private void AddRegionButton_Click(object sender, EventArgs e)
        {
            rManager.AddRegion(this);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var row = StructuresGridView.SelectedRows;
            if (row.Count == 1)
            {
                rManager.Edit(row[0].DataBoundItem, this);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var row = StructuresGridView.SelectedRows;
            if (row.Count == 1)
            {
                rManager.Delete(row[0].DataBoundItem);
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (rManager.Confirm(StartAddressTextBox.Text, EndAddressTextBox.Text,
                DescriptionTextBox.Text, AddressIncrementUpDown.Value))
                Close();
            else
                GameConfigStaticMethods.ShowIncompleteDialog(this);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DescriptionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.DescriptionCharacterCheck(e);
        }

        private void StartAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.HexCharacterCheck(e);
        }

        private void EndAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.HexCharacterCheck(e);
        }

        private void StartAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void EndAddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
