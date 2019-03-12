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
    public partial class AddressForm : Form
    {
        private IPuzzLearnManager manager;
        private MemoryAddress editAddress;

        public AddressForm(IPuzzLearnManager plManager, MemoryAddress address = null)
        {
            manager = plManager;
            InitializeComponent();
            if (address != null)
            {
                AddressTextBox.Text = address.Address.ToString("X");
                LabelTextBox.Text = address.Label;
                editAddress = address;
            }
        }

        private void AddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
            if (!manager.ValidAddressCharacter(e.KeyChar))
                e.Handled = true;
        }

        private void LabelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!manager.ValidStringCharacter(e.KeyChar))
                e.Handled = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // TODO: Required fields instead
            if (LabelTextBox.Text == "" || AddressTextBox.Text == "")
            {
                MessageBox.Show(this, "Please enter something for all fields.", "Invalid", MessageBoxButtons.OK);
                return;
            }

            MemoryAddress address = new PlaceholderAddress();
            address.Label = LabelTextBox.Text;
            address.Address = Int32.Parse(AddressTextBox.Text, System.Globalization.NumberStyles.HexNumber);

            if (editAddress != null)
                manager.EditAddress(editAddress, address);
            else
                manager.AddAddress(address);

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
