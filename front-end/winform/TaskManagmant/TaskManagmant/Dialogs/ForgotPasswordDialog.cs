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
using TaskManagmant.Help.Validators;
using TaskManagmant.Services;

namespace TaskManagmant.Dialogs
{
    public partial class ForgotPasswordDialog : Form
    {
        string email;
        StringValidator emailValidator;

        public ForgotPasswordDialog()
        {
            InitializeComponent();
            InitData();
            placeHolderTxtEmail.TabStop = true;
        }

        private void InitData()
        {
            email = "";
           emailValidator = new StringValidator("Email", true, 15, 30, @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
        }

        private void placeHolderTextBox1_TextChanged(object sender, EventArgs e)
        {
            string errorMessage = emailValidator.GetValidationMessage(placeHolderTxtEmail.Text);
            if (emailValidator.IsTouched == true)
            {
                errorProvider.SetError(sender as Control, errorMessage);
            }
            btnContinue.Enabled = emailValidator.IsValid;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                bool isExist;
                email = placeHolderTxtEmail.Text;
                User user = UserService.GetUserByEmail(email);
                if(user==null)
                {
                    MessageBox.Show("Username doesn't exist!");
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
                    MessageBox.Show("Sorry,For safety reasons, you can only try to recover your password in 10 minutes");
                    Close();
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
