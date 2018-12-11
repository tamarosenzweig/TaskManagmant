using BOL;
using System.Collections.Generic;
using TaskManagmant.Help;
using TaskManagmant.Services;

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
