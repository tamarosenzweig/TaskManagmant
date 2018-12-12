namespace TaskManagmant.Dialogs
{
    partial class SendEmailDialog
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
            this._Subject = new System.Windows.Forms.TextBox();
            this._Body = new System.Windows.Forms.RichTextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _Subject
            // 
            this._Subject.Location = new System.Drawing.Point(26, 27);
            this._Subject.Name = "_Subject";
            this._Subject.Size = new System.Drawing.Size(229, 20);
            this._Subject.TabIndex = 0;
            this._Subject.Text = "Subject";
            this._Subject.TextChanged += new System.EventHandler(this.Subject_TextChanged);
            this._Subject.Enter += new System.EventHandler(this.Input_Enter);
            this._Subject.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // _Body
            // 
            this._Body.Location = new System.Drawing.Point(26, 54);
            this._Body.Name = "_Body";
            this._Body.Size = new System.Drawing.Size(229, 156);
            this._Body.TabIndex = 1;
            this._Body.Text = "Body";
            this._Body.TextChanged += new System.EventHandler(this.Body_TextChanged);
            this._Body.Enter += new System.EventHandler(this.Input_Enter);
            this._Body.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(26, 217);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(229, 32);
            this.BtnSend.TabIndex = 2;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // SendEmailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this._Body);
            this.Controls.Add(this._Subject);
            this.Name = "SendEmailDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _Subject;
        private System.Windows.Forms.RichTextBox _Body;
        private System.Windows.Forms.Button BtnSend;
    }
}