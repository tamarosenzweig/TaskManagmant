using TaskManagmant.Help;
using TaskManagmant.UserControls;
using System;
using System.Windows.Forms;


namespace TaskManagmant.Forms
{
    public partial class TeamLeaderForm : BaseForm
    {

        private LoginForm loginForm;

        public TeamLeaderForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;

            IsMdiContainer = true;
            HeaderControl header = new HeaderControl();
            header.Dock = DockStyle.Fill;
            pnlHeader.Controls.Add(header);
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.USER = null;
            Global.UpdateCurrentUser(string.Empty);
            loginForm.Show();
            Close();
        }

        private void FollowYourProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAllProjectsForm();
        }

        private void TeamWorkerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWorkersHoursForm();
        }

        private void WorkersHoursStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            WorkersHoursStatusForm workersHoursStatusForm = new WorkersHoursStatusForm();
            workersHoursStatusForm.MdiParent = this;
            workersHoursStatusForm.Show();
        }

        private void TeamLeaderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Global.USER != null)
                loginForm.Close();
        }

        private void OpenAllProjectsForm()
        {
            CloseAllForms();
            AllProjectsForm allProjectsForm = new AllProjectsForm();
            allProjectsForm.MdiParent = this;
            allProjectsForm.Show();
        }

        private void OpenWorkersHoursForm()
        {
            CloseAllForms();
            WorkersHoursManagmantForm workersHoursForm = new WorkersHoursManagmantForm();
            workersHoursForm.MdiParent = this;
            workersHoursForm.Show();
        }

        public void CloseAllForms()
        {
            Array.ForEach(MdiChildren, form => form.Close());
        }
    }
}
