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
    public partial class InformationAddressForm : Form
    {
        IInfoFormManager infoManager;
        ISharedManager sharedManager;

        public InformationAddressForm(IInfoFormManager im, ISharedManager sm, string title, InformationAddress ia = null)
        {
            infoManager = im;
            sharedManager = sm;

            InitializeComponent();
            Text = title;

            ValueCategoryDataGrid.AutoGenerateColumns = false;
            ValueCategoryDataGrid.DataSource = infoManager.UpdateValueCategories();

            if (ia != null)
            {
                AddressTextBox.Text = ia.Address.ToString("X");
                DescriptionTextBox.Text = ia.Description;
                DefaultValueUpDown.Value = ia.DefaultValue;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (infoManager.Confirm(AddressTextBox.Text, DescriptionTextBox.Text, DefaultValueUpDown.Value))
                Close();
            else
                StaticGameConfig.ShowIncompleteDialog(this);
        }

        private void AddOrUpdateButton_Click(object sender, EventArgs e)
        {
            infoManager.AddOrUpdate((int)ValueUpDown.Value, (int)CategoryUpDown.Value);
            ValueCategoryDataGrid.DataSource = infoManager.UpdateValueCategories();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ValueCategoryDataGrid.SelectedRows.Count == 1)
            {
                infoManager.Delete(((Tuple<int, int>)ValueCategoryDataGrid.SelectedRows[0].DataBoundItem).Item1);
                ValueCategoryDataGrid.DataSource = infoManager.UpdateValueCategories();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.HexPressCheck(e);
        }

        private void DescriptionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.DescriptionPressCheck(e);
        }

        private void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sharedManager.HexDownCheck(sender, e);
        }

        private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sharedManager.DescriptionDownCheck(sender, e);
        }
    }
}
