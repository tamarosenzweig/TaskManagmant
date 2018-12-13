using BOL;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskManagmant.UserControls;

namespace TaskManagmant.Help
{
    public class ProjectsManagmant
    {
        public static void GetAllProjects(Form form, List<Project> projects, bool isTeamLeader)
        {
            form.Controls.Clear();
            int marginX = 100;
            int marginY = 50;
            int x = marginX;
            int y = marginY;
            form.SuspendLayout();
            for (int i = 0; projects != null && i < projects.Count; i++)
            {
                TmpProjectControl tmpProjectControl = new TmpProjectControl(projects[i], isTeamLeader); //Textbox to be added
                form.Controls.Add(tmpProjectControl);
                tmpProjectControl.Name = projects[i].ProjectName; //Sets properties
                tmpProjectControl.Location = new Point(x, y);
                tmpProjectControl.Visible = true;
                form.Controls.Add(tmpProjectControl);

                if (Global.SIZE.Width - x < (tmpProjectControl.Width + marginX) * 2)
                {
                    y = y + tmpProjectControl.Height + marginY;
                    x = marginX;
                }
                else
                {
                    x += tmpProjectControl.Width + marginX;
                }
            }
            form.ResumeLayout();
        }
    }
}
