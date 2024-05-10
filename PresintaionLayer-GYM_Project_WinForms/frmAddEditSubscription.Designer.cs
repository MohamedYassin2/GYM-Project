namespace PresintaionLayer_GYM_Project_WinForms
{
    partial class frmAddEditSubscription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditSubscription));
            this.s = new System.Windows.Forms.Label();
            this.txtPaymentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPeriodID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.cbSubscriptionType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Font = new System.Drawing.Font("Tahoma", 12F);
            this.s.Location = new System.Drawing.Point(33, 360);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(131, 19);
            this.s.TabIndex = 91;
            this.s.Text = "SubscriptionType";
            // 
            // txtPaymentID
            // 
            this.txtPaymentID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPaymentID.Location = new System.Drawing.Point(173, 307);
            this.txtPaymentID.MaxLength = 20;
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.Size = new System.Drawing.Size(204, 27);
            this.txtPaymentID.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(33, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 88;
            this.label2.Text = "PaymentID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label7.Location = new System.Drawing.Point(38, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 19);
            this.label7.TabIndex = 86;
            this.label7.Text = "MemberID";
            // 
            // lblPeriodID
            // 
            this.lblPeriodID.AutoSize = true;
            this.lblPeriodID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPeriodID.Location = new System.Drawing.Point(168, 84);
            this.lblPeriodID.Name = "lblPeriodID";
            this.lblPeriodID.Size = new System.Drawing.Size(33, 19);
            this.lblPeriodID.TabIndex = 85;
            this.lblPeriodID.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label8.Location = new System.Drawing.Point(33, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 19);
            this.label8.TabIndex = 84;
            this.label8.Text = "SubscriptionID";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(150, 9);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(252, 29);
            this.lblMode.TabIndex = 83;
            this.lblMode.Text = "Add New Subscription";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Location = new System.Drawing.Point(140, 407);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 43);
            this.btnClose.TabIndex = 82;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.Location = new System.Drawing.Point(303, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 43);
            this.btnSave.TabIndex = 81;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd.mm.yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(173, 119);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(206, 27);
            this.dtpStartDate.TabIndex = 79;
            this.dtpStartDate.Value = new System.DateTime(2023, 9, 3, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(38, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 19);
            this.label3.TabIndex = 74;
            this.label3.Text = "Fees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(33, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 73;
            this.label4.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(33, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 71;
            this.label1.Text = "Start Date";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMemberID.Location = new System.Drawing.Point(172, 260);
            this.txtMemberID.MaxLength = 20;
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(204, 27);
            this.txtMemberID.TabIndex = 87;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd.mm.yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(173, 166);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(206, 27);
            this.dtpEndDate.TabIndex = 92;
            this.dtpEndDate.Value = new System.DateTime(2023, 9, 3, 0, 0, 0, 0);
            // 
            // txtFees
            // 
            this.txtFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFees.Location = new System.Drawing.Point(172, 213);
            this.txtFees.MaxLength = 20;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(204, 27);
            this.txtFees.TabIndex = 93;
            // 
            // cbSubscriptionType
            // 
            this.cbSubscriptionType.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbSubscriptionType.FormattingEnabled = true;
            this.cbSubscriptionType.Location = new System.Drawing.Point(172, 354);
            this.cbSubscriptionType.Name = "cbSubscriptionType";
            this.cbSubscriptionType.Size = new System.Drawing.Size(207, 27);
            this.cbSubscriptionType.TabIndex = 94;
            this.cbSubscriptionType.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionType_SelectedIndexChanged);
            // 
            // frmAddEditSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(572, 479);
            this.Controls.Add(this.cbSubscriptionType);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.s);
            this.Controls.Add(this.txtPaymentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPeriodID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditSubscription";
            this.Text = "frmAddEditSubscription";
            this.Load += new System.EventHandler(this.frmAddEditSubscription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label s;
        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPeriodID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.ComboBox cbSubscriptionType;
    }
}