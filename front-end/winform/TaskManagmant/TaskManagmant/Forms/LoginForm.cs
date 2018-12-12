using BOL;
using BOL.Help;
using TaskManagmant.Help;
using TaskManagmant.Services;
using TaskManagmant.Help.Validators;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using TaskManagmant.UserControls;
using TaskManagmant.Dialogs;

namespace TaskManagmant.Forms
{
    public partial class LoginForm : BaseForm
    {
        private Dictionary<string, StringValidator> Validators;

        public LoginForm()
        {
            InitializeComponent();
            HeaderControl header = new HeaderControl();
            header.Dock = DockStyle.Fill;
            pnlHeader.Controls.Add(header);

            //locate login form in the middle
            PnlContainer.Location = new Point((Global.SIZE.Width - PnlContainer.Width) / 2, (Global.SIZE.Height - PnlContainer.Height) / 2);

            txtPassword.PasswordChar = '*';
            BtnLogin.Enabled = false;

            InitControlsValidations();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Hide();
            Opacity = 100;

            int currentUserId;
            bool parseSuccess = int.TryParse(System.Configuration.ConfigurationManager.AppSettings["currentUserId"], out currentUserId);
            if (parseSuccess)
            {
                User currentUser = UserService.GetUserById(currentUserId);
                if (currentUser != null)
                {
                    Global.USER = currentUser;
                    OpenSuitableForm(currentUser);
                }
                else
                {
                    Global.UpdateCurrentUser(string.Empty);
                    Show();
                }
            }
            else
                Show();
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            CheckValidation(sender);
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            Validators[(sender as Control).Name].IsTouched = true;
            CheckValidation(sender);
        }

        private void CheckValidation(object sender)
        {
            StringValidator validator = Validators[(sender as Control).Name];
            string errorMessage = validator.GetValidationMessage((sender as Control).Text);
            if (validator.IsTouched == true)
            {
                errorProvider.SetError(sender as Control, errorMessage);
            }
            BtnLogin.Enabled = !Validators.Any(v => v.Value.IsValid == false);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                //hashing password with sha256
                string hashPassword = Global.ComputeHashToSha256(txtPassword.Text);
                Login login = new Login() { Email = txtEmail.Text, Password = hashPassword };
                User user = UserService.Login(login);
                if (user != null)
                {
                    ResetForm();
                    OpenSuitableForm(user);
                }
                else
                {
                    string message = "Email or password is not correct!";
                    Global.CreateDialog(this, message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordDialog forgotPasswordDialog = new ForgotPasswordDialog();
            forgotPasswordDialog.Show();
        }

        private void ResetForm()
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            BtnLogin.Enabled = false;
            errorProvider.Clear();
            InitControlsValidations();
        }

        private void InitControlsValidations()
        {
            string emailPattern = @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$";
            Validators = new Dictionary<string, StringValidator>
            {
                { txtEmail.Name, new StringValidator("Email",true, 15, 30,emailPattern ) },
                {txtPassword.Name, new StringValidator("Password", true, 5, 10, @"^\w+$")}

            };
        }

        private void OpenSuitableForm(User user)
        {
            if (user.ManagerId == null)
            {
                ManagerForm managerForm = new ManagerForm(this);
                managerForm.Show();
                Hide();
                return;
            }
            if (user.TeamLeaderId == null)
            {
                TeamLeaderForm teamLeaderForm = new TeamLeaderForm(this);
                teamLeaderForm.Show();
                Hide();
                return;
            }
            WorkerForm userForm = new WorkerForm(this);
            userForm.Show();
            Hide();
        }

    }
}
