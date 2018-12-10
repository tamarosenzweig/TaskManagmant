namespace TaskManagmant.Forms
{
    partial class WorkersHoursForm
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
            this.lblPresence = new System.Windows.Forms.Label();
            this.lblWorkersHours = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblPresence2 = new System.Windows.Forms.Label();
            this.lblWorkersHours2 = new System.Windows.Forms.Label();
            this.lblTotalHours2 = new System.Windows.Forms.Label();
            this.lblProjectName2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPresence
            // 
            this.lblPresence.AutoSize = true;
            this.lblPresence.Location = new System.Drawing.Point(425, 70);
            this.lblPresence.Name = "lblPresence";
            this.lblPresence.Size = new System.Drawing.Size(72, 21);
            this.lblPresence.TabIndex = 15;
            this.lblPresence.Text = "Presence";
            // 
            // lblWorkersHours
            // 
            this.lblWorkersHours.AutoSize = true;
            this.lblWorkersHours.Location = new System.Drawing.Point(425, 35);
            this.lblWorkersHours.Name = "lblWorkersHours";
            this.lblWorkersHours.Size = new System.Drawing.Size(114, 21);
            this.lblWorkersHours.TabIndex = 14;
            this.lblWorkersHours.Text = "Workers Hours";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(160, 70);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(88, 21);
            this.lblTotalHours.TabIndex = 13;
            this.lblTotalHours.Text = "Total Hours";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(160, 35);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(97, 21);
            this.lblProjectName.TabIndex = 12;
            this.lblProjectName.Text = "Projet Name";
            // 
            // lblPresence2
            // 
            this.lblPresence2.AutoSize = true;
            this.lblPresence2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPresence2.Location = new System.Drawing.Point(305, 70);
            this.lblPresence2.Name = "lblPresence2";
            this.lblPresence2.Size = new System.Drawing.Size(84, 21);
            this.lblPresence2.TabIndex = 11;
            this.lblPresence2.Text = "Presence: ";
            // 
            // lblWorkersHours2
            // 
            this.lblWorkersHours2.AutoSize = true;
            this.lblWorkersHours2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblWorkersHours2.Location = new System.Drawing.Point(305, 35);
            this.lblWorkersHours2.Name = "lblWorkersHours2";
            this.lblWorkersHours2.Size = new System.Drawing.Size(127, 21);
            this.lblWorkersHours2.TabIndex = 10;
            this.lblWorkersHours2.Text = "Workers Hours: ";
            // 
            // lblTotalHours2
            // 
            this.lblTotalHours2.AutoSize = true;
            this.lblTotalHours2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTotalHours2.Location = new System.Drawing.Point(40, 70);
            this.lblTotalHours2.Name = "lblTotalHours2";
            this.lblTotalHours2.Size = new System.Drawing.Size(101, 21);
            this.lblTotalHours2.TabIndex = 9;
            this.lblTotalHours2.Text = "Total Hours: ";
            // 
            // lblProjectName2
            // 
            this.lblProjectName2.AutoSize = true;
            this.lblProjectName2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProjectName2.Location = new System.Drawing.Point(40, 35);
            this.lblProjectName2.Name = "lblProjectName2";
            this.lblProjectName2.Size = new System.Drawing.Size(109, 21);
            this.lblProjectName2.TabIndex = 8;
            this.lblProjectName2.Text = "Projet Name: ";
            // 
            // WorkersHoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.lblPresence);
            this.Controls.Add(this.lblWorkersHours);
            this.Controls.Add(this.lblTotalHours);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.lblPresence2);
            this.Controls.Add(this.lblWorkersHours2);
            this.Controls.Add(this.lblTotalHours2);
            this.Controls.Add(this.lblProjectName2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "WorkersHoursForm";
            this.Text = "WorkersHoursForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPresence;
        private System.Windows.Forms.Label lblWorkersHours;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblPresence2;
        private System.Windows.Forms.Label lblWorkersHours2;
        private System.Windows.Forms.Label lblTotalHours2;
        private System.Windows.Forms.Label lblProjectName2;
    }
}