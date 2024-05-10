using BusinessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresintaionLayer_GYM_Project_WinForms
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void _MakeControlsBackGroundTransparent()
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;


            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;


            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;


            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;


            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;

            label9.Parent = pictureBox1;
            label9.BackColor = Color.Transparent;

            label10.Parent = pictureBox1;
            label10.BackColor = Color.Transparent;

            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;

            pictureBox4.Parent = pictureBox1;
            pictureBox4.BackColor = Color.Transparent;


            pictureBox5.Parent = pictureBox1;
            pictureBox5.BackColor = Color.Transparent;


            pictureBox6.Parent = pictureBox1;
            pictureBox6.BackColor = Color.Transparent;

            pictureBox7.Parent = pictureBox1;
            pictureBox7.BackColor = Color.Transparent;

            pictureBox8.Parent = pictureBox1;
            pictureBox8.BackColor = Color.Transparent;

        }

        private void HideAllControls()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;

            btnMembers.Visible = false;
            btnTrainers.Visible = false;
            btnUsers.Visible = false;
            btnSubscription.Visible = false;
            btnSubscriptionTypes.Visible = false;
            btnPayments.Visible = false;
            btnMembersTrainers.Visible = false;

            btnLogout.Visible= false;


        }

        private void EnableAllControls()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;

            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;

            btnMembers.Visible = true;
            btnTrainers.Visible = true;
            btnUsers.Visible = true;
            btnSubscription.Visible = true;
            btnSubscriptionTypes.Visible = true;
            btnPayments.Visible = true;
            btnMembersTrainers.Visible = true;

            btnLogout.Visible = true;


        }

        private void DisableLoginControls()
        {
            label9.Visible = false;
            label10.Visible = false;
            txtUserName.Visible = false;
            txtPassword.Visible = false;
            btnLogin.Visible = false;
        }

        private void EnableLoginControls()
        {
            label9.Visible = true;
            label10.Visible = true;
            txtUserName.Visible = true;
            txtPassword.Visible = true;
            btnLogin.Visible = true;
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            _MakeControlsBackGroundTransparent();
            HideAllControls();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if(!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.Members))
            {
                MessageBox.Show("Access Denied Contact Your Admin","Warrning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
                frmMembers frm = new frmMembers();
                frm.ShowDialog();
        }

        private void btnTrainers_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.Trainers))
            {
                MessageBox.Show("Access Denied Contact Your Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTrainers frm = new frmTrainers();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.Users))
            {
                MessageBox.Show("Access Denied Contact Your Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmUsers frm = new frmUsers();
            frm.ShowDialog();

        }

       

        private void btnSubscriptionTypes_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.SubscriptionType))
            {
                MessageBox.Show("Access Denied Contact Your Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmSubscriptionTypes frm = new frmSubscriptionTypes();
            frm.ShowDialog();
        }

        private void btnSubscription_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.Subscription))
            {
                MessageBox.Show("Access Denied Contact Your Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmSubscriptions frm = new frmSubscriptions();
            frm.ShowDialog();


        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.Payments))
            {
                MessageBox.Show("Access Denied Contact Your Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmPayments frm = new frmPayments();
            frm.ShowDialog();
        }

        private void btnMembersTrainers_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUser.CurrentUser.CheckAccessPermission(clsUser.enPermission.MemberTrainer))
            {
                MessageBox.Show("Access Denied Contact Your Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmMembersTrainers frm = new frmMembersTrainers();
            frm.ShowDialog();   
        }




        private short NumberOfAttemps = 3;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show($"Please Fill All Fileds", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if user rich Number Of Attemps
            if (NumberOfAttemps == 1)
            {
                MessageBox.Show($"Your Account Is Closed Contact Admin", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLogin.Enabled = false;
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
                return;
            }

            clsGlobalUser.CurrentUser = clsUser.Find(txtUserName.Text, txtPassword.Text);

             if (clsGlobalUser.CurrentUser != null)
             {
                 EnableAllControls();
                 DisableLoginControls();
                txtPassword.Text = "";
                txtUserName.Text = "";

            }
            else
             {
                NumberOfAttemps--;
                 MessageBox.Show($"Login Falid {NumberOfAttemps} Tries Left","Warrning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
             }


        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Logout","LogOut",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                HideAllControls();
                EnableLoginControls();
                //reset Number Of Attemps
                NumberOfAttemps = 3;
            }
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
}
