namespace TaskManagmant.UserControls
{
    partial class ProjectUserControl
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
            this.projectName = new System.Windows.Forms.Label();
            this.totalHours = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.Label();
            this.customer = new System.Windows.Forms.Label();
            this.teamLeader = new System.Windows.Forms.Label();
            this.precents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projectName
            // 
            this.projectName.AutoSize = true;
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.projectName.ForeColor = System.Drawing.Color.Pink;
            this.projectName.Location = new System.Drawing.Point(10, 23);
            this.projectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(57, 20);
            this.projectName.TabIndex = 3;
            this.projectName.Text = "name: ";
            // 
            // totalHours
            // 
            this.totalHours.AutoSize = true;
            this.totalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.totalHours.ForeColor = System.Drawing.Color.Pink;
            this.totalHours.Location = new System.Drawing.Point(9, 55);
            this.totalHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalHours.Name = "totalHours";
            this.totalHours.Size = new System.Drawing.Size(92, 20);
            this.totalHours.TabIndex = 4;
            this.totalHours.Text = "total hours: ";
            // 
            // startDate
            // 
            this.startDate.AutoSize = true;
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.startDate.ForeColor = System.Drawing.Color.Pink;
            this.startDate.Location = new System.Drawing.Point(9, 84);
            this.startDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(85, 20);
            this.startDate.TabIndex = 5;
            this.startDate.Text = "start date: ";
            // 
            // endDate
            // 
            this.endDate.AutoSize = true;
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.endDate.ForeColor = System.Drawing.Color.Pink;
            this.endDate.Location = new System.Drawing.Point(9, 116);
            this.endDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(80, 20);
            this.endDate.TabIndex = 6;
            this.endDate.Text = "end date: ";
            // 
            // customer
            // 
            this.customer.AutoSize = true;
            this.customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customer.ForeColor = System.Drawing.Color.Pink;
            this.customer.Location = new System.Drawing.Point(9, 145);
            this.customer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(83, 20);
            this.customer.TabIndex = 7;
            this.customer.Text = "customer: ";
            // 
            // teamLeader
            // 
            this.teamLeader.AutoSize = true;
            this.teamLeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.teamLeader.ForeColor = System.Drawing.Color.Pink;
            this.teamLeader.Location = new System.Drawing.Point(9, 173);
            this.teamLeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.teamLeader.Name = "teamLeader";
            this.teamLeader.Size = new System.Drawing.Size(105, 20);
            this.teamLeader.TabIndex = 8;
            this.teamLeader.Text = "team leader:  ";
            // 
            // precents
            // 
            this.precents.AutoSize = true;
            this.precents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.precents.ForeColor = System.Drawing.Color.Pink;
            this.precents.Location = new System.Drawing.Point(10, 202);
            this.precents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.precents.Name = "precents";
            this.precents.Size = new System.Drawing.Size(75, 20);
            this.precents.TabIndex = 9;
            this.precents.Text = "precent:  ";
            // 
            // ProjectUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.precents);
            this.Controls.Add(this.teamLeader);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.totalHours);
            this.Controls.Add(this.projectName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProjectUserControl";
            this.Size = new System.Drawing.Size(202, 233);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projectName;
        private System.Windows.Forms.Label totalHours;
        private System.Windows.Forms.Label startDate;
        private System.Windows.Forms.Label endDate;
        private System.Windows.Forms.Label customer;
        private System.Windows.Forms.Label teamLeader;
        private System.Windows.Forms.Label precents;
    }
}
