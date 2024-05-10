namespace PresintaionLayer_GYM_Project_WinForms
{
    partial class frmTrainers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrainers));
            this.dgvAllTrainers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addTrainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mtxtSearch = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTrainers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllTrainers
            // 
            this.dgvAllTrainers.AllowUserToAddRows = false;
            this.dgvAllTrainers.AllowUserToDeleteRows = false;
            this.dgvAllTrainers.AllowUserToOrderColumns = true;
            this.dgvAllTrainers.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllTrainers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllTrainers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAllTrainers.Location = new System.Drawing.Point(0, 232);
            this.dgvAllTrainers.Name = "dgvAllTrainers";
            this.dgvAllTrainers.ReadOnly = true;
            this.dgvAllTrainers.Size = new System.Drawing.Size(948, 274);
            this.dgvAllTrainers.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.refreshToolStripMenuItem1,
            this.addTrainerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 92);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Edit;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.updateToolStripMenuItem.Text = "Edit";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Final_Delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Refresh;
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            // 
            // addTrainerToolStripMenuItem
            // 
            this.addTrainerToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Trainer;
            this.addTrainerToolStripMenuItem.Name = "addTrainerToolStripMenuItem";
            this.addTrainerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.addTrainerToolStripMenuItem.Text = "Add Trainer";
            this.addTrainerToolStripMenuItem.Click += new System.EventHandler(this.addTrainerToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(540, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 38);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mtxtSearch
            // 
            this.mtxtSearch.Font = new System.Drawing.Font("Tahoma", 20F);
            this.mtxtSearch.Location = new System.Drawing.Point(374, 12);
            this.mtxtSearch.Mask = "00000000000";
            this.mtxtSearch.Name = "mtxtSearch";
            this.mtxtSearch.Size = new System.Drawing.Size(171, 40);
            this.mtxtSearch.TabIndex = 5;
            this.mtxtSearch.ValidatingType = typeof(int);
            this.mtxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter Phone:";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::PresintaionLayer_GYM_Project_WinForms.Properties.Resources.Refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label7.Location = new System.Drawing.Point(12, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "Trainers:";
            // 
            // frmTrainers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(948, 506);
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAllTrainers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrainers";
            this.Text = "Trainers";
            this.Load += new System.EventHandler(this.frmTrainers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTrainers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllTrainers;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox mtxtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addTrainerToolStripMenuItem;
        private System.Windows.Forms.Label label7;
    }
}