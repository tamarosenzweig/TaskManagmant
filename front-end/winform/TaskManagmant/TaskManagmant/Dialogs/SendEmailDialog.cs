using BOL.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagmant.Help;
using TaskManagmant.Services;

namespace TaskManagmant.Dialogs
{
    public partial class SendEmailDialog : Form
    {
        Email email;
        public SendEmailDialog()
        {
            InitializeComponent();
            email = new Email();
        }
        private void _Subject_TextChanged(object sender, EventArgs e)
        {
            email.Subject = (sender as TextBox).Text;
        }

        private void _Body_TextChanged(object sender, EventArgs e)
        {
            email.Body = (sender as RichTextBox).Text;
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            bool created = UserService.SendEmail(email);
            if (created)
            {
                string message = "email sended successfully!";
                Global.CreateDialog(this, message);
            }
            else
            {
                string message = "failure in emailing";
                Global.CreateDialog(this, message);
            }
            Close();
        }

        private void Input_Enter(object sender, EventArgs e)
        {
            TextBoxBase textBox = (sender as TextBoxBase);
            if (textBox.Text == textBox.Name.Substring(1))
                textBox.Text = string.Empty;
        }

        private void Input_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBoxBase).Text == string.Empty)
                (sender as TextBoxBase).Text = (sender as TextBoxBase).Name.Substring(1);
        }
    }
}
