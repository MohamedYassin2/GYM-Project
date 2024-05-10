using BusinessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresintaionLayer_GYM_Project_WinForms
{
    public partial class frmAddEditMember : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _MemberID;
        clsMember _Member;
        public frmAddEditMember(int MemberID)
        {
            InitializeComponent();

            _MemberID = MemberID;

            if (_MemberID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        private void _LoadMemberDate()
        {
            //if we add new member
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Member";
                _Member = new clsMember();
                this.Text = "Add Member";
                return;
            }

            _Member = clsMember.Find(_MemberID);

            if (_Member == null)
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _MemberID);
                this.Close();

                return;
            }
            this.Text = "Edit Member";
            lblMode.Text = "Edit Member ID = " + _MemberID;
            lblMemberID.Text = _MemberID.ToString();
            txtName.Text = _Member.Name;
            txtEmail.Text = _Member.Email;
            txtPhone1.Text = _Member.Phone1;
            txtPhone2.Text = _Member.Phone2;
            txtAddress.Text = _Member.Address;
            dtpDateOfBirth.Value = _Member.DateOfBirth;

            if (_Member.IsActive)
                rbYes.Checked = true;
            else
                rbNo.Checked = true;

        }
        private void frmAddEditMember_Load(object sender, EventArgs e)
        {

            _LoadMemberDate();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone1.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Please Fill All Fields","Warrning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("Are Sure To Save The Data?","Confirm!",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                bool _IsActive;
                _Member.Name = txtName.Text;
                _Member.Email = txtEmail.Text;
                _Member.Phone1 = txtPhone1.Text;
                _Member.Phone2 = txtPhone2.Text;
                _Member.DateOfBirth = dtpDateOfBirth.Value;
                _Member.Address = txtAddress.Text;

                _IsActive = rbYes.Checked;

                _Member.IsActive = _IsActive;

                if (_Member.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblMode.Text = "Edit Member ID = " + _Member.MemberID;
                    lblMemberID.Text = _Member.MemberID.ToString();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            

            


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
