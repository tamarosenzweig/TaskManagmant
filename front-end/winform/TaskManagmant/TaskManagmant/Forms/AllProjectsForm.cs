using BOL;
using TaskManagmant.Help;
using TaskManagmant.Services;
using TaskManagmant.UserControls;
using System.Collections.Generic;
using System.Drawing;


namespace TaskManagmant.Forms
{
    public partial class AllProjectsForm : BaseForm
    {
        public AllProjectsForm()
        {
            InitializeComponent();
            GetAllProjects();
        }

        private void GetAllProjects()
        {
            List<Project> projects = ProjectService.GetProjectsByTeamLeaderId(Global.USER.UserId);
            int marginX = 100;
            int marginY = 50;
            int x = marginX;
            int y = marginY;

            SuspendLayout();

            for (int i = 0; projects != null && i < projects.Count; i++)
            {
                ProjectUserControl projectControl = new ProjectUserControl(projects[i]); //Textbox to be added
                Controls.Add(projectControl);
                projectControl.Name = projects[i].ProjectName; //Sets properties
                projectControl.Location = new Point(x, y);
                Controls.Add(projectControl);


                if (Global.SIZE.Width - x < (projectControl.Width + marginX) * 2)
                {
                    y = y + projectControl.Height + marginY;
                    x = marginX;
                }
                else
                {
                    x += projectControl.Width + marginX;
                }
            }
            ResumeLayout();
        }
    }
}
