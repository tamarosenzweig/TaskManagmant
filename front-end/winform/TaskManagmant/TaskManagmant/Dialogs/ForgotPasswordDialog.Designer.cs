namespace TaskManagmant.Dialogs
{
    partial class ForgotPasswordDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.placeHolderTxtEmail = new TaskManagmant.Help.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(47, 165);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(162, 52);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(43, 52);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Forgot password? We\'ll help you \r\nget another one!\r\n";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // placeHolderTxtEmail
            // 
            this.placeHolderTxtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.placeHolderTxtEmail.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTxtEmail.Location = new System.Drawing.Point(47, 115);
            this.placeHolderTxtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.placeHolderTxtEmail.Name = "placeHolderTxtEmail";
            this.placeHolderTxtEmail.PlaceHolderText = null;
            this.placeHolderTxtEmail.Size = new System.Drawing.Size(223, 29);
            this.placeHolderTxtEmail.TabIndex = 2;
            this.placeHolderTxtEmail.Text = "enter your email";
            this.placeHolderTxtEmail.TextChanged += new System.EventHandler(this.placeHolderTextBox1_TextChanged);
            // 
            // ForgotPasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 281);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.placeHolderTxtEmail);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ForgotPasswordDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPasswordDialog";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private Help.PlaceHolderTextBox placeHolderTxtEmail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}