using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TaskManagmant.Help;
using TaskManagmant.Services;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace TaskManagmant.Forms
{
    public partial class ProjectReportForm : BaseForm
    {
        private RadGridView radGridView;

        private List<ReportItem> report;

        private List<Project> projects;

        private List<Project> filteredProjects;

        private Dictionary<string, int> projectFilter;

        private SaveFileDialog saveFileDialog;

        public ProjectReportForm()
        {
            InitializeComponent();
            projects = filteredProjects = ProjectService.GetProjectsReports();
            //remove workers with numHours 0
            projects.ForEach(project =>
                 project.DepartmentsHours.ForEach(departmentHours =>
                    departmentHours.Department.Workers = departmentHours.Department.Workers.Where(worker => worker.WorkerHours[0].NumHours > 0).ToList()
         )
       );
            InitReportList();
            InitRadGridView();
            Controls.Add(radGridView);
            InitFilters();

            btnExport.Location = new Point(Global.SIZE.Width - btnExport.Width - 20, 20);

        }

        private void btnExport_Click(object sender, EventArgs e)
        {      
            if (saveFileDialog == null)
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "*.xlsx|*.xlsx";
                saveFileDialog.FileName = "ProjecReportChildRowsGrouped";
            }
            saveFileDialog.ShowDialog();
            saveFileDialog.FileOk += SaveFileDialog_FileOk;
        }

        private void SaveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridViewSpreadExport gridViewSpreadExport = new GridViewSpreadExport(radGridView);
            gridViewSpreadExport.ChildViewExportMode = ChildViewExportMode.ExportAllViews;
            gridViewSpreadExport.ExportChildRowsGrouped = true;
            gridViewSpreadExport.RunExport(saveFileDialog.FileName, new SpreadExportRenderer());
            string message = "saved successfully!";
            Global.CreateDialog(this, message);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32((sender as ComboBox).SelectedValue);
            if (value == 0)
            {
                projectFilter.Remove((sender as ComboBox).Name);
            }
            else
            {
                projectFilter[(sender as ComboBox).Name] = value;
            }

            filteredProjects = projects;
            if (projectFilter.ContainsKey(cmbMonth.Name))
            {
                int month = projectFilter[cmbMonth.Name];
                filteredProjects = filteredProjects.Where(project => project.StartDate.Month <= month && project.EndDate.Month >= month).ToList();
            }
            if (projectFilter.ContainsKey(cmbWorker.Name))
            {
                int workerId = projectFilter[cmbWorker.Name];
                filteredProjects = filteredProjects.Where(project => project.DepartmentsHours.Any(departmentHours => departmentHours.Department.Workers.Any(worker => worker.UserId == workerId))).ToList();
            }
            if (projectFilter.ContainsKey(cmbTeamLeader.Name))
            {
                int teamLeaderId = projectFilter[cmbTeamLeader.Name];
                filteredProjects = filteredProjects.Where(project => project.TeamLeaderId == teamLeaderId).ToList();
            }
            if (projectFilter.ContainsKey(cmbProject.Name))
            {
                int projectId = projectFilter[cmbProject.Name];
                filteredProjects = filteredProjects.Where(project => project.ProjectId == projectId).ToList();
            }
            InitReportList();
            radGridView.Relations.Clear();
            radGridView.DataSource = report;
            radGridView.Relations.AddSelfReference(radGridView.MasterTemplate, "Id", "ParentId");
        }

        private void InitReportList()
        {
            report = new List<ReportItem>();
            int index = 1;
            filteredProjects.ForEach(project =>
            {
                int projectId = index++;

                int days = Convert.ToInt32(Global.DateDiffInDays(project.StartDate, project.EndDate));
                DateTime date = DateTime.Today;
                if (date > project.EndDate)
                    date = project.EndDate;
                int workedDays = Convert.ToInt32(Global.DateDiffInDays(project.StartDate, date));
                string workedPercent = Global.ToPercent(workedDays / days);
                double projectPresenceHours = Global.ToShortNumber(PresenceHoursService.GetPresenceHoursForProject(project));
                string projectPercentHours = Global.ToPercent(PresenceHoursService.GetPercentHoursForProject(project));
                string status = project.IsComplete ? "Finished!" : project.EndDate <= DateTime.Today ? "Time Over!" : "In Working!";
                report.Add(
                    new ReportItem(
                        projectId,
                        project.ProjectName,
                        project.TeamLeader.UserName,
                        project.TotalHours,
                        projectPresenceHours,
                        projectPercentHours,
                        project.Customer.CustomerName,
                        project.StartDate.ToString("yyyy-MM-dd"),
                        project.EndDate.ToString("yyyy-MM-dd"),
                        days,
                        workedDays,
                        workedPercent,
                        status,
                        0
                    ));
                project.DepartmentsHours.ForEach(departmentHours =>
                {
                    int departmentHoursId = index++;
                    double departmentPresenceHours = Global.ToShortNumber(PresenceHoursService.GetPresenceHoursForDepartment(departmentHours.Department));
                    string departmentPercentHours = departmentHours.NumHours > 0 ? Global.ToPercent(departmentPresenceHours / departmentHours.NumHours) : "-";
                    report.Add(
                        new ReportItem(
                            departmentHoursId,
                            departmentHours.Department.DepartmentName,
                            departmentHours.NumHours,
                            departmentPresenceHours,
                            departmentPercentHours,
                            projectId
                        ));

                    report.AddRange(departmentHours.Department.Workers.Select(worker =>
                    {
                        int workerHours = worker.WorkerHours.Count > 0 ? worker.WorkerHours[0].NumHours : 0;
                        double workerPresenceHours = Global.ToShortNumber(PresenceHoursService.GetPresenceHoursForWorker(worker));
                        string workerPercentHours = workerHours > 0 ? Global.ToPercent(workerPresenceHours / workerHours) : "-";
                        return new ReportItem(
                            index++,
                            worker.UserName,
                            worker.TeamLeader.UserName,
                            workerHours,
                            workerPresenceHours,
                            workerPercentHours,
                            departmentHoursId
                            );
                    }));
                });
            });
        }

        private void InitRadGridView()
        {
            radGridView = new RadGridView();
            radGridView.ReadOnly = true;
            radGridView.AllowDragToGroup = false;
            radGridView.AutoSize = true;
            radGridView.Font = new Font("Segoe UI", 10);
            radGridView.Location = new Point(0, 90);
            radGridView.Relations.AddSelfReference(radGridView.MasterTemplate, "Id", "ParentId");
            radGridView.DataSource = report;
            List<PropertyInfo> ReportItemProps = Type.GetType("TaskManagmant.Help.ReportItem").GetProperties().ToList();
            ReportItemProps.ForEach(property =>
            {
                GridViewTextBoxColumn textBoxColumn = new GridViewTextBoxColumn();
                textBoxColumn.FieldName = property.Name;
                textBoxColumn.HeaderText = property.Name;
                textBoxColumn.TextAlignment = ContentAlignment.MiddleLeft;
                textBoxColumn.Width = Global.SIZE.Width / (ReportItemProps.Count - 2);
                radGridView.MasterTemplate.Columns.Add(textBoxColumn);
            });
            radGridView.Columns["Id"].IsVisible = false;
            radGridView.Columns["ParentId"].IsVisible = false;
        }

        private void InitFilters()
        {
            projectFilter = new Dictionary<string, int>();
            InitMonths();
            InitWorkersAndTeamLeaders();
            InitProjects();
        }

        private void InitMonths()
        {
            List<dynamic> months = new List<dynamic> { new { MonthId = 0, MonthName = string.Empty } };
            for (int i = 0; i < 12; i++)
            {
                string fullMonthName = new DateTime(DateTime.Today.Year, i + 1, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                months.Add(new { MonthId = i + 1, MonthName = fullMonthName });
            }
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "MonthId";
            cmbMonth.DataSource = months;
        }

        private void InitWorkersAndTeamLeaders()
        {
            List<User> users = UserService.GetAllUsers();

            List<User> workers = new List<User> { new User() };
            workers.AddRange(users.Where(worker => worker.TeamLeaderId != null).ToList());
            cmbWorker.DisplayMember = "UserName";
            cmbWorker.ValueMember = "UserId";
            cmbWorker.DataSource = workers;

            List<User> teamLeaders = new List<User> { new User() };
            teamLeaders.AddRange(users.Where(worker => worker.TeamLeaderId == null));
            cmbTeamLeader.DisplayMember = "UserName";
            cmbTeamLeader.ValueMember = "UserId";
            cmbTeamLeader.DataSource = teamLeaders;
        }

        private void InitProjects()
        {
            List<Project> projects = new List<Project> { new Project() };
            projects.AddRange(ProjectService.GetAllProjects());
            cmbProject.DisplayMember = "ProjectName";
            cmbProject.ValueMember = "ProjectId";
            cmbProject.DataSource = projects;
        }

    }

}
