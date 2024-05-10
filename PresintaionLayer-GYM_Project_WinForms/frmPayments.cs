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
    public partial class frmPayments : Form
    {
        public frmPayments()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            dgvAllPayments.DataSource = clsPayment.GetAllPayments();
            mtxtSearch.Text = string.Empty;

        }
        private void frmPayments_Load(object sender, EventArgs e)
        {
            _RefreshData(); 
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void addTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPayment frm = new frmAddEditPayment(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTranier frm = new frmAddEditTranier((int)dgvAllPayments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshData();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Payment [" + dgvAllPayments.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {
                
                //Perform Delele and refresh
               if(clsSubscriptionPeriod.IsMemberHasSubscription((int)dgvAllPayments.CurrentRow.Cells[3].Value))
                {
                    if (clsSubscriptionPeriod.DeleteSubscriptionPeriodByPaymentID((int)dgvAllPayments.CurrentRow.Cells[0].Value) && clsPayment.DeletePayment((int)dgvAllPayments.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Payment Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshData();
                    }

                    else
                        MessageBox.Show("Payment is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               else
                {
                    if (clsPayment.DeletePayment((int)dgvAllPayments.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Payment Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshData();
                    }

                    else
                        MessageBox.Show("Payment is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mtxtSearch.Text == string.Empty)
                return;
            if (clsMember.IsMemberExistByPhoneNumber(mtxtSearch.Text))
            {
                dgvAllPayments.DataSource = clsPayment.GetPaymentByPhoneNumber(mtxtSearch.Text);
            }
            else
            {
                _RefreshData();
            }
        }

        private void mtxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }
    }
}
