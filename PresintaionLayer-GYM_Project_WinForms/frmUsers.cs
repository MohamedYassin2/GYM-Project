using BusinessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresintaionLayer_GYM_Project_WinForms
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            dgvAllUsers.DataSource = clsUser.GetAllUsers();
            mtxtSearch.Text = string.Empty;
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mtxtSearch.Text == string.Empty)
                return;
            if (clsUser.IsPersonExistByPhoneNumber(mtxtSearch.Text))
            {
                dgvAllUsers.DataSource = clsUser.GetUserByPhoneNumber(mtxtSearch.Text);
            }
            else
            {
                _RefreshData();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {
                int PersonID = clsUser.Find((int)dgvAllUsers.CurrentRow.Cells[0].Value).PersonID;
                //Perform Delele and refresh
                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value) && clsTrainer.DeletePerson(PersonID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("User is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _RefreshData();

        }

        private void addTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void addTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void mtxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }
    }
}
