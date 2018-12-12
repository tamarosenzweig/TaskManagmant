namespace TaskManagmant.Forms
{
    partial class UserForm
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
            this.btnRemoveImg = new System.Windows.Forms.Button();
            this.cmbTeamLeader = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbDepartmentName = new System.Windows.Forms.ComboBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblTeamLeader = new System.Windows.Forms.Label();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.btnUploadImg = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkIsATeamLeader = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.btnRemoveImg);
            this.pnlContainer.Controls.Add(this.cmbTeamLeader);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.cmbDepartmentName);
            this.pnlContainer.Controls.Add(this.lblDepartmentName);
            this.pnlContainer.Controls.Add(this.lblTeamLeader);
            this.pnlContainer.Controls.Add(this.picImg);
            this.pnlContainer.Controls.Add(this.btnUploadImg);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.checkIsATeamLeader);
            this.pnlContainer.Controls.Add(this.txtEmail);
            this.pnlContainer.Controls.Add(this.lblEmail);
            this.pnlContainer.Controls.Add(this.txtConfirmPassword);
            this.pnlContainer.Controls.Add(this.txtPassword);
            this.pnlContainer.Controls.Add(this.txtUserName);
            this.pnlContainer.Controls.Add(this.lblUserName);
            this.pnlContainer.Controls.Add(this.lblPassword);
            this.pnlContainer.Controls.Add(this.lblConfirmPassword);
            this.pnlContainer.Location = new System.Drawing.Point(21, 21);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1020, 410);
            this.pnlContainer.TabIndex = 0;
            // 
            // btnRemoveImg
            // 
            this.btnRemoveImg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRemoveImg.Location = new System.Drawing.Point(705, 354);
            this.btnRemoveImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveImg.Name = "btnRemoveImg";
            this.btnRemoveImg.Size = new System.Drawing.Size(300, 31);
            this.btnRemoveImg.TabIndex = 84;
            this.btnRemoveImg.Text = "remove image";
            this.btnRemoveImg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveImg.UseVisualStyleBackColor = true;
            this.btnRemoveImg.Visible = false;
            this.btnRemoveImg.Click += new System.EventHandler(this.btnRemoveImg_Click);
            // 
            // cmbTeamLeader
            // 
            this.cmbTeamLeader.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbTeamLeader.FormattingEnabled = true;
            this.cmbTeamLeader.Location = new System.Drawing.Point(360, 225);
            this.cmbTeamLeader.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTeamLeader.Name = "cmbTeamLeader";
            this.cmbTeamLeader.Size = new System.Drawing.Size(300, 29);
            this.cmbTeamLeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(394, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add User";
            // 
            // cmbDepartmentName
            // 
            this.cmbDepartmentName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbDepartmentName.FormattingEnabled = true;
            this.cmbDepartmentName.Location = new System.Drawing.Point(360, 150);
            this.cmbDepartmentName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDepartmentName.Name = "cmbDepartmentName";
            this.cmbDepartmentName.Size = new System.Drawing.Size(300, 29);
            this.cmbDepartmentName.TabIndex = 5;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDepartmentName.Location = new System.Drawing.Point(360, 124);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(134, 21);
            this.lblDepartmentName.TabIndex = 0;
            this.lblDepartmentName.Text = "department name";
            // 
            // lblTeamLeader
            // 
            this.lblTeamLeader.AutoSize = true;
            this.lblTeamLeader.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTeamLeader.Location = new System.Drawing.Point(360, 200);
            this.lblTeamLeader.Name = "lblTeamLeader";
            this.lblTeamLeader.Size = new System.Drawing.Size(92, 21);
            this.lblTeamLeader.TabIndex = 0;
            this.lblTeamLeader.Text = "team leader";
            // 
            // picImg
            // 
            this.picImg.Location = new System.Drawing.Point(705, 150);
            this.picImg.Margin = new System.Windows.Forms.Padding(2);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(300, 179);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImg.TabIndex = 83;
            this.picImg.TabStop = false;
            // 
            // btnUploadImg
            // 
            this.btnUploadImg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUploadImg.Location = new System.Drawing.Point(705, 74);
            this.btnUploadImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnUploadImg.Name = "btnUploadImg";
            this.btnUploadImg.Size = new System.Drawing.Size(300, 31);
            this.btnUploadImg.TabIndex = 7;
            this.btnUploadImg.Text = "upload your image";
            this.btnUploadImg.UseVisualStyleBackColor = true;
            this.btnUploadImg.Click += new System.EventHandler(this.UploadImg_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSave.Location = new System.Drawing.Point(360, 354);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(300, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "ADD";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_click);
            // 
            // checkIsATeamLeader
            // 
            this.checkIsATeamLeader.AutoSize = true;
            this.checkIsATeamLeader.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkIsATeamLeader.Location = new System.Drawing.Point(360, 74);
            this.checkIsATeamLeader.Margin = new System.Windows.Forms.Padding(2);
            this.checkIsATeamLeader.Name = "checkIsATeamLeader";
            this.checkIsATeamLeader.Size = new System.Drawing.Size(148, 25);
            this.checkIsATeamLeader.TabIndex = 4;
            this.checkIsATeamLeader.Text = "is A TeamLeader?";
            this.checkIsATeamLeader.UseVisualStyleBackColor = true;
            this.checkIsATeamLeader.CheckedChanged += new System.EventHandler(this.CheckIsATeamLeader_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.Location = new System.Drawing.Point(15, 150);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 29);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.TextChanged += new System.EventHandler(this.Control_TextChanged);
            this.txtEmail.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmail.Location = new System.Drawing.Point(15, 124);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "email";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(15, 300);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(300, 29);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.Control_TextChanged);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(15, 225);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextChanged += new System.EventHandler(this.Control_TextChanged);
            this.txtPassword.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtUserName.Location = new System.Drawing.Point(15, 74);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(300, 29);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.Control_TextChanged);
            this.txtUserName.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblUserName.Location = new System.Drawing.Point(15, 50);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 21);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "user name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPassword.Location = new System.Drawing.Point(15, 200);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 21);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "password";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(15, 275);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(135, 21);
            this.lblConfirmPassword.TabIndex = 0;
            this.lblConfirmPassword.Text = "confirm password";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 441);
            this.Controls.Add(this.pnlContainer);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "UserForm";
            this.ShowInTaskbar = false;
            this.Text = "AddUserForm";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ComboBox cmbTeamLeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbDepartmentName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblTeamLeader;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnUploadImg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkIsATeamLeader;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnRemoveImg;
    }
}