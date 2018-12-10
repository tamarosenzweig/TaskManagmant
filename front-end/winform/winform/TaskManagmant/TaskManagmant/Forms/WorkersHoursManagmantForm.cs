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
using TaskManagmant.UserControls;

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
           List<Project> projects = ProjectService.getProjectsByTeamLeaderId(Global.USER.UserId);
           ProjectsManagmant.GetAllProjects(this, projects,true);
        }

    }
}
