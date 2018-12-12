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
using TaskManagmant.Help;
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
                string message = "Sorry,For safety reasons, you can only try to recover your password in 10 minutes";
                Global.CreateDialog(this, message);
                Close();
                return;
            }
            ChangePassword changePassword = new ChangePassword() { UserId = user.UserId, Token = txtVerificationCode.Text };
            bool confirmed = UserService.ConfirmToken(changePassword);
            if (confirmed)
            {
                //open new password form
                NewPasswordDialog newPasswordDialog = new NewPasswordDialog(user);
                newPasswordDialog.Show();
                Close();
            }
            else
            {
                string message = "Sorry, token is missed!";
                Global.CreateDialog(this, message);
                count++;
            }
        }
    }
}
