using BOL;
using TaskManagmant.Help;
using TaskManagmant.Services;
using System.Collections.Generic;


namespace TaskManagmant.Forms
{
    public partial class WorkersHoursManagmantForm : BaseForm
    {
        public WorkersHoursManagmantForm()
        {
            InitializeComponent();
            GetAllProjects();
        }

        private void GetAllProjects()
        {
           List<Project> projects = ProjectService.GetProjectsByTeamLeaderId(Global.USER.UserId);
           ProjectsManagmant.GetAllProjects(this, projects,true);
        }
    }
}
