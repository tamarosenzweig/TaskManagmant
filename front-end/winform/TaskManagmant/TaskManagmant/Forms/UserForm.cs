using System;
using System.Drawing;
using System.Windows.Forms;
using TaskManagmant.Services;
using BOL;
using TaskManagmant.Help;
using System.Collections.Generic;
using System.Linq;
using TaskManagmant.Help.Validators;

namespace TaskManagmant.Forms
{
    public delegate void OpenUserListFormDel(bool isUserList);

    public partial class UserForm : BaseForm
    {
        private User user;

        private bool isToEditUser;

        private Dictionary<string, StringValidator> validators;

        private OpenUserListFormDel openUserListForm;

        private string selectedFile;

        private bool IschangedImage;

        private User oldUser;

        private List<int> teamProjectIdList;

        public UserForm(User user, OpenUserListFormDel openUserListForm)
        {
            InitializeComponent();
            this.user = user;
            oldUser = user;
            isToEditUser = user.UserId != 0;
            this.openUserListForm = openUserListForm;
            pnlContainer.Location = new Point((ClientSize.Width - pnlContainer.Width) / 2, (ClientSize.Height - pnlContainer.Height) / 2);
            pnlContainer.Anchor = AnchorStyles.None;
            InitControlsValidations();
            InitData();
        }

