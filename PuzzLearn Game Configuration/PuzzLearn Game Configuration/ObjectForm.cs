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
    public partial class ObjectForm : Form
    {
        private ISharedManager sharedManager;
        private IObjectFormManager objectManager;

        public ObjectForm(ISharedManager sm, IObjectFormManager ofm, string title, ObjectBlock o = null)
        {
            sharedManager = sm;
            objectManager = ofm;

            InitializeComponent();
            Text = title;
            XAddressesGridView.AutoGenerateColumns = false;
            YAddressesGridView.AutoGenerateColumns = false;

            XAddressesGridView.DataSource = objectManager.GetXAddresses();
            YAddressesGridView.DataSource = objectManager.GetYAddresses();
            InformationAddressTextBox.Text = objectManager.GetInfoString();

            if (o != null)
            {
                DescriptionTextBox.Text = o.Description;
                FixedValueUpDown.Value = o.FixedValue;
            }
        }

        private void AddXButton_Click(object sender, EventArgs e)
        {
            objectManager.AddX(this);
        }

        private void EditXButton_Click(object sender, EventArgs e)
        {
            var row = XAddressesGridView.SelectedRows;
            if (row.Count == 1)
                objectManager.EditX(row[0].DataBoundItem, this);
        }

        private void DeleteXButton_Click(object sender, EventArgs e)
        {
            var row = XAddressesGridView.SelectedRows;
            if (row.Count == 1)
                objectManager.DeleteX(row[0].DataBoundItem);
        }

        private void AddYButton_Click(object sender, EventArgs e)
        {
            objectManager.AddY(this);
        }

        private void EditYButton_Click(object sender, EventArgs e)
        {
            var row = YAddressesGridView.SelectedRows;
            if (row.Count == 1)
                objectManager.EditY(row[0].DataBoundItem, this);
        }

        private void DeleteYButton_Click(object sender, EventArgs e)
        {
            var row = YAddressesGridView.SelectedRows;
            if (row.Count == 1)
                objectManager.DeleteY(row[0].DataBoundItem);
        }

        private void AddEditAddressButton_Click(object sender, EventArgs e)
        {
            objectManager.AddEditInfo(this);
            InformationAddressTextBox.Text = objectManager.GetInfoString();
        }

        private void DeleteAddressButton_Click(object sender, EventArgs e)
        {
            objectManager.DeleteInfo();
            InformationAddressTextBox.Text = objectManager.GetInfoString();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (objectManager.Confirm(FixedValueUpDown.Value, DescriptionTextBox.Text))
                Close();
            else
                StaticGameConfig.ShowIncompleteDialog(this);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DescriptionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.DescriptionPressCheck(e);
        }

        private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sharedManager.DescriptionDownCheck(sender, e);
        }
    }
}
