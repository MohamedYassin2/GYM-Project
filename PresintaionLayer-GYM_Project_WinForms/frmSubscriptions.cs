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
    public partial class frmSubscriptions : Form
    {
        public frmSubscriptions()
        {
            InitializeComponent();
        }
        clsMember _Member;
        private void _RefreshData()
        {
            dgvAllSubscription.DataSource = clsSubscriptionPeriod.GetSubscriptionPeriods();
            mtxtSearch.Text = string.Empty;
        }
        private void frmSubscriptions_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mtxtSearch.Text == string.Empty)
                return;

            
            _Member = clsMember.FindByPhoneNumber(mtxtSearch.Text);

            if(_Member != null)
            {
                if (clsSubscriptionPeriod.IsMemberHasSubscription(_Member.MemberID))
                {
                    dgvAllSubscription.DataSource = clsSubscriptionPeriod.GetSubscriptionPeriodByMemberID(_Member.MemberID);
                }
                else
                    MessageBox.Show("Error : There is no Subscrption To Member With Phone[" + mtxtSearch.Text + "]","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error : There is no Member With Phone[" + mtxtSearch.Text + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void refresjhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void addSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditSubscription frm = new frmAddEditSubscription(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditSubscription frm = new frmAddEditSubscription((int)dgvAllSubscription.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Subscription [" + dgvAllSubscription.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {
                
                //Perform Delele and refresh
                if (clsSubscriptionPeriod.DeleteSubscriptionPeriod((int)dgvAllSubscription.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Subscription Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("Subscription is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void mtxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }
    }
}
