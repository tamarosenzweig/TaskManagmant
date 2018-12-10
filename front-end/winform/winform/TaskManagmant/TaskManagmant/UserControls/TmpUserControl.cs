using System;
using System.Windows.Forms;
using TaskManagmant.Services;
using BOL;
using TaskManagmant.Help;
using TaskManagmant.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagmant.UserControls
{

    public partial class TmpUserControl : UserControl
    {
        User user;

        public TmpUserControl(User user, bool isWorkerList)
        {
            InitializeComponent();
            this.user = user;

            //user profile
            string imageUrl = $"{Global.UPLOADS}/UsersProfiles/";
            if (user.ProfileImageName != null)
                imageUrl += user.ProfileImageName;
            else
                imageUrl += "guest.jpg";
            picUserProfile.Load(imageUrl);
            picUserProfile.BackColor = Color.Transparent;

            //user name
            lblUserName.Text = user.UserName;

            //department
            if (user.Department != null)
                lblDepartment.Text = user.Department.DepartmentName;
            else
                lblDepartment.Text = "Team Leader";

            //buttons
            InitButtons(isWorkerList);

        }

        private void InitButtons(bool isWorkerList)
        {
            if (isWorkerList)
            {
                //add two button
                //1.edit worker
                Button button = new Button();
                button.Name = "btnEdit";
                button.Text = "Edit";
                button.Size = new Size(80, 30);
                button.Location = new Point(30, 35);
                button.Click += EditUser_Click;
                pnlButtons.Controls.Add(button);
                //2.delete worker
                button = new Button();
                button.Name = "btnDelete";
                button.Text = "Delete";
                button.Size = new Size(80, 30);
                button.Location = new Point(170, 35);
                button.Click += DeleteUser_Click;
                pnlButtons.Controls.Add(button);
            }
            else
            {
                Button button = new Button();
                button.Name = "btnTeamManagement";
                button.Text = "Team Management";
                button.Size = new Size(130, 50);
                button.Location = new Point(10, 0);
                button.Click += TeamMangement_Click;
                pnlButtons.Controls.Add(button);
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            bool isConfirm = Global.createDialog(ParentForm, "Delete User", "Are you sure you want to delete?", true);
            if (isConfirm == true)
            {
                //if this user is team-worker and he has incomlete hours we can't delete him
                if (user.TeamLeaderId != null)
                {
                    List<Project> teamProjects = ProjectService.getProjectsByTeamLeaderId((int)user.TeamLeaderId);
                    List<int> teamProjectIdList = teamProjects.Select(project => project.ProjectId).ToList();
                    bool hasUncomletedHours = WorkerHoursService.HasIncomletHours(user.UserId, teamProjectIdList);
                    if (hasUncomletedHours)
                    {
                        MessageBox.Show("Immposible to delete a worker who has incomplete hours");
                    }
                    else
                    {
                        UserService.DeleteUser(user);
                        (ParentForm as UserListForm).InitForm();
                    }
                }
                //if  this user is a team-leader and he has workers or projects we can't delete him
                else
                {
                    bool hasWorkes = UserService.HasWorkes(user.UserId);
                    if (hasWorkes)
                    {
                        MessageBox.Show("Impossible to delete team-leader who has workers");
                        return;
                    }
                    bool hasProjects = ProjectService.HasProjects(user.UserId);
                    if (hasProjects)
                    {
                        MessageBox.Show("Impossible to delete team-leader who has projects");
                        return;
                    }
                    UserService.DeleteUser(user);
                    (ParentForm as UserListForm).InitForm();

                }
            }


        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = ((ParentForm as UserListForm).MdiParent as ManagerForm);
            managerForm.CloseAllForms();
            UserForm userForm = new UserForm(user, managerForm.OpenUserListForm);
            userForm.MdiParent = managerForm;
            userForm.Show();
        }

        private void TeamMangement_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = ((ParentForm as UserListForm).MdiParent as ManagerForm);
            managerForm.CloseAllForms();
            TeamManagementForm teamManagementForm = new TeamManagementForm(user);
            teamManagementForm.MdiParent = managerForm;
            teamManagementForm.Show();
        }

    }
}
