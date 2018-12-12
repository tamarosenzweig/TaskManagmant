using BOL;
using TaskManagmant.Help;
using System;
using System.Collections.Generic;
using TaskManagmant.UserControls;
using TaskManagmant.Services;
using System.Windows.Forms;

namespace TaskManagmant.Forms
{
    public partial class ManagerForm : BaseForm
    {
        LoginForm loginForm;

        public ManagerForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;

            IsMdiContainer = true;
            HeaderControl header = new HeaderControl();
            header.Dock = DockStyle.Fill;
            pnlHeader.Controls.Add(header);
        }

        private void AllUsers_Click(object sender, EventArgs e)
        {
            OpenUserListForm(true);
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            UserForm addUserForm = new UserForm(new User(), OpenUserListForm);
            addUserForm.MdiParent = this;
            addUserForm.Show();
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ProjectReportForm projectReportForm = new ProjectReportForm();
            projectReportForm.MdiParent = this;
            projectReportForm.Show();
        }

        private void AddProject_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            AddProjectForm addProject = new AddProjectForm();
            addProject.MdiParent = this;
            addProject.Show();
        }

        private void TeamsManagement_Click(object sender, EventArgs e)
        {
            OpenUserListForm(false);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Global.USER = null;
            Global.UpdateCurrentUser(string.Empty);
            loginForm.Show();
            Close();
        }

        private void permissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPermissionForm();
        }

        private void ManagerForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (Global.USER != null)
                loginForm.Close();
        }

        public void CloseAllForms()
        {
            Array.ForEach(MdiChildren, form => form.Close());
        }

        private void OpenPermissionForm()
        {
            CloseAllForms();
            PermissionForm permissionForm = new PermissionForm();
            permissionForm.MdiParent = this;
            permissionForm.Show();
        }

        public void OpenUserListForm(bool isWorkerList)
        {
            CloseAllForms();
            UserListForm userListForm = new UserListForm(isWorkerList);
            userListForm.MdiParent = this;
            userListForm.Show();
        }
    }
}
