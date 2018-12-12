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
            myProject = project;
            initData();
        }

        private void initData()
        {
            lblProjectName.Text = myProject.ProjectName;
            lblDonePrecents1.Text = $"{PresenceHoursService.GetPercentHoursForProject(myProject)}%";
            lblCustomer1.Text = myProject.Customer.CustomerName;
            lblStartDate1.Text = myProject.StartDate.ToShortDateString();
            lblEndDate1.Text = myProject.EndDate.ToShortDateString();
            lblTotalHours1.Text = $"{myProject.TotalHours} hours";
            double presenceHours= PresenceHoursService.GetPresenceHoursForProject(myProject);
            lblWorkedHours1.Text = $"{presenceHours} hours";
            lblNeedsHours1.Text = $"{(myProject.TotalHours - presenceHours)} hours";
        }
        
    }
}
