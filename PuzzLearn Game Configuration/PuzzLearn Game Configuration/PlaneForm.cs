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
    public partial class PlaneForm : Form
    {
        private ISharedManager sharedManager;
        private IPlaneFormManager planeFormManager;

        public PlaneForm(ISharedManager sm, IPlaneFormManager pfm, string title, AddressPlane sourcePlane = null)
        {
            sharedManager = sm;
            planeFormManager = pfm;

            InitializeComponent();
            Text = title;

            if (sourcePlane != null)
            {
                XMinUpDown.Value = sourcePlane.XMin;
                XMaxUpDown.Value = sourcePlane.XMax;
                YMinUpDown.Value = sourcePlane.YMin;
                YMaxUpDown.Value = sourcePlane.YMax;
                DefaultValueUpDown.Value = sourcePlane.DefaultValue;
                DescriptionTextBox.Text = sourcePlane.Description;
            }

            StructuresGridView.AutoGenerateColumns = false;
            XAddressesGridView.AutoGenerateColumns = false;
            YAddressesGridView.AutoGenerateColumns = false;


            StructuresGridView.DataSource = planeFormManager.GetStructureSource();
            XAddressesGridView.DataSource = planeFormManager.GetXAddressSource();
            YAddressesGridView.DataSource = planeFormManager.GetYAddressSource();
        }

        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            planeFormManager.AddObject(this);
        }

        private void AddRegionButton_Click(object sender, EventArgs e)
        {
            planeFormManager.AddRegion(this);
        }

        private void AddXYRegionButton_Click(object sender, EventArgs e)
        {
            planeFormManager.AddXYRegion(this);
        }

        private void EditObjectButton_Click(object sender, EventArgs e)
        {
            var row = StructuresGridView.SelectedRows;
            if (row.Count >= 1)
            {
                planeFormManager.EditStruct((MemStructObject)row[0].DataBoundItem, this);
            }
        }

        private void DeleteObjectButton_Click(object sender, EventArgs e)
        {
            var row = StructuresGridView.SelectedRows;
            if (row.Count >= 1)
            {
                planeFormManager.DeleteStruct((MemStructObject)row[0].DataBoundItem);
            }
        }

        private void AddXButton_Click(object sender, EventArgs e)
        {
            planeFormManager.AddX(this);
        }

        private void EditXButton_Click(object sender, EventArgs e)
        {
            var row = XAddressesGridView.SelectedRows;
            if (row.Count >= 1)
            {
                planeFormManager.EditX((IntegerAddress)row[0].DataBoundItem, this);
            }
        }

        private void DeleteXButton_Click(object sender, EventArgs e)
        {
            var row = XAddressesGridView.SelectedRows;
            if (row.Count >= 1)
            {
                planeFormManager.DeleteX((IntegerAddress)row[0].DataBoundItem);
            }
        }

        private void AddYButton_Click(object sender, EventArgs e)
        {
            planeFormManager.AddY(this);
        }

        private void EditYButton_Click(object sender, EventArgs e)
        {
            var row = YAddressesGridView.SelectedRows;
            if (row.Count >= 1)
            {
                planeFormManager.EditY((IntegerAddress)row[0].DataBoundItem, this);
            }
        }

        private void DeleteYButton_Click(object sender, EventArgs e)
        {
            var row = YAddressesGridView.SelectedRows;
            if (row.Count >= 1)
            {
                planeFormManager.DeleteY((IntegerAddress)row[0].DataBoundItem);
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (planeFormManager.Confirm(XMinUpDown.Value, XMaxUpDown.Value, YMinUpDown.Value, YMaxUpDown.Value, DefaultValueUpDown.Value, DescriptionTextBox.Text))
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

        private void XMinUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void XMaxUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void YMinUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void YMaxUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sharedManager.DescriptionDownCheck(sender, e);
        }
    }
}
