using BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagmant.Services;

namespace TaskManagmant.Dialogs
{
    public partial class VerificationCodeDialog : Form
    {
        User user;
        int count;
        public VerificationCodeDialog(User user)
        {
            InitializeComponent();
            this.user = user;
            count = 0;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if(count==3)
            {
                MessageBox.Show("Sorry,For safety reasons, you can only try to recover your password in 10 minutes");
                Close();
                return;
            }
            ChangePassword changePassword = new ChangePassword() { UserId = user.UserId, Token = placeHolderTextBox1.Text };
            bool confirmed = UserService.ConfirmToken(changePassword);
            if (confirmed)
            {
                //open new password form
                NewPasswordDialog newPasswordDialog = new NewPasswordDialog(user);
                newPasswordDialog.Show();
            }
            else
            {
                MessageBox.Show("Sorry, token is missed!");
                count++;

            }
        }
    }
}
