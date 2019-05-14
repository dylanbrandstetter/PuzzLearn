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
    public partial class IntegerAddressForm : Form
    {
        private IIntFormManager intManager;
        private ISharedManager sharedManager;

        public IntegerAddressForm(IIntFormManager ifm, ISharedManager sm, string title = "Integer Address", IntegerAddress ia = null)
        {
            intManager = ifm;
            sharedManager = sm;

            InitializeComponent();
            Text = title;

            if (ia != null)
            {
                AddressTextBox.Text = ia.Address.ToString("X");
                DescriptionTextBox.Text = ia.Description;
                OffsetUpDown.Value = ia.Offset;
                MultiplicationFactorUpDown.Value = ia.Multiply;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (intManager.Confirm(AddressTextBox.Text, DescriptionTextBox.Text, OffsetUpDown.Value, MultiplicationFactorUpDown.Value))
                Close();
            else
                StaticGameConfig.ShowIncompleteDialog(this);
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
