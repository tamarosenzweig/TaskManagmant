﻿namespace TaskManagmant.UserControls
{
    partial class WorkerTaskControl
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblNumHours = new System.Windows.Forms.Label();
            this.btnStartOrStop = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPresence = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(30, 29);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(100, 21);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "ProjectName";
            // 
            // lblNumHours
            // 
            this.lblNumHours.AutoSize = true;
            this.lblNumHours.Location = new System.Drawing.Point(160, 29);
            this.lblNumHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumHours.Name = "lblNumHours";
            this.lblNumHours.Size = new System.Drawing.Size(87, 21);
            this.lblNumHours.TabIndex = 1;
            this.lblNumHours.Text = "NumHours";
            // 
            // btnStartOrStop
            // 
            this.btnStartOrStop.Location = new System.Drawing.Point(390, 21);
            this.btnStartOrStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartOrStop.Name = "btnStartOrStop";
            this.btnStartOrStop.Size = new System.Drawing.Size(166, 37);
            this.btnStartOrStop.TabIndex = 2;
            this.btnStartOrStop.Text = "Start Your Task";
            this.btnStartOrStop.UseVisualStyleBackColor = true;
            this.btnStartOrStop.Click += new System.EventHandler(this.BtnStartOrStop_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(600, 27);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(70, 21);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00:00";
            // 
            // lblPresence
            // 
            this.lblPresence.AutoSize = true;
            this.lblPresence.Location = new System.Drawing.Point(274, 29);
            this.lblPresence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPresence.Name = "lblPresence";
            this.lblPresence.Size = new System.Drawing.Size(72, 21);
            this.lblPresence.TabIndex = 4;
            this.lblPresence.Text = "Presence";
            // 
            // WorkerTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPresence);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnStartOrStop);
            this.Controls.Add(this.lblNumHours);
            this.Controls.Add(this.lblProjectName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WorkerTaskControl";
            this.Size = new System.Drawing.Size(814, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblNumHours;
        private System.Windows.Forms.Button btnStartOrStop;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPresence;
    }
}
