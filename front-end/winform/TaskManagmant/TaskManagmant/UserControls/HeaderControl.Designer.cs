namespace TaskManagmant.UserControls
{
    partial class HeaderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenue = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picUserProfile = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblOwners = new System.Windows.Forms.Label();
            this.pnlMenue.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenue
            // 
            this.pnlMenue.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMenue.Controls.Add(this.lblOwners);
            this.pnlMenue.Controls.Add(this.panel1);
            this.pnlMenue.Controls.Add(this.lblProjectName);
            this.pnlMenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenue.Location = new System.Drawing.Point(0, 0);
            this.pnlMenue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMenue.Name = "pnlMenue";
            this.pnlMenue.Size = new System.Drawing.Size(1200, 100);
            this.pnlMenue.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picUserProfile);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(912, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 100);
            this.panel1.TabIndex = 6;
            // 
            // picUserProfile
            // 
            this.picUserProfile.Location = new System.Drawing.Point(194, 13);
            this.picUserProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picUserProfile.Name = "picUserProfile";
            this.picUserProfile.Size = new System.Drawing.Size(75, 75);
            this.picUserProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserProfile.TabIndex = 5;
            this.picUserProfile.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblUserName.Location = new System.Drawing.Point(53, 37);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(120, 30);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "User Name";
            // 
            // lblProjectName
            // 
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProjectName.Location = new System.Drawing.Point(24, 17);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(198, 65);
            this.lblProjectName.TabIndex = 3;
            this.lblProjectName.Text = "TaskMe";
            // 
            // lblOwners
            // 
            this.lblOwners.BackColor = System.Drawing.Color.Transparent;
            this.lblOwners.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblOwners.Location = new System.Drawing.Point(24, 72);
            this.lblOwners.Name = "lblOwners";
            this.lblOwners.Size = new System.Drawing.Size(198, 20);
            this.lblOwners.TabIndex = 7;
            this.lblOwners.Text = "By Tamar And Efrat";
            this.lblOwners.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMenue);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HeaderControl";
            this.Size = new System.Drawing.Size(1200, 100);
            this.pnlMenue.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenue;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.PictureBox picUserProfile;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOwners;
    }
}
