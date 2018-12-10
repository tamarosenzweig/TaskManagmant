using System;
using System.Windows.Forms;
using BOL;
using TaskManagmant.Help;
using TaskManagmant.Services;
using System.Drawing;
using System.Threading.Tasks;

namespace TaskManagmant.UserControls
{
    public delegate void EnableWorkerTasksDel(WorkerTaskControl workerTaskControl, bool enable);
    public partial class WorkerTaskControl : UserControl
    {
        WorkerHours workerHours;
        PresenceHours presenceHours;
        EnableWorkerTasksDel EnableWorkerTasksHandle;
        Timer timer;
        TimeSpan time;
        bool isStarted = false;
        decimal presenceSum;
        System.Threading.CancellationTokenSource cancellationTokenSource;
        public WorkerTaskControl(WorkerHours workerHours, EnableWorkerTasksDel EnableWorkerTasksHandle)
        {
            InitializeComponent();
            this.workerHours = workerHours;
            this.EnableWorkerTasksHandle = EnableWorkerTasksHandle;
            lblProjectName.Text = workerHours.Project.ProjectName;
            lblNumHours.Text = workerHours.NumHours.ToString();
            UpdatePresenceSum();
        }

        private void BtnStartOrStop_Click(object sender, EventArgs e)
        {
            BtnTaskClick();
        }

        private void BtnTaskClick()
        {
            //disable/enable other buttons
            EnableWorkerTasksHandle(this, isStarted);
            if (isStarted == false)
            {
                StartTask();
            }
            else
            {
                StopTask();
            }
        }

        private  void StartTask()
        {
            startTimer();
            isStarted = true;
            btnStartOrStop.Text = "Stop Your Task";
            AddPresenceHours();
            int timeout = Convert.ToInt32((workerHours.NumHours - presenceSum) * 60 * 60 * 1000);
            cancellationTokenSource = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationToken ct = cancellationTokenSource.Token;
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(timeout);
                if (ct.IsCancellationRequested==false)
                {
                    BeginInvoke(new Action(() =>
                    {
                        BtnTaskClick();
                        Global.createDialog(ParentForm, "Your task is complete", "You can turn to another task.if you need more time to this task pleas contact your team-leader", false);
                        Enabled = false;
                        BackColor = Color.Gray;
                    }));
                }
               
            }, ct);
         

        }
        private void StopTask()
        {
            timer.Stop();
            isStarted = false;
            btnStartOrStop.Text = "Start Your Task";
            EditPresenceHours();
            cancellationTokenSource.Cancel();
        }
        private void AddPresenceHours()
        {
            DateTime startDate = DateTime.Now;
            presenceHours = new PresenceHours() { WorkerId = workerHours.WorkerId, ProjectId = workerHours.ProjectId, StartHour = startDate };
            presenceHours.PresenceHoursId = PresenceHoursService.AddPresenceHours(presenceHours);

        }
        private void EditPresenceHours()
        {
            presenceHours.EndHour = DateTime.Now;
            PresenceHoursService.EditPresenceHours(presenceHours);
            UpdatePresenceSum();
        }
        private void startTimer()
        {
            timer = new Timer();
            time = new TimeSpan(0, 0, 0);
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            time = time.Add(new TimeSpan(0, 0, 1));

            lblTime.Text = GetTimeFormat(time);
        }
        private string GetTimeFormat(TimeSpan time)
        {
            return $"{AddZeroBefore(time.Hours)}:{AddZeroBefore(time.Minutes)}:{AddZeroBefore(time.Seconds)}";
        }
        private string AddZeroBefore(int number)
        {
            return number < 10 ? $"0{number}" : number.ToString();

        }
        private void UpdatePresenceSum()
        {
            presenceSum = PresenceHoursService.GetPresenceHoursSum(workerHours.ProjectId, workerHours.WorkerId);
            TimeSpan presenceTime = new TimeSpan(0, 0, 0, (int)(presenceSum * 60 * 60));
            lblPresence.Text = GetTimeFormat(presenceTime);
        }
    }
}
