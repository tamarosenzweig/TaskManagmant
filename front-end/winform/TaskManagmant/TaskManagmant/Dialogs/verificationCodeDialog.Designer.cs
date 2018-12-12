namespace TaskManagmant.Dialogs
{
    partial class VerificationCodeDialog
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.lblVerificationCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(70, 200);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(140, 50);
            this.btnContinue.TabIndex = 12;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(30, 21);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 42);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Verify your account, you got a verification code to your email";
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Location = new System.Drawing.Point(34, 110);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.Size = new System.Drawing.Size(236, 29);
            this.txtVerificationCode.TabIndex = 14;
            // 
            // lblVerificationCode
            // 
            this.lblVerificationCode.AutoSize = true;
            this.lblVerificationCode.Location = new System.Drawing.Point(30, 75);
            this.lblVerificationCode.Name = "lblVerificationCode";
            this.lblVerificationCode.Size = new System.Drawing.Size(131, 21);
            this.lblVerificationCode.TabIndex = 15;
            this.lblVerificationCode.Text = "Verification Code:";
            // 
            // VerificationCodeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 281);
            this.Controls.Add(this.lblVerificationCode);
            this.Controls.Add(this.txtVerificationCode);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnContinue);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VerificationCodeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "verificationCodeFormDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtVerificationCode;
        private System.Windows.Forms.Label lblVerificationCode;
    }
}