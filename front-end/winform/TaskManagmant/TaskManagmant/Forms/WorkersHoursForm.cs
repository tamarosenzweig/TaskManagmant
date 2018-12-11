using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskManagmant.Help;
using TaskManagmant.Services;

namespace TaskManagmant.Forms
{
    public partial class WorkersHoursForm : BaseForm
    {
       private Project myProject;

        public WorkersHoursForm(Project project)
        {
            InitializeComponent();
            myProject = project;
            initData();
        }

        public void UpdateWorkerHours(User worker, DepartmentHours departmentHours)
        {
            string panelName = $"pnl{departmentHours.Department.DepartmentName}";
            string labelName = $"lbl{departmentHours.DepartmentHoursId},{worker.UserId}";
            Controls[panelName].Controls[labelName].Text = worker.WorkerHours[0].NumHours.ToString();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string userName = (sender as Button).Name;
            User selectedWorker = null;
            DepartmentHours myDepartmentHours = myProject.DepartmentsHours.First(departmentHours =>
            {
                selectedWorker = departmentHours.Department.Workers.FirstOrDefault(worker => worker.UserName == userName);
                return selectedWorker != null;
            });
            UpdateHoursDialog updateHoursDialog = new UpdateHoursDialog(selectedWorker, myDepartmentHours);
            updateHoursDialog.ShowDialog(this);

        }

        private void initData()
        {
            lblProjectName.Text = myProject.ProjectName;
            lblTotalHours.Text = myProject.TotalHours.ToString();
            lblWorkersHours.Text = myProject.DepartmentsHours.Sum(departmentHours => departmentHours.Department.Workers.Sum(worker => worker.WorkerHours[0].NumHours)).ToString();
            lblPresence.Text = Global.ToShortNumber(PresenceHoursService.GetPresenceHoursForProject(myProject)).ToString();
            List<Department> departments = DepartmentService.GetAllDepartments();
            int margin = 40;
            int x = margin;
            int y = 110;
            int width = 360;
            int height = 400;
            myProject.DepartmentsHours.ForEach(departmentHours =>
            {
                Department department = departmentHours.Department;
                //panel
                Panel panel = new Panel();
                panel.Name = $"pnl{department.DepartmentName}";
                panel.Location = new Point(x, y);
                panel.Size = new Size(width, height);
                panel.BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(panel);

                //title
                Label title = new Label();
                title.Name = $"lbl{department.DepartmentName}";
                title.Text = $"{department.DepartmentName}: {departmentHours.NumHours}";
                title.AutoSize = true;
                title.Location = new Point((panel.Width - title.Width) / 2, 10);
                panel.Controls.Add(title);

                x += width + margin;
                if (Global.SIZE.Width - x < width + margin)
                {
                    x = margin;
                    y += height + margin;
                }
                int index = 1;
                margin = 30;
                department.Workers.ForEach(worker =>
                {
                    int workerY;

                    Label lblUserName = new Label();
                    lblUserName.Name = $"lbl{worker.UserName}";
                    lblUserName.Text = worker.UserName;
                    lblUserName.Size = new Size(80, 30);
                    workerY = index * (lblUserName.Height + margin) + title.Location.Y + title.Height;
                    lblUserName.Location = new Point(10, workerY);
                    panel.Controls.Add(lblUserName);

                    Label numHours = new Label();
                    numHours.Name = $"lbl{departmentHours.DepartmentHoursId},{worker.UserId}";
                    numHours.Text = worker.WorkerHours[0].NumHours.ToString();
                    numHours.Location = new Point(100, workerY);
                    numHours.Size = new Size(80, 30);
                    panel.Controls.Add(numHours);

                    Label lblPresence = new Label();
                    lblPresence.Name = $"lbl{worker.UserName}";
                    lblPresence.Text = Global.ToShortNumber(worker.PresenceHours.Where(presence => presence.EndHour != null).Sum(presence => Global.DateDiffInHours(presence.StartHour, (DateTime)presence.EndHour))).ToString();
                    lblPresence.Size = new Size(80, 30);
                    workerY = index * (lblPresence.Height + margin) + title.Location.Y + title.Height;
                    lblPresence.Location = new Point(190, workerY);
                    panel.Controls.Add(lblPresence);

                    Button btnEdit = new Button();
                    btnEdit.Name = worker.UserName;
                    btnEdit.Text = "Update";
                    btnEdit.Click += BtnEdit_Click;
                    btnEdit.Size = new Size(80, 30);
                    btnEdit.Location = new Point(280, workerY);
                    panel.Controls.Add(btnEdit);

                    index++;
                });
            });
        }
    }
}


