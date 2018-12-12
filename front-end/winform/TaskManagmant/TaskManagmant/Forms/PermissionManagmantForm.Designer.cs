namespace TaskManagmant.Forms
{
    partial class PermissionManagmantForm
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
            this.lblInstuction1 = new System.Windows.Forms.Label();
            this.lblInstuction2 = new System.Windows.Forms.Label();
            this.lblSelctedTitle = new System.Windows.Forms.Label();
            this.lblProjectTeamTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbOtherWorkers = new System.Windows.Forms.ComboBox();
            this.listSelectedWorkers = new System.Windows.Forms.ListBox();
            this.listProjectWorkers = new System.Windows.Forms.ListBox();
            this.listPermissionWorkers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstuction1
            // 
            this.lblInstuction1.AutoSize = true;
            this.lblInstuction1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInstuction1.Location = new System.Drawing.Point(658, 93);
            this.lblInstuction1.Name = "lblInstuction1";
            this.lblInstuction1.Size = new System.Drawing.Size(190, 34);
            this.lblInstuction1.TabIndex = 23;
            this.lblInstuction1.Text = "Select worker from combo-box\r\nto work for this project\r\n";
            // 
            // lblInstuction2
            // 
            this.lblInstuction2.AutoSize = true;
            this.lblInstuction2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInstuction2.Location = new System.Drawing.Point(914, 93);
            this.lblInstuction2.Name = "lblInstuction2";
            this.lblInstuction2.Size = new System.Drawing.Size(171, 51);
            this.lblInstuction2.TabIndex = 22;
            this.lblInstuction2.Text = "Double click on an item \r\nto remove the permission \r\nof this worker to the projec" +
    "t";
            // 
            // lblSelctedTitle
            // 
            this.lblSelctedTitle.AutoSize = true;
            this.lblSelctedTitle.Location = new System.Drawing.Point(915, 51);
            this.lblSelctedTitle.Name = "lblSelctedTitle";
            this.lblSelctedTitle.Size = new System.Drawing.Size(151, 21);
            this.lblSelctedTitle.TabIndex = 21;
            this.lblSelctedTitle.Text = "Selected Worker List";
            this.lblSelctedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProjectTeamTitle
            // 
            this.lblProjectTeamTitle.AutoSize = true;
            this.lblProjectTeamTitle.Location = new System.Drawing.Point(88, 51);
            this.lblProjectTeamTitle.Name = "lblProjectTeamTitle";
            this.lblProjectTeamTitle.Size = new System.Drawing.Size(181, 21);
            this.lblProjectTeamTitle.TabIndex = 20;
            this.lblProjectTeamTitle.Text = "Project Team Worker List";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(500, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 32);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cmbOtherWorkers
            // 
            this.cmbOtherWorkers.FormattingEnabled = true;
            this.cmbOtherWorkers.Location = new System.Drawing.Point(658, 152);
            this.cmbOtherWorkers.Name = "cmbOtherWorkers";
            this.cmbOtherWorkers.Size = new System.Drawing.Size(200, 29);
            this.cmbOtherWorkers.TabIndex = 18;
            this.cmbOtherWorkers.SelectedIndexChanged += new System.EventHandler(this.CmbOtherWorkers_SelectedIndexChanged);
            // 
            // listSelectedWorkers
            // 
            this.listSelectedWorkers.FormattingEnabled = true;
            this.listSelectedWorkers.ItemHeight = 21;
            this.listSelectedWorkers.Location = new System.Drawing.Point(914, 151);
            this.listSelectedWorkers.Name = "listSelectedWorkers";
            this.listSelectedWorkers.Size = new System.Drawing.Size(200, 256);
            this.listSelectedWorkers.TabIndex = 17;
            this.listSelectedWorkers.DoubleClick += new System.EventHandler(this.ListSelectedWorkers_DoubleClick);
            // 
            // listProjectWorkers
            // 
            this.listProjectWorkers.FormattingEnabled = true;
            this.listProjectWorkers.ItemHeight = 21;
            this.listProjectWorkers.Location = new System.Drawing.Point(86, 151);
            this.listProjectWorkers.Name = "listProjectWorkers";
            this.listProjectWorkers.Size = new System.Drawing.Size(200, 256);
            this.listProjectWorkers.TabIndex = 16;
            // 
            // listPermissionWorkers
            // 
            this.listPermissionWorkers.FormattingEnabled = true;
            this.listPermissionWorkers.ItemHeight = 21;
            this.listPermissionWorkers.Location = new System.Drawing.Point(350, 151);
            this.listPermissionWorkers.Name = "listPermissionWorkers";
            this.listPermissionWorkers.Size = new System.Drawing.Size(200, 256);
            this.listPermissionWorkers.TabIndex = 24;
            this.listPermissionWorkers.DoubleClick += new System.EventHandler(this.ListPermissionWorkers_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 42);
            this.label1.TabIndex = 25;
            this.label1.Text = "Workers with permission \r\nfor this projct";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(351, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 51);
            this.label2.TabIndex = 26;
            this.label2.Text = "Double click on an item \r\nto remove the permission \r\nof this worker to the projec" +
    "t";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.listProjectWorkers);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.listSelectedWorkers);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.cmbOtherWorkers);
            this.pnlContainer.Controls.Add(this.listPermissionWorkers);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.lblInstuction1);
            this.pnlContainer.Controls.Add(this.lblProjectTeamTitle);
            this.pnlContainer.Controls.Add(this.lblInstuction2);
            this.pnlContainer.Controls.Add(this.lblSelctedTitle);
            this.pnlContainer.Location = new System.Drawing.Point(71, 38);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1200, 523);
            this.pnlContainer.TabIndex = 27;
            // 
            // PermissionManagmantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 598);
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "PermissionManagmantForm";
            this.Text = "AddPermissionForm";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstuction1;
        private System.Windows.Forms.Label lblInstuction2;
        private System.Windows.Forms.Label lblSelctedTitle;
        private System.Windows.Forms.Label lblProjectTeamTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbOtherWorkers;
        private System.Windows.Forms.ListBox listSelectedWorkers;
        private System.Windows.Forms.ListBox listProjectWorkers;
        private System.Windows.Forms.ListBox listPermissionWorkers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlContainer;
    }
}