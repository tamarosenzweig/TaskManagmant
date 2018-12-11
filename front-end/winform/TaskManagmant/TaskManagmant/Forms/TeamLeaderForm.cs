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
using TaskManagmant.UserControls;

namespace TaskManagmant.Forms
{
    public partial class TeamLeaderForm : BaseForm
    {
        LoginForm loginForm;
        public TeamLeaderForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;

            IsMdiContainer = true;
            pnlHeader.Controls.Add(new HeaderControl());
        }
        
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.USER = null;
            Global.UpdateCurrentUser(string.Empty);
            loginForm.Show();
            Close();
        }

        private void followYourProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAllProjectsForm();
        }

        private void teamWorkerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWorkersHoursForm();
        }

        private void OpenAllProjectsForm()
        {
            CloseAllForms();
            AllProjectsForm allProjectsForm = new AllProjectsForm();
            allProjectsForm.MdiParent = this;
            allProjectsForm.Show();
        }

        private void workersHoursStatusToolStripMenuItem_Click(object sender, EventArgs e)
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
