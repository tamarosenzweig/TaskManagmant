namespace TaskManagmant.Forms
{
    partial class ManagerForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.usersManagmantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allUsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsManagmantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamsManagmantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 100);
            this.pnlHeader.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersManagmantMenuItem,
            this.projectsManagmantMenuItem,
            this.teamsManagmantMenuItem,
            this.logoutMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 100);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1280, 31);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // usersManagmantMenuItem
            // 
            this.usersManagmantMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allUsersMenuItem,
            this.addUserMenuItem});
            this.usersManagmantMenuItem.Name = "usersManagmantMenuItem";
            this.usersManagmantMenuItem.Size = new System.Drawing.Size(149, 25);
            this.usersManagmantMenuItem.Text = "Users Managmant";
            // 
            // allUsersMenuItem
            // 
            this.allUsersMenuItem.Name = "allUsersMenuItem";
            this.allUsersMenuItem.Size = new System.Drawing.Size(144, 26);
            this.allUsersMenuItem.Text = "All User";
            this.allUsersMenuItem.Click += new System.EventHandler(this.AllUsers_Click);
            // 
            // addUserMenuItem
            // 
            this.addUserMenuItem.Name = "addUserMenuItem";
            this.addUserMenuItem.Size = new System.Drawing.Size(144, 26);
            this.addUserMenuItem.Text = "Add User";
            this.addUserMenuItem.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // projectsManagmantMenuItem
            // 
            this.projectsManagmantMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsMenuItem,
            this.addProjectMenuItem,
            this.permissionsToolStripMenuItem});
            this.projectsManagmantMenuItem.Name = "projectsManagmantMenuItem";
            this.projectsManagmantMenuItem.Size = new System.Drawing.Size(173, 25);
            this.projectsManagmantMenuItem.Text = "Projects Managemant";
            // 
            // reportsMenuItem
            // 
            this.reportsMenuItem.Name = "reportsMenuItem";
            this.reportsMenuItem.Size = new System.Drawing.Size(163, 26);
            this.reportsMenuItem.Text = "Reports";
            this.reportsMenuItem.Click += new System.EventHandler(this.Reports_Click);
            // 
            // addProjectMenuItem
            // 
            this.addProjectMenuItem.Name = "addProjectMenuItem";
            this.addProjectMenuItem.Size = new System.Drawing.Size(163, 26);
            this.addProjectMenuItem.Text = "Add Project";
            this.addProjectMenuItem.Click += new System.EventHandler(this.AddProject_Click);
            // 
            // permissionsToolStripMenuItem
            // 
            this.permissionsToolStripMenuItem.Name = "permissionsToolStripMenuItem";
            this.permissionsToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.permissionsToolStripMenuItem.Text = "Permissions";
            this.permissionsToolStripMenuItem.Click += new System.EventHandler(this.permissionsToolStripMenuItem_Click);
            // 
            // teamsManagmantMenuItem
            // 
            this.teamsManagmantMenuItem.Name = "teamsManagmantMenuItem";
            this.teamsManagmantMenuItem.Size = new System.Drawing.Size(152, 25);
            this.teamsManagmantMenuItem.Text = "teams managmant";
            this.teamsManagmantMenuItem.Click += new System.EventHandler(this.TeamsManagement_Click);
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Name = "logoutMenuItem";
            this.logoutMenuItem.Size = new System.Drawing.Size(67, 25);
            this.logoutMenuItem.Text = "logout";
            this.logoutMenuItem.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 749);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ManagerForm";
            this.Text = "Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem usersManagmantMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allUsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsManagmantMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProjectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamsManagmantMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissionsToolStripMenuItem;
    }
}