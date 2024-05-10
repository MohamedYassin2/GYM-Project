using BusinessLayer_GYM_Project;
using BusinessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresintaionLayer_GYM_Project_WinForms
{
    public partial class frmMembers : Form
    {
        public frmMembers()
        {
            InitializeComponent();
        }
       
        private void _RefreshData()
        {
            dgvAllMembers.DataSource = clsMember.GetAllMembers();
            mtxtSearch.Text = string.Empty;
            cbFilter.SelectedIndex = 0;

        }
        private void frmMembers_Load(object sender, EventArgs e)
        {
            _RefreshData();
            
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mtxtSearch.Text == string.Empty)
                return;
            if(clsMember.IsMemberExistByPhoneNumber(mtxtSearch.Text))
            {
                dgvAllMembers.DataSource = clsMember.GetMemberByPhoneNumber(mtxtSearch.Text);
            }
            else
            {
                _RefreshData();
            }


        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddEditMember frm = new frmAddEditMember(-1);
            frm.ShowDialog();

            _RefreshData();
        }

      
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Member [" + dgvAllMembers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)

            {
                if(clsSubscriptionPeriod.IsMemberHasSubscription((int)dgvAllMembers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Error : There is Subscription Period Related To This Member .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clsPayment.IsMemberHasPayment((int)dgvAllMembers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Error : There is Payment Related To This Member .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(clsMemberTrainer.IsMemberHasTrainers((int)dgvAllMembers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Error :First Please Delete Member In MemberTrainers .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int PersonID=clsMember.Find((int)dgvAllMembers.CurrentRow.Cells[0].Value).PersonID;
                //Perform Delele and refresh
                if (clsMember.DeleteMember((int)dgvAllMembers.CurrentRow.Cells[0].Value) && clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Member Deleted Successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("Error: Member is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMember frm = new frmAddEditMember((int)dgvAllMembers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshData();
                
         }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _RefreshData();

        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMember frm = new frmAddEditMember(-1);
            frm.ShowDialog();

            _RefreshData();
        }

        private void mtxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void mtxtSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dgvAllMembers.DataSource = clsMember.GetAllMembers();
                return;
            }
                
            if(cbFilter.Text == "Member ID")
            {
                
                dgvAllMembers.DataSource = clsMember.SearchByMemberID(Convert.ToInt32(txtSearch.Text));
            }

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
                txtSearch.Visible = false;
            else
                txtSearch.Visible = true;

        }
    }
}
