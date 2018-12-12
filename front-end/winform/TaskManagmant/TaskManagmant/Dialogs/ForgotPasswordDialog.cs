﻿using BOL;
using TaskManagmant.Help;
using TaskManagmant.Help.Validators;
using TaskManagmant.Services;
using System;
using System.Windows.Forms;


namespace TaskManagmant.Dialogs
{
    public partial class ForgotPasswordDialog : Form
    {
        private string email;

        private StringValidator emailValidator;

        public ForgotPasswordDialog()
        {
            InitializeComponent();
            InitData();
        }

        private void txtEamil_TextChanged(object sender, EventArgs e)
        {
            string errorMessage = emailValidator.GetValidationMessage(txtEamil.Text);
            errorProvider.SetError(sender as Control, errorMessage);
            btnContinue.Enabled = emailValidator.IsValid;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                bool isExist;
                email = txtEamil.Text;
                User user = UserService.GetUserByEmail(email);
                if (user == null)
                {
                    string message = "Username doesn't exist!";
                    Global.CreateDialog(this, message);
                    return;
                }
                isExist = UserService.ForgotPassword(email);
                if (isExist)
                {
                    //open verification code form dialog
                    VerificationCodeDialog verificationCodeFormDialog = new VerificationCodeDialog(user);
                    verificationCodeFormDialog.Show();
                }
                else
                {
                    string message = "Sorry,For safety reasons, you can only try to recover your password in 10 minutes";
                    Global.CreateDialog(this, message);
                    Close();
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitData()
        {
            email = "";
            emailValidator = new StringValidator("Email", true, 15, 30, @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
        }
    }
}
