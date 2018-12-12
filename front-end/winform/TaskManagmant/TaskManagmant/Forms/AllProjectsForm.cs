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
            int width = 840;

            SuspendLayout();

            for (int i = 0; projects != null && i < projects.Count; i++)
            {
                ProjectUserControl userControl = new ProjectUserControl(projects[i]); //Textbox to be added
                Controls.Add(userControl);
                userControl.Name = projects[i].ProjectName; //Sets properties
                userControl.Location = new Point(x, y);
                Controls.Add(userControl);

                if (width - x < userControl.Width + marginX)
                {
                    y = y + userControl.Height + marginY;
                    x = marginX;
                }
                else
                {
                    x += userControl.Width + marginX;
                }
            }
            ResumeLayout();
        }
    }
}
