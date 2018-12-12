namespace TaskManagmant.Forms
{
    partial class TeamManagementForm
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
            this.listTeamWorkers = new System.Windows.Forms.ListBox();
            this.listSelectedWorkers = new System.Windows.Forms.ListBox();
            this.cmbOtherWorkers = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTeamTitle = new System.Windows.Forms.Label();
            this.lblSelctedTitle = new System.Windows.Forms.Label();
            this.lblInstuction2 = new System.Windows.Forms.Label();
            this.lblInstuction1 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listTeamWorkers
            // 
            this.listTeamWorkers.FormattingEnabled = true;
            this.listTeamWorkers.ItemHeight = 21;
            this.listTeamWorkers.Location = new System.Drawing.Point(135, 131);
            this.listTeamWorkers.Name = "listTeamWorkers";
            this.listTeamWorkers.Size = new System.Drawing.Size(200, 256);
            this.listTeamWorkers.TabIndex = 0;
            // 
            // listSelectedWorkers
            // 
            this.listSelectedWorkers.FormattingEnabled = true;
            this.listSelectedWorkers.ItemHeight = 21;
            this.listSelectedWorkers.Location = new System.Drawing.Point(785, 131);
            this.listSelectedWorkers.Name = "listSelectedWorkers";
            this.listSelectedWorkers.Size = new System.Drawing.Size(200, 256);
            this.listSelectedWorkers.TabIndex = 1;
            this.listSelectedWorkers.DoubleClick += new System.EventHandler(this.ListSelectedWorkers_DoubleClick);
            // 
            // cmbOtherWorkers
            // 
            this.cmbOtherWorkers.FormattingEnabled = true;
            this.cmbOtherWorkers.Location = new System.Drawing.Point(467, 133);
            this.cmbOtherWorkers.Name = "cmbOtherWorkers";
            this.cmbOtherWorkers.Size = new System.Drawing.Size(200, 29);
            this.cmbOtherWorkers.TabIndex = 2;
            this.cmbOtherWorkers.SelectedIndexChanged += new System.EventHandler(this.CmbOtherWorkers_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(467, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblTeamTitle
            // 
            this.lblTeamTitle.AutoSize = true;
            this.lblTeamTitle.Location = new System.Drawing.Point(170, 31);
            this.lblTeamTitle.Name = "lblTeamTitle";
            this.lblTeamTitle.Size = new System.Drawing.Size(129, 21);
            this.lblTeamTitle.TabIndex = 4;
            this.lblTeamTitle.Text = "Team Worker List";
            // 
            // lblSelctedTitle
            // 
            this.lblSelctedTitle.AutoSize = true;
            this.lblSelctedTitle.Location = new System.Drawing.Point(788, 31);
            this.lblSelctedTitle.Name = "lblSelctedTitle";
            this.lblSelctedTitle.Size = new System.Drawing.Size(151, 21);
            this.lblSelctedTitle.TabIndex = 5;
            this.lblSelctedTitle.Text = "Selected Worker List";
            this.lblSelctedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInstuction2
            // 
            this.lblInstuction2.AutoSize = true;
            this.lblInstuction2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInstuction2.Location = new System.Drawing.Point(782, 74);
            this.lblInstuction2.Name = "lblInstuction2";
            this.lblInstuction2.Size = new System.Drawing.Size(191, 34);
            this.lblInstuction2.TabIndex = 6;
            this.lblInstuction2.Text = "Double click on an item \r\nto remove this worker the team";
            // 
            // lblInstuction1
            // 
            this.lblInstuction1.AutoSize = true;
            this.lblInstuction1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInstuction1.Location = new System.Drawing.Point(468, 74);
            this.lblInstuction1.Name = "lblInstuction1";
            this.lblInstuction1.Size = new System.Drawing.Size(190, 34);
            this.lblInstuction1.TabIndex = 7;
            this.lblInstuction1.Text = "Select worker from combo-box\r\nto join him to th team";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.lblTeamTitle);
            this.pnlContainer.Controls.Add(this.lblInstuction1);
            this.pnlContainer.Controls.Add(this.listTeamWorkers);
            this.pnlContainer.Controls.Add(this.lblInstuction2);
            this.pnlContainer.Controls.Add(this.listSelectedWorkers);
            this.pnlContainer.Controls.Add(this.lblSelctedTitle);
            this.pnlContainer.Controls.Add(this.cmbOtherWorkers);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Location = new System.Drawing.Point(48, 31);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1129, 446);
            this.pnlContainer.TabIndex = 8;
            // 
            // TeamManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 510);
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "TeamManagementForm";
            this.Text = "TeamManagementForm";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTeamWorkers;
        private System.Windows.Forms.ListBox listSelectedWorkers;
        private System.Windows.Forms.ComboBox cmbOtherWorkers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTeamTitle;
        private System.Windows.Forms.Label lblSelctedTitle;
        private System.Windows.Forms.Label lblInstuction2;
        private System.Windows.Forms.Label lblInstuction1;
        private System.Windows.Forms.Panel pnlContainer;
    }
}