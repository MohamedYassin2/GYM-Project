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
    public partial class frmAddEditUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _UserID;
        clsUser _User;
        clsUser.enPermission _Permission;
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            if (_UserID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _LoadUserData()
        {
            //if we add new Trainer
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                _User = new clsUser();
                //this refer to form
                this.Text = "Add User";
                return;
            }

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _UserID);
                this.Close();

                return;
            }
            this.Text = "Edit User";
            lblMode.Text = "Edit User ID = " + _UserID;
            lblUserID.Text = _UserID.ToString();
            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            txtPhone1.Text = _User.Phone1;
            txtPhone2.Text = _User.Phone2;
            txtAddress.Text = _User.Address;
            dtpDateOfBirth.Value = _User.DateOfBirth;
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.PassWord;
            txtSalary.Text = _User.Salary.ToString();

            if(_User.Permission == -1)
            {
                chkAll.Checked = true;
                chkMembers.Checked = true;
                chkTrainers.Checked = true;
                chkUsers.Checked = true;
                chkPaymetns.Checked = true;
                chkSubscriptions.Checked = true;
                chkSubscriptionType.Checked = true;
                chkMembersTrainers.Checked = true;
                return;
            }

            if (_User.CheckAccessPermission(clsUser.enPermission.Members))
                chkMembers.Checked = true;

            if (_User.CheckAccessPermission(clsUser.enPermission.Trainers))
                chkTrainers.Checked = true;

            if (_User.CheckAccessPermission(clsUser.enPermission.Users))
                chkUsers.Checked = true;

            if (_User.CheckAccessPermission(clsUser.enPermission.Subscription))
                chkSubscriptions.Checked = true;

            if (_User.CheckAccessPermission(clsUser.enPermission.Payments))
                chkPaymetns.Checked = true;

            if (_User.CheckAccessPermission(clsUser.enPermission.MemberTrainer))
                chkMembersTrainers.Checked = true;

            if (_User.CheckAccessPermission(clsUser.enPermission.SubscriptionType))
                chkSubscriptionType.Checked = true;




        }

        private int AddPerrmission()
        {
            int Perrmission = 0;

            if(chkAll.Checked)
            {
                Perrmission = -1;
                return Perrmission;
            }
            if (chkMembers.Checked)
                Perrmission += (int)clsUser.enPermission.Members;
            if (chkTrainers.Checked)
                Perrmission += (int)clsUser.enPermission.Trainers;
            if (chkUsers.Checked)
                Perrmission += (int)clsUser.enPermission.Users;
            if (chkPaymetns.Checked)
                Perrmission += (int)clsUser.enPermission.Payments;
            if (chkSubscriptions.Checked)
                Perrmission += (int)clsUser.enPermission.Subscription;
            if (chkSubscriptionType.Checked)
                Perrmission += (int)clsUser.enPermission.SubscriptionType;
            if (chkMembersTrainers.Checked)
                Perrmission += (int)clsUser.enPermission.MemberTrainer;

            return Perrmission;

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadUserData();
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone1.Text == "" || txtAddress.Text == "" || txtSalary.Text == "" || txtPassword.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("Please Fill All Fields", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal Salary = Convert.ToDecimal(txtSalary.Text);
            if (Salary <= 0)
            {
                MessageBox.Show("Please Enter Valid Salary", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are Sure To Save The Data?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                _User.Name = txtName.Text;
                _User.Email = txtEmail.Text;
                _User.Phone1 = txtPhone1.Text;
                _User.Phone2 = txtPhone2.Text;
                _User.DateOfBirth = dtpDateOfBirth.Value;
                _User.Address = txtAddress.Text;
                _User.UserName = txtUserName.Text;
                _User.PassWord = txtPassword.Text;
                _User.Salary = Convert.ToDecimal(txtSalary.Text);
                _User.Permission = AddPerrmission();



                if (_User.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblMode.Text = "Edit User ID = " + _User.UserID;
                    lblUserID.Text = _User.UserID.ToString();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                chkMembers.Checked = true;
                chkTrainers.Checked = true;
                chkUsers.Checked = true;
                chkPaymetns.Checked = true;
                chkSubscriptions.Checked = true;
                chkSubscriptionType.Checked = true;
                chkMembersTrainers.Checked = true;
            }
            if(chkAll.Checked == false)
            {
                chkMembers.Checked = false;
                chkTrainers.Checked = false;
                chkUsers.Checked = false;
                chkPaymetns.Checked = false;
                chkSubscriptions.Checked = false;
                chkSubscriptionType.Checked = false;
                chkMembersTrainers.Checked = false;
            }
            
            
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
           
           
        }
    }
}

