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

        private List<User> permissionList;

        public PermissionManagmantForm(Project project)
        {
            InitializeComponent();
            this.myProject = project;
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
                MessageBox.Show("It is not possible to remove a worker's permission to a project if hours were defined for him to this project");
                return;
            }
            //delete permission
            int permissionId = permission.PermissionId;
            deletedWorkers.Add(permissionId);

            permissionList.Remove(user);

            otherWorkers.Add(user);

            cmbOtherWorkers.Items.Add(user);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedWorkers.Count > 0)
            {
                bool edited = true;
                selectedWorkers.ForEach(permissionToworker =>
                {
                    permissionToworker.WorkerId = permissionToworker.Worker.UserId;
                    permissionToworker.ProjectId = myProject.ProjectId;
                    permissionToworker.Worker = null;
                    edited = edited && PermissionService.AddPermission(permissionToworker);
                });
                if (edited)
                    Global.createDialog(this, "Add Permission", "Saved Successfully!", false);
                else
                    Global.createDialog(this, "Add Permission", "Saving Failed", false);
            }

            if (deletedWorkers.Count > 0)
            {
                bool deleted = true;
                deletedWorkers.ForEach(permissionToworker =>
                {
                    deleted = deleted && PermissionService.DeletePemission(permissionToworker);
                });
                if (deleted)
                    Global.createDialog(this, "Delete Permission", "Saved Successfully!", false);
                else
                    Global.createDialog(this, "Delete Permission", "Saving Failed", false);
            }
            Close();

        }

        private void initData()
        {
            List<User> Allworkers = myProject.DepartmentsHours.SelectMany(departmentHour => departmentHour.Department.Workers).ToList();
            List<User> workers = Allworkers.Where(worker => worker.TeamLeaderId == myProject.TeamLeaderId).ToList();
            permissionList = Allworkers.Where(worker => worker.TeamLeaderId != myProject.TeamLeaderId).ToList();
            otherWorkers = UserService.GetAllUsers().Where(worker => worker.TeamLeaderId != null && !Allworkers.Any(user => user.UserId == worker.UserId)).ToList();

            listProjectWorkers.DataSource = workers;
            listProjectWorkers.DisplayMember = "UserName";

            listPermissionWorkers.DataSource = permissionList;
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
