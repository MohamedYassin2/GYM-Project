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
    public partial class frmAddEditTranier : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _TrainerID;
        clsTrainer _Trainer;
        public frmAddEditTranier(int TrainerID)
        {
            InitializeComponent();

            _TrainerID = TrainerID;

            if (_TrainerID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }
        private void _LoadTrainerData()
        {
            //if we add new Trainer
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Trainer";
                _Trainer = new clsTrainer();
                this.Text = "Add Trainer";
                return;
            }

            _Trainer = clsTrainer.Find(_TrainerID);

            if (_Trainer == null)
            {
                MessageBox.Show("This form will be closed because No Trainer with ID = " + _TrainerID);
                this.Close();

                return;
            }
            this.Text = "Edit Trainer";
            lblMode.Text = "Edit Trainer ID = " + _TrainerID;
            lblTrainerID.Text = _TrainerID.ToString();
            txtName.Text = _Trainer.Name;
            txtEmail.Text = _Trainer.Email;
            txtPhone1.Text = _Trainer.Phone1;
            txtPhone2.Text = _Trainer.Phone2;
            txtAddress.Text = _Trainer.Address;
            dtpDateOfBirth.Value = _Trainer.DateOfBirth;
            txtQualification.Text = _Trainer.Qualification;
            txtSalary.Text = _Trainer.Salary.ToString();

           

        }
        private void frmAddEditTranier_Load(object sender, EventArgs e)
        {
            _LoadTrainerData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone1.Text == "" || txtAddress.Text == "" || txtSalary.Text == "" || txtQualification.Text == "")
            {
                MessageBox.Show("Please Fill All Fields", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal Salary=Convert.ToDecimal(txtSalary.Text);
            if (Salary <= 0)
            {
                MessageBox.Show("Please Enter Valid Salary", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are Sure To Save The Data?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                
                _Trainer.Name = txtName.Text;
                _Trainer.Email = txtEmail.Text;
                _Trainer.Phone1 = txtPhone1.Text;
                _Trainer.Phone2 = txtPhone2.Text;
                _Trainer.DateOfBirth = dtpDateOfBirth.Value;
                _Trainer.Address = txtAddress.Text;
                _Trainer.Qualification = txtQualification.Text;
                _Trainer.Salary = Convert.ToDecimal( txtSalary.Text);


                if (_Trainer.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblMode.Text = "Edit Trainer ID = " + _Trainer.TrainerID;
                    lblTrainerID.Text = _Trainer.TrainerID.ToString();
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
