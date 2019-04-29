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
    public partial class XYRegionForm : Form
    {
        private ISharedManager sharedManager;
        private IXYFormManager xyManager;

        public XYRegionForm(ISharedManager sm, IXYFormManager xy, string title, XYRegion xyr = null)
        {
            sharedManager = sm;
            xyManager = xy;

            InitializeComponent();
            Text = title;
            ValueCategoryDataGrid.DataSource = xyManager.UpdateValueCategories();

            if (xyr != null)
            {
                AddressTextBox.Text = xyr.StartAddress.ToString("X");
                DescriptionTextBox.Text = xyr.Description;

                WidthUpDown.Value = xyr.Width;
                HeightUpDown.Value = xyr.Height;
                RowOffsetUpDown.Value = xyr.RowOffset;
                XStartUpDown.Value = xyr.XOffset;
                YStartUpDown.Value = xyr.YOffset;
                DefaultValueUpDown.Value = xyr.DefaultValue;
            }
        }

        private void AddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.HexCharacterCheck(e);
        }

        private void DescriptionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.DescriptionCharacterCheck(e);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (xyManager.Confirm(DescriptionTextBox.Text, AddressTextBox.Text, WidthUpDown.Value,
                HeightUpDown.Value, RowOffsetUpDown.Value, XStartUpDown.Value, YStartUpDown.Value, DefaultValueUpDown.Value))
                Close();
            else
                GameConfigStaticMethods.ShowIncompleteDialog(this);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddOrUpdateButton_Click(object sender, EventArgs e)
        {
            xyManager.AddOrUpdate(ValueUpDown.Value, CategoryUpDown.Value);
            ValueCategoryDataGrid.DataSource = xyManager.UpdateValueCategories();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var row = ValueCategoryDataGrid.SelectedRows;
            if (row.Count == 1)
            {
                xyManager.Delete(((Tuple<int, int>)ValueCategoryDataGrid.SelectedRows[0].DataBoundItem).Item1);
                ValueCategoryDataGrid.DataSource = xyManager.UpdateValueCategories();
            }
        }
    }
}
