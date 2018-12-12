using BOL;
using TaskManagmant.Help;
using TaskManagmant.Help.Validators;
using TaskManagmant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace TaskManagmant.Dialogs
{
    public partial class NewPasswordDialog : Form
    {
        private User user;

        private Dictionary<string, StringValidator> validators;

        public NewPasswordDialog(User user)
        {
            InitializeComponent();
            this.user = user;
            InitData();
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            validators[(sender as Control).Name].IsTouched = true;
            CheckValidation(sender);
        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            CheckValidation(sender);
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            string hPassword = Global.ComputeHashToSha256(txtPassword.Text);
            string hConfirmPassword = Global.ComputeHashToSha256(txtConfirmPassword.Text);
            user.Password = hPassword;
            user.ConfirmPassword = hConfirmPassword;

            bool edited = UserService.ChangePassword(user);
            if (edited)
            {
                string message = "password was changed succesfully";
                Global.CreateDialog(this, message);
            }
            else
            {
                string message = "edit failed";
                Global.CreateDialog(this, message);
            }
            Close();
        }

        private void InitData()
        {
            validators = new Dictionary<string, StringValidator>();
            validators.Add(txtPassword.Name, new StringValidator("Password", true, 5, 10, @"^\w+$"));
            validators.Add(txtConfirmPassword.Name, new IsMatchStringValidator("Confirm password", true, 5, 10, @"^\w+$", txtPassword, "password"));
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            btnContinue.Enabled = false;
        }

        private void CheckValidation(object sender)
        {
            StringValidator validator = validators[(sender as Control).Name];
            string errorMessage = validator.GetValidationMessage((sender as Control).Text);
            if (validator.IsTouched == true)
            {
                errorProvider.SetError(sender as Control, errorMessage);
            }
            btnContinue.Enabled = !validators.Any(v => v.Value.IsValid == false);
        }

    }
}
