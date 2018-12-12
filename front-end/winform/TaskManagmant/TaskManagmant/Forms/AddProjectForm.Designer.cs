namespace TaskManagmant.Forms
{
    partial class AddProjectForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlHours = new System.Windows.Forms.Panel();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbTeamLeader = new System.Windows.Forms.ComboBox();
            this.lblTeamLeader = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlContainer.SuspendLayout();
            this.pnlHours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.lblStartDate);
            this.pnlContainer.Controls.Add(this.dtEndDate);
            this.pnlContainer.Controls.Add(this.lblEndDate);
            this.pnlContainer.Controls.Add(this.dtStartDate);
            this.pnlContainer.Controls.Add(this.pnlHours);
            this.pnlContainer.Controls.Add(this.cmbCustomer);
            this.pnlContainer.Controls.Add(this.cmbTeamLeader);
            this.pnlContainer.Controls.Add(this.lblTeamLeader);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.txtProjectName);
            this.pnlContainer.Controls.Add(this.lblProjectName);
            this.pnlContainer.Controls.Add(this.lblCustomer);
            this.pnlContainer.Location = new System.Drawing.Point(33, 23);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1020, 474);
            this.pnlContainer.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStartDate.Location = new System.Drawing.Point(705, 145);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(75, 21);
            this.lblStartDate.TabIndex = 92;
            this.lblStartDate.Text = "start date";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtEndDate.Location = new System.Drawing.Point(705, 245);
            this.dtEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(300, 29);
            this.dtEndDate.TabIndex = 91;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            this.dtEndDate.Leave += new System.EventHandler(this.DateTimePicker_Leave);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblEndDate.Location = new System.Drawing.Point(705, 220);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(70, 21);
            this.lblEndDate.TabIndex = 90;
            this.lblEndDate.Text = "end date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtStartDate.Location = new System.Drawing.Point(705, 170);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(300, 29);
            this.dtStartDate.TabIndex = 89;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            this.dtStartDate.Leave += new System.EventHandler(this.DateTimePicker_Leave);
            // 
            // pnlHours
            // 
            this.pnlHours.Controls.Add(this.lblTotalHours);
            this.pnlHours.Controls.Add(this.lblHours);
            this.pnlHours.Location = new System.Drawing.Point(360, 95);
            this.pnlHours.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHours.Name = "pnlHours";
            this.pnlHours.Size = new System.Drawing.Size(300, 326);
            this.pnlHours.TabIndex = 87;
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(0, 50);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(104, 21);
            this.lblTotalHours.TabIndex = 1;
            this.lblTotalHours.Text = "Total Hours: 0";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHours.Location = new System.Drawing.Point(29, 6);
            this.lblHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(241, 21);
            this.lblHours.TabIndex = 0;
            this.lblHours.Text = "Enter hours for every department";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(15, 320);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(300, 29);
            this.cmbCustomer.TabIndex = 86;
            // 
            // cmbTeamLeader
            // 
            this.cmbTeamLeader.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbTeamLeader.FormattingEnabled = true;
            this.cmbTeamLeader.Location = new System.Drawing.Point(15, 245);
            this.cmbTeamLeader.Name = "cmbTeamLeader";
            this.cmbTeamLeader.Size = new System.Drawing.Size(300, 29);
            this.cmbTeamLeader.TabIndex = 85;
            // 
            // lblTeamLeader
            // 
            this.lblTeamLeader.AutoSize = true;
            this.lblTeamLeader.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTeamLeader.Location = new System.Drawing.Point(15, 220);
            this.lblTeamLeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeamLeader.Name = "lblTeamLeader";
            this.lblTeamLeader.Size = new System.Drawing.Size(92, 21);
            this.lblTeamLeader.TabIndex = 84;
            this.lblTeamLeader.Text = "team leader";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(394, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(202, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Project";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSave.Location = new System.Drawing.Point(360, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(300, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "ADD";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtProjectName.Location = new System.Drawing.Point(15, 170);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(300, 29);
            this.txtProjectName.TabIndex = 0;
            this.txtProjectName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.txtProjectName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProjectName.Location = new System.Drawing.Point(15, 145);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(101, 21);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "project name";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCustomer.Location = new System.Drawing.Point(15, 295);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(75, 21);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "customer";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 511);
            this.Controls.Add(this.pnlContainer);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "AddProjectForm";
            this.Text = "AddProject";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlHours.ResumeLayout(false);
            this.pnlHours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbTeamLeader;
        private System.Windows.Forms.Label lblTeamLeader;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Panel pnlHours;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblTotalHours;
    }
}