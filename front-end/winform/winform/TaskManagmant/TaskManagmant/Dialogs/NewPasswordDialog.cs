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
using TaskManagmant.Help.Validators;
using TaskManagmant.Services;

namespace TaskManagmant.Dialogs
{
    public partial class NewPasswordDialog : Form
    {
        User user;
        Dictionary<string, StringValidator> validators;
        public NewPasswordDialog(User user)
        {
            InitializeComponent();
            this.user = user;
            init();
        }
        private void init()
        {
            validators = new Dictionary<string, StringValidator>();
            validators.Add(txtPassword.Name, new StringValidator("Password", true, 5, 10, @"^\w+$"));
            validators.Add(txtConfirmPassword.Name, new IsMatchStringValidator("Confirm password", true, 5, 10, @"^\w+$", txtPassword, "password"));
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            StringValidator validator = validators[(sender as Control).Name];
            string errorMessage = validator.GetValidationMessage((sender as Control).Text);
            if (validator.IsTouched == true)
            {
                errorProvider.SetError(sender as Control, errorMessage);
            }
            btnContinue.Enabled = !validators.Any(v => v.Value.IsValid == false);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string hPassword = Global.ComputeHashToSha256(txtPassword.Text);
            string hConfirmPassword = Global.ComputeHashToSha256(txtConfirmPassword.Text);
            user.Password = hPassword;
            user.ConfirmPassword = hConfirmPassword;
     
            bool edited = UserService.ChangePassword(user);
            if (edited)
                MessageBox.Show($"password was changed succesfully");
            else
                MessageBox.Show($"edit failed");
            Close();
        }

    }
}
