using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;
using TaskManagmant.Services;

namespace TaskManagmant.UserControls
{
    public partial class ProjectUserControl : UserControl
    {
       private Project myProject;
        public ProjectUserControl(Project project)
        {
            InitializeComponent();
            this.myProject = project;
            initData();
        }

        private void initData()
        {
            this.projectName.Text += myProject.ProjectName;
            this.totalHours.Text += myProject.TotalHours.ToString();
            this.startDate.Text += myProject.StartDate.ToShortDateString();
            this.endDate.Text += myProject.EndDate.ToShortDateString();
            this.customer.Text += myProject.Customer.CustomerName;
            this.teamLeader.Text += myProject.TeamLeader.UserName;
        }
        
    }
}
