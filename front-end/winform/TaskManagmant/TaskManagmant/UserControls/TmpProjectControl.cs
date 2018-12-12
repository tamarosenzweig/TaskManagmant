using BOL;
using TaskManagmant.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace TaskManagmant.UserControls
{
    public partial class TmpProjectControl : UserControl
    {

        private Project myProject;

        public TmpProjectControl(Project project, bool isTeamLeader)
        {
            InitializeComponent();
            myProject = project;
            lblProjectName.Text = myProject.ProjectName;
            //add departments labels with their hours
            int margin = 30;
            int y = lblProjectName.Location.X + lblProjectName.Height + margin;
            myProject.DepartmentsHours.ForEach(departmentHours =>
            {
                y += margin;
                Label lblDepartment = new Label();
                lblDepartment.Name = $"lbl{departmentHours.Department.DepartmentName}";
                lblDepartment.Text = $"{departmentHours.Department.DepartmentName}: ";


                lblDepartment.Location = new Point(margin, y);
                Controls.Add(lblDepartment);

                Label lblHoursDepartment = new Label();
                lblHoursDepartment.Name = $"lblHours{departmentHours.DepartmentId}";
                lblHoursDepartment.Text = departmentHours.NumHours.ToString(); ;

                lblHoursDepartment.Location = new Point(Width / 2, y);
                Controls.Add(lblHoursDepartment);
            });
            if (isTeamLeader)
            {
                Button btnUpdate = new Button();
                btnUpdate.Text = "update workers hours";
                btnUpdate.Size = new Size(150, 50);
                btnUpdate.Location = new Point((Width - btnUpdate.Width) / 2, 22);
                pnlButtons.Controls.Add(btnUpdate);
                btnUpdate.Click += BtnUpdate_Click;
            }
            else
            {
                Button btnPermission = new Button();
                btnPermission.Text = "add permission to project";
                btnPermission.Size = new Size(150, 50);
                btnPermission.Location = new Point((Width - btnPermission.Width) / 2, 22);
                pnlButtons.Controls.Add(btnPermission);
                btnPermission.Click += BtnPermission_Click;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            TeamLeaderForm teamLeaderForm = ((ParentForm as WorkersHoursManagmantForm).MdiParent as TeamLeaderForm);
            teamLeaderForm.CloseAllForms();
            WorkersHoursForm userForm = new WorkersHoursForm(myProject);
            userForm.MdiParent = teamLeaderForm;
            userForm.Show();
        }

        private void BtnPermission_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = ((ParentForm as PermissionForm).MdiParent as ManagerForm);
            managerForm.CloseAllForms();
            PermissionManagmantForm addPermissionForm = new PermissionManagmantForm(myProject);
            addPermissionForm.MdiParent = managerForm;
            addPermissionForm.Show();
        }
    }
}
