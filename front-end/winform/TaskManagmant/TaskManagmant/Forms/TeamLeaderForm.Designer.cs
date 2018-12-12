namespace TaskManagmant.Forms
{
    partial class TeamLeaderForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.followYourProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamWorkerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workersHoursStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 100);
            this.pnlHeader.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.followYourProjectsToolStripMenuItem,
            this.teamWorkerListToolStripMenuItem,
            this.workersHoursStatusToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 100);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 29);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // followYourProjectsToolStripMenuItem
            // 
            this.followYourProjectsToolStripMenuItem.Name = "followYourProjectsToolStripMenuItem";
            this.followYourProjectsToolStripMenuItem.Size = new System.Drawing.Size(163, 25);
            this.followYourProjectsToolStripMenuItem.Text = "Follow your projects";
            this.followYourProjectsToolStripMenuItem.Click += new System.EventHandler(this.FollowYourProjectsToolStripMenuItem_Click);
            // 
            // teamWorkerListToolStripMenuItem
            // 
            this.teamWorkerListToolStripMenuItem.Name = "teamWorkerListToolStripMenuItem";
            this.teamWorkerListToolStripMenuItem.Size = new System.Drawing.Size(212, 25);
            this.teamWorkerListToolStripMenuItem.Text = "Workers hours managmant";
            this.teamWorkerListToolStripMenuItem.Click += new System.EventHandler(this.TeamWorkerListToolStripMenuItem_Click);
            // 
            // workersHoursStatusToolStripMenuItem
            // 
            this.workersHoursStatusToolStripMenuItem.Name = "workersHoursStatusToolStripMenuItem";
            this.workersHoursStatusToolStripMenuItem.Size = new System.Drawing.Size(172, 25);
            this.workersHoursStatusToolStripMenuItem.Text = "Workers Hours Status";
            this.workersHoursStatusToolStripMenuItem.Click += new System.EventHandler(this.WorkersHoursStatusToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // TeamLeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 727);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "TeamLeaderForm";
            this.Text = "TeamLeader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeamLeaderForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem followYourProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamWorkerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workersHoursStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}