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
    public partial class frmTrainers : Form
    {
        public frmTrainers()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            dgvAllTrainers.DataSource = clsTrainer.GetAllTrainers();
            mtxtSearch.Text = string.Empty;

        }
        private void frmTrainers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mtxtSearch.Text == string.Empty)
                return;
            if (clsTrainer.IsTrainerExistByPhoneNumber(mtxtSearch.Text))
            {
                dgvAllTrainers.DataSource = clsTrainer.GetTrainerByPhoneNumber(mtxtSearch.Text);
            }
            else
            {
                _RefreshData();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Trainer [" + dgvAllTrainers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {
                if(clsMemberTrainer.IsTrainerTeachMembers((int)dgvAllTrainers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Error: First Delete The Trainer From MemberTrainer Section and Try Again! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int PersonID = clsTrainer.Find((int)dgvAllTrainers.CurrentRow.Cells[0].Value).PersonID;
                //Perform Delele and refresh
                if (clsTrainer.DeleteTrainer((int)dgvAllTrainers.CurrentRow.Cells[0].Value) && clsTrainer.DeletePerson(PersonID))
                {
                    MessageBox.Show("Trainer Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                    return;
                }

                else
                    MessageBox.Show("Trainer is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnAddNewTranier_Click(object sender, EventArgs e)
        {

        }

        private void addTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTranier frm = new frmAddEditTranier(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void addTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTranier frm = new frmAddEditTranier(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTranier frm = new frmAddEditTranier((int)dgvAllTrainers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshData();
        }

        private void mtxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }
    }
}
