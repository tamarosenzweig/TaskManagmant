namespace TaskManagmant.Forms
{
    partial class UpdateHoursDialog
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
            this.lblNumHours = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.numericHours = new System.Windows.Forms.NumericUpDown();
            this.lblPresence = new System.Windows.Forms.Label();
            this.lblWorkerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumHours
            // 
            this.lblNumHours.AutoSize = true;
            this.lblNumHours.Location = new System.Drawing.Point(35, 126);
            this.lblNumHours.Name = "lblNumHours";
            this.lblNumHours.Size = new System.Drawing.Size(59, 21);
            this.lblNumHours.TabIndex = 4;
            this.lblNumHours.Text = "Hours: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // numericHours
            // 
            this.numericHours.Location = new System.Drawing.Point(108, 126);
            this.numericHours.Name = "numericHours";
            this.numericHours.Size = new System.Drawing.Size(120, 29);
            this.numericHours.TabIndex = 2;
            // 
            // lblPresence
            // 
            this.lblPresence.AutoSize = true;
            this.lblPresence.Location = new System.Drawing.Point(32, 80);
            this.lblPresence.Name = "lblPresence";
            this.lblPresence.Size = new System.Drawing.Size(79, 21);
            this.lblPresence.TabIndex = 1;
            this.lblPresence.Text = "Presence: ";
            // 
            // lblWorkerName
            // 
            this.lblWorkerName.AutoSize = true;
            this.lblWorkerName.Location = new System.Drawing.Point(32, 34);
            this.lblWorkerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkerName.Name = "lblWorkerName";
            this.lblWorkerName.Size = new System.Drawing.Size(114, 21);
            this.lblWorkerName.TabIndex = 0;
            this.lblWorkerName.Text = "Worker Name: ";
            // 
            // UpdateHoursDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.lblNumHours);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericHours);
            this.Controls.Add(this.lblPresence);
            this.Controls.Add(this.lblWorkerName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "UpdateHoursDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateHoursDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWorkerName;
        private System.Windows.Forms.Label lblPresence;
        private System.Windows.Forms.NumericUpDown numericHours;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNumHours;
    }
}