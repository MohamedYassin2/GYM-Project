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
    public partial class frmMembersTrainers : Form
    {
        public frmMembersTrainers()
        {
            InitializeComponent();
        }
        clsMemberTrainer EditMemberTrainerRecored;

        private void _RefreshData()
        {
            dgvAllMembersTrainers.DataSource = clsMemberTrainer.GetAllMemberTranierRecords();

            if (EdittxtMemberID.Text == string.Empty || EdittxtTrainerID.Text == string.Empty)
                return;

            try
            {
                EdittxtMemberID.Text = Convert.ToString((int)dgvAllMembersTrainers.CurrentRow.Cells[0].Value);
                EdittxtTrainerID.Text = Convert.ToString((int)dgvAllMembersTrainers.CurrentRow.Cells[1].Value);
                dtpEditAssignDate.Value = (DateTime)dgvAllMembersTrainers.CurrentRow.Cells[2].Value;

            }
            catch
            {
                return;
            }



        }

        private void frmMembersTrainers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void dgvAllMembersTrainers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EdittxtMemberID.Text = Convert.ToString((int)dgvAllMembersTrainers.CurrentRow.Cells[0].Value);
                EdittxtTrainerID.Text = Convert.ToString((int)dgvAllMembersTrainers.CurrentRow.Cells[1].Value);
                dtpEditAssignDate.Value = (DateTime)dgvAllMembersTrainers.CurrentRow.Cells[2].Value;
            }
           catch
            {
                return;
            }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _RefreshData();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete This Record For MemberID [" + dgvAllMembersTrainers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsMemberTrainer.DeleteRecordInMemberTranierTable((int)dgvAllMembersTrainers.CurrentRow.Cells[0].Value, (int)dgvAllMembersTrainers.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("Recored Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("Recored is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(EdittxtMemberID.Text == string.Empty)
            {
                MessageBox.Show("MemberID Filed Is Empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EdittxtTrainerID.Text == string.Empty)
            {
                MessageBox.Show("TrainerID Filed Is Empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsMemberTrainer.IsRecordMemberTranierExist(Convert.ToInt32(EdittxtMemberID.Text), Convert.ToInt32(EdittxtTrainerID.Text)))
            {
                MessageBox.Show("Error: This Record Is Already Exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!clsMember.IsMemberExist(Convert.ToInt32(EdittxtMemberID.Text)))
            {
                MessageBox.Show("Error: There is No Member With ID ["+EdittxtMemberID.Text+"]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsTrainer.IsTrainerExist(Convert.ToInt32(EdittxtTrainerID.Text)))
            {
                MessageBox.Show("Error: There is No Trainer With ID [" + EdittxtTrainerID.Text + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            EditMemberTrainerRecored = clsMemberTrainer.Find((int)dgvAllMembersTrainers.CurrentRow.Cells[0].Value);

            if(EditMemberTrainerRecored != null)
            {
                EditMemberTrainerRecored.MemberID = Convert.ToInt16(EdittxtMemberID.Text);
                EditMemberTrainerRecored.TrainerID = Convert.ToInt16(EdittxtTrainerID.Text);
                EditMemberTrainerRecored.AssignDate = dtpEditAssignDate.Value;

            }
            else
            {
                MessageBox.Show("Error: There is no Record With MemberID ["+ EdittxtMemberID.Text+"] ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (MessageBox.Show("Are You Sure You Want To Update Recoerd With MemberID[" + (int)dgvAllMembersTrainers.CurrentRow.Cells[0].Value + "] ?", "Update!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clsMemberTrainer.DeleteRecordInMemberTranierTable((int)dgvAllMembersTrainers.CurrentRow.Cells[0].Value, (int)dgvAllMembersTrainers.CurrentRow.Cells[1].Value);

                if (EditMemberTrainerRecored.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Saved Failed", "Falied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _RefreshData();




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddtxtMemberID.Text == string.Empty)
            {
                MessageBox.Show("MemberID Filed Is Empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AddtxtTrainerID.Text == string.Empty)
            {
                MessageBox.Show("TrainerID Filed Is Empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsMemberTrainer.IsRecordMemberTranierExist(Convert.ToInt32(AddtxtMemberID.Text), Convert.ToInt32(AddtxtTrainerID.Text)))
            {
                MessageBox.Show("Error: This Record Is Already Exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsMember.IsMemberExist(Convert.ToInt32(AddtxtMemberID.Text)))
            {
                MessageBox.Show("Error: There is No Member With ID [" + AddtxtMemberID.Text + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsTrainer.IsTrainerExist(Convert.ToInt32(AddtxtTrainerID.Text)))
            {
                MessageBox.Show("Error: There is No Trainer With ID [" + AddtxtTrainerID.Text + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EditMemberTrainerRecored = new clsMemberTrainer();

            EditMemberTrainerRecored.MemberID = Convert.ToInt16(AddtxtMemberID.Text);
            EditMemberTrainerRecored.TrainerID = Convert.ToInt16(AddtxtTrainerID.Text);
            EditMemberTrainerRecored.AssignDate = dtpAddAssignDate.Value;

            if (MessageBox.Show("Are You Sure You Want To Add Recoerd With MemberID[" + AddtxtMemberID.Text + "] and With TrainerID ["+AddtxtTrainerID.Text+"] ?", "Add!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                if (EditMemberTrainerRecored.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Saved Failed", "Falied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _RefreshData();

            AddtxtMemberID.Text = string.Empty;
            AddtxtTrainerID.Text = string.Empty;
            dtpAddAssignDate.Value = DateTime.Now;








        }
    }
}
