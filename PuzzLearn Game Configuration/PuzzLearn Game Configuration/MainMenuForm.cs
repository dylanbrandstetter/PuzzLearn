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
        private IPuzzLearnManager manager;

        public MainMenuForm()
        {
            manager = new PuzzLearnManager();
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            AddressDataGridView.DataSource = manager.GetAddressListSource();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddressForm AddForm = new AddressForm(manager);
            AddForm.Text = "Add Address";

            AddForm.ShowDialog();

            LoadDataGrid();
            AddressDataGridView.Refresh();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (AddressDataGridView.SelectedRows.Count > 0)
            {
                MemoryAddress addr = (MemoryAddress)(AddressDataGridView.SelectedRows[0].DataBoundItem);
                AddressForm EditForm = new AddressForm(manager, addr);
                EditForm.Text = "Edit Address";

                EditForm.ShowDialog();

                LoadDataGrid();
                AddressDataGridView.Refresh();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (AddressDataGridView.SelectedRows.Count > 0)
            {
                MemoryAddress addr = (MemoryAddress)(AddressDataGridView.SelectedRows[0].DataBoundItem);
                manager.DeleteAddress(addr);

                LoadDataGrid();
                AddressDataGridView.Refresh();
            }
        }

        private void AddressDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddressDataGridView.Rows[e.RowIndex].Selected = true;
        }
    }
}
