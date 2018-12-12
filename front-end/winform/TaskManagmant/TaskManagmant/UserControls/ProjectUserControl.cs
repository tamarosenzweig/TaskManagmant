using BOL;
using TaskManagmant.Services;
using System.Windows.Forms;


namespace TaskManagmant.UserControls
{
    public partial class ProjectUserControl : UserControl
    {

       private Project myProject;

        public ProjectUserControl(Project project)
        {
            InitializeComponent();
            myProject = project;
            InitData();
        }

        private void InitData()
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
