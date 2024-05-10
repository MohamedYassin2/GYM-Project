namespace PresintaionLayer_GYM_Project_WinForms
{
    partial class frmSubscriptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubscriptions));
            this.dgvAllSubscription = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtSearch = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refresjhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSubscription)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllSubscription
            // 
            this.dgvAllSubscription.AllowUserToAddRows = false;
            this.dgvAllSubscription.AllowUserToDeleteRows = false;
            this.dgvAllSubscription.AllowUserToOrderColumns = true;
            this.dgvAllSubscription.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllSubscription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSubscription.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvAllSubscription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAllSubscription.Location = new System.Drawing.Point(0, 187);
            this.dgvAllSubscription.Name = "dgvAllSubscription";
            this.dgvAllSubscription.ReadOnly = true;
            this.dgvAllSubscription.Size = new System.Drawing.Size(800, 263);
            this.dgvAllSubscription.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.addSubscriptionToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(193, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Edit;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem1.Text = "Edit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Final_Delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addSubscriptionToolStripMenuItem
            // 
            this.addSubscriptionToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Subscriptions;
            this.addSubscriptionToolStripMenuItem.Name = "addSubscriptionToolStripMenuItem";
            this.addSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.addSubscriptionToolStripMenuItem.Text = "Add New Subscription";
            this.addSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.addSubscriptionToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 42);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter Member Phone:";
            // 
            // mtxtSearch
            // 
            this.mtxtSearch.Font = new System.Drawing.Font("Tahoma", 20F);
            this.mtxtSearch.Location = new System.Drawing.Point(327, 12);
            this.mtxtSearch.Mask = "00000000000";
            this.mtxtSearch.Name = "mtxtSearch";
            this.mtxtSearch.Size = new System.Drawing.Size(171, 40);
            this.mtxtSearch.TabIndex = 8;
            this.mtxtSearch.ValidatingType = typeof(int);
            this.mtxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtSearch_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refresjhToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            // 
            // refresjhToolStripMenuItem
            // 
            this.refresjhToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Refresh;
            this.refresjhToolStripMenuItem.Name = "refresjhToolStripMenuItem";
            this.refresjhToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refresjhToolStripMenuItem.Text = "Refresh";
            this.refresjhToolStripMenuItem.Click += new System.EventHandler(this.refresjhToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(493, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 38);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label7.Location = new System.Drawing.Point(12, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 33);
            this.label7.TabIndex = 10;
            this.label7.Text = "Subscriptions:";
            // 
            // frmSubscriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAllSubscription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubscriptions";
            this.Text = "Subscriptions";
            this.Load += new System.EventHandler(this.frmSubscriptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSubscription)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllSubscription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refresjhToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label label7;
    }
}