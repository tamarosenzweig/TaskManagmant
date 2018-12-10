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
using TaskManagmant.Help;
using TaskManagmant.Services;

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
