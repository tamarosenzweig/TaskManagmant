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
    public partial class PermissionManagmantForm : BaseForm
    {
        private Project myProject;

        private List<Permission> selectedWorkers;

        private List<int> deletedWorkers;

        private List<User> otherWorkers;

        private List<User> workersWithPermissions;

        public PermissionManagmantForm(Project project)
        {
            InitializeComponent();

            pnlContainer.Location = new Point((ClientSize.Width - pnlContainer.Width) / 2, (ClientSize.Height - pnlContainer.Height) / 2);
            pnlContainer.Anchor = AnchorStyles.None;

            myProject = project;
            initData();
        }

        private void cmbOtherWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = (sender as ComboBox).SelectedItem as User;
            Permission permission = new Permission()
            {
                Worker = selectedUser,
                ProjectId = myProject.ProjectId
            };

            if (selectedWorkers != null && selectedUser != null)
            {
                selectedWorkers.Add(permission);
                listSelectedWorkers.Items.Add(selectedUser);

                otherWorkers.Remove(selectedUser);
                cmbOtherWorkers.Items.Remove(selectedUser);
            }
        }

        private void listSelectedWorkers_DoubleClick(object sender, EventArgs e)
        {
            User user = (sender as ListBox).SelectedItem as User;
            selectedWorkers.RemoveAll(x => x.WorkerId == user.UserId);
            listSelectedWorkers.Items.Remove(user);

            otherWorkers.Add(user);
            cmbOtherWorkers.Items.Add(user);
        }

        private void listPermissionWorkers_DoubleClick(object sender, EventArgs e)
        {
            User user = (sender as ListBox).SelectedItem as User;
            Permission permission = user.Permissions.First(p => p.ProjectId == myProject.ProjectId);
            if (WorkerHoursService.HasIncomletHours(user.UserId, new List<int> { permission.ProjectId }))
            {
                string message = "It is not possible to remove a worker's permission to a project if hours were defined for him to this project";
                Global.CreateDialog(this,message);
                return;
            }
            //delete permission
            int permissionId = permission.PermissionId;
            deletedWorkers.Add(permissionId);

            workersWithPermissions.Remove(user);
            listPermissionWorkers.DataSource = null;
            listPermissionWorkers.DataSource = workersWithPermissions;
            listProjectWorkers.DisplayMember = "UserName";

            otherWorkers.Add(user);
            cmbOtherWorkers.Items.Add(user);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedWorkers.Count > 0)
            {
                bool created = true;
                selectedWorkers.ForEach(permissionToworker =>
                {
                    permissionToworker.WorkerId = permissionToworker.Worker.UserId;
                    permissionToworker.ProjectId = myProject.ProjectId;
                    permissionToworker.Worker = null;
                    created = created && PermissionService.AddPermission(permissionToworker);
                });
                if (created)
                    Global.CreateDialog(this, "Saved Successfully!", "Add Permission");
                else
                    Global.CreateDialog(this, "Saving Failed", "Add Permission");
            }

            if (deletedWorkers.Count > 0)
            {
                bool deleted = true;
                deletedWorkers.ForEach(permissionToworker =>
                {
                    deleted = deleted && PermissionService.DeletePemission(permissionToworker);
                });
                if (deleted)
                    Global.CreateDialog(this, "Saved Successfully!", "Delete Permission");
                else
                    Global.CreateDialog(this, "Saving Failed", "Delete Permission");
            }
            Close();

        }

        private void initData()
        {
            List<User> Allworkers = myProject.DepartmentsHours.SelectMany(departmentHour => departmentHour.Department.Workers).ToList();
            List<User> workers = Allworkers.Where(worker => worker.TeamLeaderId == myProject.TeamLeaderId).ToList();
            workersWithPermissions = Allworkers.Where(worker => worker.TeamLeaderId != myProject.TeamLeaderId).ToList();
            otherWorkers = UserService.GetAllUsers().Where(worker => worker.TeamLeaderId != null && !Allworkers.Any(user => user.UserId == worker.UserId)).ToList();

            List<User> workersWithDeletedPermission = workersWithPermissions.Where(worker => worker.Permissions.FirstOrDefault(p => p.ProjectId == myProject.ProjectId) == null || worker.Permissions.First(p => p.ProjectId == myProject.ProjectId).IsActive == false).ToList();
            workersWithDeletedPermission.ForEach(worker =>
            {
                workersWithPermissions.Remove(worker);
            });
            otherWorkers.AddRange(workersWithDeletedPermission);


            listProjectWorkers.DataSource = workers;
            listProjectWorkers.DisplayMember = "UserName";

            listPermissionWorkers.DataSource = workersWithPermissions;
            listProjectWorkers.DisplayMember = "UserName";

            cmbOtherWorkers.Items.AddRange(otherWorkers.ToArray());
            cmbOtherWorkers.DisplayMember = "UserName";

            selectedWorkers = new List<Permission>();
            deletedWorkers = new List<int>();
            listSelectedWorkers.DisplayMember = "UserName";
            listPermissionWorkers.DisplayMember = "UserName";

            cmbOtherWorkers.SelectedIndex = -1;
        }
    }
}
