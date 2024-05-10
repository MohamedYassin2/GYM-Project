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
using System.Xml.Linq;

namespace PresintaionLayer_GYM_Project_WinForms
{
    public partial class frmAddEditSubscription : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PeriodID;
        clsSubscriptionPeriod _Subscription;
        public frmAddEditSubscription(int PeriodID)
        {
            InitializeComponent();
            _PeriodID = PeriodID;

            if (_PeriodID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }

        private void FillComboboxWithSubscriptionType()
        {
            DataTable dt =clsSubscriptionType.GetAllSubscriptionType();

            foreach (DataRow dr in dt.Rows) 
            {
                cbSubscriptionType.Items.Add(dr[1].ToString());
            }
        }

        private void _LoadSubscriptionData()
        {
            FillComboboxWithSubscriptionType();
            cbSubscriptionType.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Subscription";
                _Subscription = new clsSubscriptionPeriod();
                this.Text = "Add Subscription";
                return;
            }
            _Subscription = clsSubscriptionPeriod.Find(_PeriodID);

            if (_Subscription == null)
            {
                MessageBox.Show("This form will be closed because No Subscription with ID = " + _PeriodID);
                this.Close();

                return;
            }
            this.Text = "Edit Subscription";
            lblMode.Text = "Edit Subscription ID = " + _PeriodID;
            lblPeriodID.Text = _PeriodID.ToString();
            dtpStartDate.Value = _Subscription.StartDate;
            dtpEndDate.Value = _Subscription.EndDate;
            txtFees.Text =_Subscription.Fees.ToString();
            txtMemberID.Text = _Subscription.MemberID.ToString();
            txtPaymentID.Text = _Subscription.PaymentID.ToString();
            cbSubscriptionType.SelectedIndex = cbSubscriptionType.FindString(clsSubscriptionType.Find(_Subscription.SubscriptionTypeID).Name);

        }

        private void frmAddEditSubscription_Load(object sender, EventArgs e)
        {
            _LoadSubscriptionData();
        }

     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //check if START DATE AFTER END DATE
            if (DateTime.Compare(dtpStartDate.Value, dtpEndDate.Value) > 0 )
            {
                MessageBox.Show("Error: Start Date is After End Date", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if START DATE EQUALS END DATE
            if (DateTime.Compare(dtpStartDate.Value, dtpEndDate.Value) == 0)
            {
                MessageBox.Show("Error: Start Date is Same as End Date", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(txtFees.Text) <= 0)
            {
                MessageBox.Show("Error: Please Enter Valid Fees", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!clsMember.IsMemberExist(Convert.ToInt32(txtMemberID.Text)))
            {
                MessageBox.Show("Error: Member with ID " + txtMemberID.Text + " is not Found", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!clsPayment.IsPaymentExist(Convert.ToInt32(txtPaymentID.Text)))
            {
                MessageBox.Show("Error: Payment with ID " + txtPaymentID.Text + " is not Found", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            int SubscriptionTypeID = clsSubscriptionType.Find(cbSubscriptionType.Text).SubscriptionTypeID;

            _Subscription.StartDate = dtpStartDate.Value;
            _Subscription.EndDate = dtpEndDate.Value;
            _Subscription.Fees = Convert.ToInt32(txtFees.Text);
            _Subscription.MemberID = Convert.ToInt32(txtMemberID.Text);
            _Subscription.PaymentID = Convert.ToInt32(txtPaymentID.Text);
            _Subscription.SubscriptionTypeID = SubscriptionTypeID;

            if(MessageBox.Show("Are You Sure You Want To Save Data?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) ==DialogResult.OK)
            {
                if (_Subscription.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblMode.Text = "Edit Subscription ID = " + _Subscription.PeriodID;
                    lblPeriodID.Text = _Subscription.PeriodID.ToString();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
           
        }

        private void cbSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbSubscriptionType.SelectedIndex == 0)
            //    txtFees.Text = "500";
            //if (cbSubscriptionType.SelectedText == "2 Month")
            //    txtFees.Text = "1000";
            //if (cbSubscriptionType.SelectedText == "3 Month")
            //    txtFees.Text = "1500";
            //if (cbSubscriptionType.SelectedText == "6 Month")
            //    txtFees.Text = "3000";
            //if (cbSubscriptionType.SelectedText == "1 Year")
            //    txtFees.Text = "6000";
            //if (cbSubscriptionType.SelectedText == "2 Year")
            //    txtFees.Text = "12000";
            //if (cbSubscriptionType.SelectedText == "3 Year")
            //    txtFees.Text = "24000";



        }
    }
}
