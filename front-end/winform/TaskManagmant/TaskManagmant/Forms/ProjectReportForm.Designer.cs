namespace TaskManagmant.Forms
{
    partial class ProjectReportForm
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
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlConditions = new System.Windows.Forms.Panel();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblWorker = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.cmbWorker = new System.Windows.Forms.ComboBox();
            this.lblTeamLeader = new System.Windows.Forms.Label();
            this.cmbTeamLeader = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.pnlConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1028, 35);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(143, 37);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export to EXEL";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // pnlConditions
            // 
            this.pnlConditions.Controls.Add(this.lblProject);
            this.pnlConditions.Controls.Add(this.lblWorker);
            this.pnlConditions.Controls.Add(this.cmbProject);
            this.pnlConditions.Controls.Add(this.cmbWorker);
            this.pnlConditions.Controls.Add(this.lblTeamLeader);
            this.pnlConditions.Controls.Add(this.cmbTeamLeader);
            this.pnlConditions.Controls.Add(this.lblMonth);
            this.pnlConditions.Controls.Add(this.cmbMonth);
            this.pnlConditions.Location = new System.Drawing.Point(2, 12);
            this.pnlConditions.Name = "pnlConditions";
            this.pnlConditions.Size = new System.Drawing.Size(961, 61);
            this.pnlConditions.TabIndex = 9;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(720, 19);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(61, 21);
            this.lblProject.TabIndex = 16;
            this.lblProject.Text = "Project:";
            // 
            // lblWorker
            // 
            this.lblWorker.AutoSize = true;
            this.lblWorker.Location = new System.Drawing.Point(240, 19);
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Size = new System.Drawing.Size(64, 21);
            this.lblWorker.TabIndex = 14;
            this.lblWorker.Text = "Worker:";
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(820, 15);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(121, 29);
            this.cmbProject.TabIndex = 15;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // cmbWorker
            // 
            this.cmbWorker.FormattingEnabled = true;
            this.cmbWorker.Location = new System.Drawing.Point(340, 15);
            this.cmbWorker.Name = "cmbWorker";
            this.cmbWorker.Size = new System.Drawing.Size(121, 29);
            this.cmbWorker.TabIndex = 13;
            this.cmbWorker.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // lblTeamLeader
            // 
            this.lblTeamLeader.AutoSize = true;
            this.lblTeamLeader.Location = new System.Drawing.Point(480, 19);
            this.lblTeamLeader.Name = "lblTeamLeader";
            this.lblTeamLeader.Size = new System.Drawing.Size(100, 21);
            this.lblTeamLeader.TabIndex = 12;
            this.lblTeamLeader.Text = "Team Leader:";
            // 
            // cmbTeamLeader
            // 
            this.cmbTeamLeader.FormattingEnabled = true;
            this.cmbTeamLeader.Location = new System.Drawing.Point(580, 15);
            this.cmbTeamLeader.Name = "cmbTeamLeader";
            this.cmbTeamLeader.Size = new System.Drawing.Size(121, 29);
            this.cmbTeamLeader.TabIndex = 11;
            this.cmbTeamLeader.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(10, 19);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(59, 21);
            this.lblMonth.TabIndex = 10;
            this.lblMonth.Text = "Month:";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(110, 15);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 29);
            this.cmbMonth.TabIndex = 9;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // ProjectReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.pnlConditions);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ProjectReportForm";
            this.Text = "ProjectReportForm";
            this.pnlConditions.ResumeLayout(false);
            this.pnlConditions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlConditions;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label lblWorker;
        private System.Windows.Forms.ComboBox cmbWorker;
        private System.Windows.Forms.Label lblTeamLeader;
        private System.Windows.Forms.ComboBox cmbTeamLeader;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
    }
}