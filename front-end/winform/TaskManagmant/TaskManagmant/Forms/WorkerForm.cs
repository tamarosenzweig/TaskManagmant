using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using TaskManagmant.Dialogs;
using TaskManagmant.Help;
using TaskManagmant.Services;
using TaskManagmant.UserControls;

namespace TaskManagmant.Forms
{
    public partial class WorkerForm : BaseForm
    {
        LoginForm loginForm;
        public WorkerForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;

            pnlHeader.Controls.Add(new HeaderControl());

            timer1.Tick += timer1_Tick;
            timer1.Start();
            ShowWorkerTasks();
            InitProjectsGraph();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //show current date time
            DateTime datetime = DateTime.Now;
            lblDateTime.Text = datetime.ToString();
        }

        private void EnableWorkerTasks(WorkerTaskControl workerTaskControl, bool enable)
        {
            List<WorkerTaskControl> workerTaskControls = PnlWorkerTaskList.Controls.Cast<WorkerTaskControl>().ToList();
            workerTaskControls.ForEach(control =>
            {
                (control.Controls["BtnStartOrStop"] as Button).Enabled = enable;
            });
            (workerTaskControl.Controls["BtnStartOrStop"] as Button).Enabled = true;
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            SendEmailDialog sendEmailDialog = new SendEmailDialog();
            sendEmailDialog.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Global.USER = null;
            Global.UpdateCurrentUser(string.Empty);
            loginForm.Show();
            Close();
        }

        private void WorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Global.USER!=null)
            loginForm.Close();
        }

        private void InitProjectsGraph()
        {
            List<dynamic> presenceStatusList = PresenceHoursService.GetPresenceStatusPerProjects();
            List<string> projectNameList = presenceStatusList.Select(presenceStatus => (string)presenceStatus.projectName).ToList();
            List<decimal> presenceHoursList = presenceStatusList.Select(presenceStatus => (decimal)presenceStatus.presenceHours).ToList();
            List<int> projectHoursList = presenceStatusList.Select(presenceStatus => (int)presenceStatus.projectHours).ToList();

            projectsGraph.Series["Presence Hours"].Points.DataBindXY(projectNameList, presenceHoursList);
            projectsGraph.Series["Project Hours"].Points.DataBindXY(projectNameList, projectHoursList);

            projectsGraph.Location = new Point((Width - projectsGraph.Width) / 2, PnlWorkerTaskList.Location.Y + PnlWorkerTaskList.Height + 20);
        }

        private void ShowWorkerTasks()
        {
            List<WorkerHours> workerHoursList = WorkerHoursService.GetAllWorkerHours();
            int index = 0;
            workerHoursList.ForEach(workerHours =>
            {
                WorkerTaskControl workerTaskControl = new WorkerTaskControl(workerHours, EnableWorkerTasks);
                workerTaskControl.Location = new Point(0, index * workerTaskControl.Height);
                PnlWorkerTaskList.Controls.Add(workerTaskControl);
                index++;
            });
            PnlWorkerTaskList.Location = new Point((Width - PnlWorkerTaskList.Width) / 2, 150);
        }

    }
}