        private void UploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Choose Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg;*.jpeg;*.png";

            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                picImg.Image = Image.FromFile(fileOpen.FileName);
                selectedFile = fileOpen.FileName;
                IschangedImage = true;
                btnRemoveImg.Visible = true;
            }
            fileOpen.Dispose();
        }

        private void btnRemoveImg_Click(object sender, EventArgs e)
        {
            picImg.Image = null;
            selectedFile = null;
            btnRemoveImg.Visible = false;
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            CheckValidation(sender);
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            validators[(sender as Control).Name].IsTouched = true;
            CheckValidation(sender);
        }

        private void CheckValidation(object sender)
        {
            StringValidator validator = validators[(sender as Control).Name];
            string errorMessage = validator.GetValidationMessage((sender as Control).Text);
            if (validator.IsTouched == true)
            {
                errorProvider.SetError(sender as Control, errorMessage);
            }
            btnSave.Enabled = !validators.Any(v => v.Value.IsValid == false);
        }

        private void CheckIsATeamLeader_CheckedChanged(object sender, EventArgs e)
        {
            VisibleComboBoxes((sender as CheckBox).Checked == false);
        }

        private void Save_click(object sender, EventArgs e)
        {
            user.UserName = txtUserName.Text;
            user.Email = txtEmail.Text;
            if (!checkIsATeamLeader.Checked)
            {
                user.DepartmentId = Convert.ToInt32(cmbDepartmentName.SelectedValue);
                user.TeamLeaderId = Convert.ToInt32(cmbTeamLeader.SelectedValue);
            }
            else
            {
                user.TeamLeaderId = null;
                user.DepartmentId = null;
            }
            user.TeamLeader = null;
            user.Department = null;
            if (!isToEditUser)
            {
                string hPassword = Global.ComputeHashToSha256(txtPassword.Text);
                string hConfirmPassword = Global.ComputeHashToSha256(txtConfirmPassword.Text);
                user.Password = hPassword;
                user.ConfirmPassword = hConfirmPassword;
                user.ManagerId = Global.USER.UserId;
                if (selectedFile != null)
                    user.ProfileImageName = UserService.UploadImageProfile(selectedFile);
                bool isCreated = UserService.AddUser(this,user);
                if (isCreated)
                {
                    ShowDialog("Add user", $"{user.UserName} added succesfully");
                }
            }
            else
            {
                //if the user edited from team-leader to team-worker
                if (oldUser.TeamLeaderId == null && user.TeamLeaderId != null)
                {
                    //check if he has workers
                    bool hasWorkers = UserService.HasWorkes(user.UserId);
                    if (hasWorkers)
                    {
                        string message = "It is not possible to change a team-leader to be a worker when he has workers";
                        Global.CreateDialog(this, message);
                        checkIsATeamLeader.Checked = true;
                        user = oldUser;
                        return;
                    }
                    //check if he has projects
                    bool hasProjects = ProjectService.HasProjects(user.UserId);
                    if (hasProjects)
                    {
                        string message = "It is not possible to change a team-leader to be a worker when he has projects";
                        Global.CreateDialog(this, message);
                        checkIsATeamLeader.Checked = true;
                        user = oldUser;
                        return;
                    }
                    return;
                }
                //if the user edited from team-worker to...
                if (oldUser.TeamLeaderId != user.TeamLeaderId && WorkerHoursService.HasIncomletHours(user.UserId, teamProjectIdList))
                {
                    //to team-leader
                    if (user.TeamLeaderId == null)
                    {
                        string message = "It is not possible to change a worker to be a team-team-leader who has hours for the teams project";
                        Global.CreateDialog(this, message);
                        checkIsATeamLeader.Checked = false;
                    }
                    //to difference team
                    else
                    {
                        string message = "It is not possible to move a worker to different team if he has hours for the teams project";
                        Global.CreateDialog(this, message);
                        cmbTeamLeader.SelectedValue = oldUser.TeamLeaderId;
                        user = oldUser;
                        return;
                    }
                }
                // department is changed
                if (oldUser.DepartmentId != user.DepartmentId && WorkerHoursService.HasIncomletHours(user.UserId, teamProjectIdList))
                {
                    string message = "It is not possible to move a department worker if he has incomplete hours";
                    Global.CreateDialog(this, message);
                    cmbDepartmentName.SelectedValue = oldUser.DepartmentId;
                    user = oldUser;
                    return;
                }

                //profile image
                if (user.ProfileImageName != null && IschangedImage)
                {
                    UserService.RemoveUploadedImage(user.ProfileImageName, false);
                }
                if (selectedFile != null)
                {
                    user.ProfileImageName = UserService.UploadImageProfile(selectedFile);
                }

                bool isCreated = UserService.EditUser(this,user);
                if (isCreated)
                {
                    ShowDialog("Edit User", $"{user.UserName} edited succesfully");
                }
            }
        }

        private void InitData()
        {
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            cmbDepartmentName.DataSource = DepartmentService.GetAllDepartments();
            cmbTeamLeader.DataSource = UserService.GetAllTeamLeaders();
            cmbDepartmentName.DisplayMember = "DepartmentName";
            cmbDepartmentName.ValueMember = "DepartmentId";
            cmbTeamLeader.DisplayMember = "UserName";
            cmbTeamLeader.ValueMember = "UserId";
            if (isToEditUser == true)
            {
                oldUser = new User { TeamLeaderId = user.TeamLeaderId, DepartmentId = user.DepartmentId };
                txtEmail.Text = user.Email;
                txtUserName.Text = user.UserName;

                pnlContainer.Controls.Remove(txtPassword);
                pnlContainer.Controls.Remove(txtConfirmPassword);
                pnlContainer.Controls.Remove(lblPassword);
                pnlContainer.Controls.Remove(lblConfirmPassword);

                lblTitle.Text = "Edit User";
                btnSave.Text = "Edit";

                if (user.TeamLeaderId == null)
                {
                    checkIsATeamLeader.Checked = true;
                    List<User> teamLeaders = cmbTeamLeader.DataSource as List<User>;
                    teamLeaders.Remove(teamLeaders.First(u => u.UserId == user.UserId));
                    cmbTeamLeader.DataSource = null;
                    cmbTeamLeader.DataSource = teamLeaders;
                    cmbTeamLeader.DisplayMember = "UserName";
                    cmbTeamLeader.ValueMember = "UserId";
                }
                else
                {
                    cmbDepartmentName.SelectedValue = user.DepartmentId;
                    cmbTeamLeader.SelectedValue = user.TeamLeaderId;
                    List<Project> projects = ProjectService.GetProjectsByTeamLeaderId((int)user.TeamLeaderId);
                    teamProjectIdList = projects.Select(project => project.ProjectId).ToList();
                }
                if (user.ProfileImageName != null)
                    picImg.Load($"{Global.UPLOADS}/UsersProfiles/{user.ProfileImageName}");
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void InitControlsValidations()
        {
            validators = new Dictionary<string, StringValidator>
            {
                { txtUserName.Name, new StringValidator("User name",true, 2, 15, "^[a-zA-Z0-9]+$") },
                { txtEmail.Name, new StringValidator("Email",true, 15, 30, @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$") },
            };
            if (!isToEditUser)
            {
                validators.Add(txtPassword.Name, new StringValidator("Password", true, 5, 10, @"^\w+$"));
                validators.Add(txtConfirmPassword.Name, new IsMatchStringValidator("Confirm password", true, 5, 10, @"^\w+$", txtPassword, "password"));
            }
        }

        private void VisibleComboBoxes(bool isVisible)
        {
            cmbDepartmentName.Visible = isVisible;
            cmbTeamLeader.Visible = isVisible;
            lblDepartmentName.Visible = isVisible;
            lblTeamLeader.Visible = isVisible;
        }

        private void ShowDialog(string title, string msg)
        {
            Global.CreateDialog(this, msg,title);
            Close();
            openUserListForm(true);
        }


    }
}

