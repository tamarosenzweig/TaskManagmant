using BOL;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskManagmant.UserControls;

namespace TaskManagmant.Help
{
    public class ProjectsManagmant
    {
        public static void GetAllProjects(Form form, List<Project> projects,bool isTeamLeader)
        {
            form.Controls.Clear();
            int marginX = 100;
            int marginY = 50;
            int x = marginX;
            int y = marginY;
            int width = 1000;
            form.SuspendLayout();
            for (int i = 0; projects != null && i < projects.Count; i++)
            {
                TmpProjectControl userControl = new TmpProjectControl(projects[i],isTeamLeader); //Textbox to be added
                form.Controls.Add(userControl);
                userControl.Name = projects[i].ProjectName; //Sets properties
                userControl.Location = new Point(x, y);
                userControl.Visible = true;
                form.Controls.Add(userControl);

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
            form.ResumeLayout();
        }
    }
}
