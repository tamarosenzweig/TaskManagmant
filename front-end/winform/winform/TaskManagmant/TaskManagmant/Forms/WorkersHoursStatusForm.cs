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
using TaskManagmant.Services;

namespace TaskManagmant.Forms
{
    public partial class WorkersHoursStatusForm : BaseForm
    {
        List<dynamic> presenceStatusList;

        public WorkersHoursStatusForm()
        {
            InitializeComponent();
            InitWorkersGraph();
        }

        private void InitWorkersGraph()
        {
            presenceStatusList = PresenceHoursService.GetPresenceStatusPerWorkers();
            List<string> projectNameList = presenceStatusList.Select(presenceStatus => (string)presenceStatus.projectName).Distinct().ToList();
            List<Project> projectList = projectNameList.Select(projectName => new Project { ProjectName = projectName}).ToList();
            projectList[0].ProjectName = "All";
            cmbProjects.DataSource = projectList;
            cmbProjects.DisplayMember = "ProjectName";
        }

        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            string projectName = ((sender as ComboBox).SelectedItem as Project).ProjectName;
            lblSelectedProject.Text = projectName;
            InitGraph(projectName);
        }

        private void InitGraph(string projectName)
        {
            string selectedProject = projectName != "All" ? projectName : null;
            List<dynamic> presenceStatusFilterList = presenceStatusList.Where(presenceStatus => presenceStatus.projectName == selectedProject).ToList();
            List<string> workerNameList = presenceStatusFilterList.Select(presenceStatus => (string)presenceStatus.userName).ToList();
            List<decimal> presenceHoursList = presenceStatusFilterList.Select(presenceStatus => (decimal)presenceStatus.presenceHours).ToList();
            List<int> projectHoursList = presenceStatusFilterList.Select(presenceStatus => (int)presenceStatus.projectHours).ToList();

            workersGraph.Series["Worker Hours"].Points.DataBindXY(workerNameList, projectHoursList);
            workersGraph.Series["Presence Hours"].Points.DataBindXY(workerNameList, presenceHoursList);
        }

    }
}
