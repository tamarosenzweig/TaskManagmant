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
            this.picUserProfile = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.pnlMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenue
            // 
            this.pnlMenue.Controls.Add(this.picUserProfile);
            this.pnlMenue.Controls.Add(this.lblUserName);
            this.pnlMenue.Controls.Add(this.lblProjectName);
            this.pnlMenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenue.Location = new System.Drawing.Point(0, 0);
            this.pnlMenue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMenue.Name = "pnlMenue";
            this.pnlMenue.Size = new System.Drawing.Size(1200, 100);
            this.pnlMenue.TabIndex = 2;
            // 
            // picUserProfile
            // 
            this.picUserProfile.Location = new System.Drawing.Point(1095, 13);
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
            this.lblUserName.Location = new System.Drawing.Point(927, 37);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(120, 30);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "User Name";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProjectName.Location = new System.Drawing.Point(27, 26);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(338, 50);
            this.lblProjectName.TabIndex = 3;
            this.lblProjectName.Text = "Task Management";
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
            this.pnlMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenue;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.PictureBox picUserProfile;
        private System.Windows.Forms.Label lblUserName;
    }
}
