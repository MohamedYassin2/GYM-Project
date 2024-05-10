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
    public partial class frmSubscriptionTypes : Form
    {
        public frmSubscriptionTypes()
        {
            InitializeComponent();
        }
        clsSubscriptionType _SubscriptionType;
        clsSubscriptionType _SubscriptionType2;
        private void _RefreshData()
        {
            dgvAllSubscriptionTypes.DataSource = clsSubscriptionType.GetAllSubscriptionType();
      
            lblSubscriptiontTypeID.Text =Convert.ToString((int)dgvAllSubscriptionTypes.CurrentRow.Cells[0].Value);
            txtName.Text = (string)dgvAllSubscriptionTypes.CurrentRow.Cells[1].Value;
        }
        private void frmSubscriptionTypes_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void dgvAllSubscriptionTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblSubscriptiontTypeID.Text = Convert.ToString((int)dgvAllSubscriptionTypes.CurrentRow.Cells[0].Value);
                txtName.Text = (string)dgvAllSubscriptionTypes.CurrentRow.Cells[1].Value;
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete SubscriptionType [" + dgvAllSubscriptionTypes.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {
               
                //Perform Delele and refresh
                if (clsSubscriptionType.DeleteSubscriptionType((int)dgvAllSubscriptionTypes.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("SubscriptionType Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("SubscriptionType is not deleted.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNameAdd.Text == string.Empty)
            {
                MessageBox.Show("Name Filed Is Empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(clsSubscriptionType.IsSubscriptionTypeExistByName(txtNameAdd.Text))
            {
                MessageBox.Show("Name Is Aready Exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SubscriptionType2 = new clsSubscriptionType();

            _SubscriptionType2.Name = txtNameAdd.Text;

            if (MessageBox.Show("Are You Sure You Want To Add SubscriptionType With Name [" + txtNameAdd.Text + "]?", "Update!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (_SubscriptionType2.Save())
                {
                    MessageBox.Show("Data Added Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblIDAdd.Text = _SubscriptionType2.SubscriptionTypeID.ToString();

                }
                else
                {
                    MessageBox.Show("Data Add Failed", "Falied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _RefreshData();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name Filed Is Empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsSubscriptionType.IsSubscriptionTypeExistByName(txtName.Text))
            {
                MessageBox.Show("Name Is Aready Exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SubscriptionType = clsSubscriptionType.Find((int)dgvAllSubscriptionTypes.CurrentRow.Cells[0].Value);

            _SubscriptionType.Name = txtName.Text;

            if (MessageBox.Show("Are You Sure You Want To Update ID[" + (int)dgvAllSubscriptionTypes.CurrentRow.Cells[0].Value + "] Data?", "Update!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (_SubscriptionType.Save())
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
    }
}
