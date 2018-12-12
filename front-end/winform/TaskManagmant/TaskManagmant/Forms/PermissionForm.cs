using BOL;
using TaskManagmant.Help;
using TaskManagmant.Services;
using System.Collections.Generic;


namespace TaskManagmant.Forms
{
    public partial class PermissionForm : BaseForm
    {
        public PermissionForm()
        {
            InitializeComponent();
            GetAllProjects();
        }

        private void GetAllProjects()
        {
            List<Project> projects = ProjectService.GetProjectsReports();
            ProjectsManagmant.GetAllProjects(this, projects,false);
        }
    }
}
