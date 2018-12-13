using BOL;
using TaskManagmant.Dialogs;
using TaskManagmant.Help;
using TaskManagmant.Services;
using TaskManagmant.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace TaskManagmant.Forms
{
    public partial class WorkerForm : BaseForm
    {

        private LoginForm loginForm;

        public WorkerForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;

            //header
            HeaderControl header = new HeaderControl();
            header.Dock = DockStyle.Fill;
            pnlHeader.Controls.Add(header);

            //date and time
            lblDateTime.Location = new Point(0, pnlHeader.Height);
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            //worker task list
            ShowWorkerTasks();

            //buttons
            pnlButtons.Location = new Point((Global.SIZE.Width/4-pnlButtons.Width)/2, lblDateTime.Location.Y + lblDateTime.Height);

            //projects graph
            InitProjectsGraph();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //show current date time
            DateTime datetime = DateTime.Now;
            lblDateTime.Text = datetime.ToString();
        }

        private void EnableWorkerTasks(WorkerTaskControl workerTaskControl, bool enable)
        {
            List<WorkerTaskControl> workerTaskControls = PnlWorkerTaskList.Controls.OfType<WorkerTaskControl>().ToList();
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

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Global.USER = null;
            Global.UpdateCurrentUser(string.Empty);
            loginForm.Show();
            Close();
        }

        private void WorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Global.USER != null)
                loginForm.Close();
        }

        private void ShowWorkerTasks()
        {
            List<WorkerHours> workerHoursList = WorkerHoursService.GetAllWorkerHours();
            int index = 1;
            PnlWorkerTaskList.Size = new Size(Global.SIZE.Width / 2, PnlWorkerTaskList.Height);
            PnlWorkerTaskList.Location = new Point((Global.SIZE.Width - PnlWorkerTaskList.Width) / 2, lblDateTime.Location.Y + lblDateTime.Height);
            int pnlHeight = 125;
            workerHoursList.ForEach(workerHours =>
            {
                WorkerTaskControl workerTaskControl = new WorkerTaskControl(workerHours, EnableWorkerTasks);
                workerTaskControl.Size = new Size(PnlWorkerTaskList.Width, workerTaskControl.Height);
                workerTaskControl.Location = new Point(0, index * workerTaskControl.Height);
                PnlWorkerTaskList.Controls.Add(workerTaskControl);
                pnlHeight += workerTaskControl.Height;
                index++;
            });
            PnlWorkerTaskList.Size = new Size(Global.SIZE.Width / 2, pnlHeight);
        }

        private void InitProjectsGraph()
        {
            List<dynamic> presenceStatusList = PresenceHoursService.GetPresenceStatusPerProjects();
            List<string> projectNameList = presenceStatusList.Select(presenceStatus => (string)presenceStatus.projectName).ToList();
            List<decimal> presenceHoursList = presenceStatusList.Select(presenceStatus => (decimal)presenceStatus.presenceHours).ToList();
            List<int> projectHoursList = presenceStatusList.Select(presenceStatus => (int)presenceStatus.projectHours).ToList();

            projectsGraph.Series["Project Hours"].Points.DataBindXY(projectNameList, projectHoursList);
            projectsGraph.Series["Presence Hours"].Points.DataBindXY(projectNameList, presenceHoursList);

            lblTitleGraph.Location = new Point((Global.SIZE.Width - lblTitleGraph.Width) / 2, PnlWorkerTaskList.Location.Y + PnlWorkerTaskList.Height+lblTitleGraph.Height);
            projectsGraph.Size = new Size(Global.SIZE.Width / 2, Global.SIZE.Height / 3);
            projectsGraph.Location = new Point(0, lblTitleGraph.Location.Y-lblTitleGraph.Height);
        }
    }
}

