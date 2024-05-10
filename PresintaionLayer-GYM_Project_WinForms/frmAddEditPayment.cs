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
    public partial class frmAddEditPayment : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PaymentID;
        clsPayment _Payment;


        public frmAddEditPayment(int PaymentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;



            if (_PaymentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }


        private void _LoadPaymentData()
        {
            //if we add new Payment
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Payment";
                _Payment = new clsPayment();
                this.Text = "Add Payment";
                dtpPaymentDate.Value = DateTime.Now;
                return;
            }
            _Payment = clsPayment.Find(_PaymentID);

            if (_Payment == null)
            {
                MessageBox.Show("This form will be closed because No Payment with ID = " + _PaymentID);
                this.Close();

                return;
            }

            this.Text = "Edit Payment";
            lblMode.Text = "Edit Payment ID = " + _PaymentID;
            txtAmount.Text = _Payment.Amount.ToString();
            dtpPaymentDate.Value = _Payment.PaymentDate;
            txtMemberID.Text = _Payment.MemberID.ToString();
            

        }


        private void frmAddEditPayment_Load(object sender, EventArgs e)
        {
            _LoadPaymentData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Error : Please Eenter Vaild Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt16(txtAmount.Text) <0)
            {
                MessageBox.Show("Error : Please Eenter Vaild Amount","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Compare(dtpPaymentDate.Value,DateTime.Now) > 0)
            {
                MessageBox.Show("Error : Please Eenter Vaild Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!clsMember.IsMemberExist(Convert.ToInt16(txtMemberID.Text))) 
            {
                MessageBox.Show("Error : Member With ID["+txtMemberID.Text+"] is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are Sure To Save The Data?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                _Payment.Amount = Convert.ToInt16(txtAmount.Text);
                _Payment.PaymentDate = dtpPaymentDate.Value;
                _Payment.MemberID = Convert.ToInt16(txtMemberID.Text);

                if(_Payment.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblMode.Text = "Edit Payment ID = " + _Payment.PaymentID;
                    lblPaymentID.Text = _Payment.PaymentID.ToString();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
