namespace TaskManagmant.Dialogs
{
    partial class NewPasswordDialog
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.txtPassword = new TaskManagmant.Help.PlaceHolderTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new TaskManagmant.Help.PlaceHolderTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(36, 201);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(141, 50);
            this.btnContinue.TabIndex = 15;
            this.btnContinue.Text = "Finish";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(36, 114);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceHolderText = null;
            this.txtPassword.Size = new System.Drawing.Size(194, 20);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.Text = "enter your new password\r\n";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(32, 54);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(241, 42);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Forgot password? We\'ll help you \r\nget another one!\r\n";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtConfirmPassword.Location = new System.Drawing.Point(36, 150);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PlaceHolderText = null;
            this.txtConfirmPassword.Size = new System.Drawing.Size(194, 20);
            this.txtConfirmPassword.TabIndex = 16;
            this.txtConfirmPassword.Text = "confirm your new password";
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // NewPasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 281);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NewPasswordDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPasswordDialog";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private Help.PlaceHolderTextBox txtPassword;
        private System.Windows.Forms.Label lblTitle;
        private Help.PlaceHolderTextBox txtConfirmPassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}