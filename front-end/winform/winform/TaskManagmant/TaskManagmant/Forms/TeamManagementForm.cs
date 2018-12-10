using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TaskManagmant.Help;
using TaskManagmant.Services;

namespace TaskManagmant.Forms
{
    public partial class TeamManagementForm : Form
    {
        User teamLeader;
        List<User> teamWorkers;
        List<User> otherWorkers;
        List<User> selectedWorkers;

        public TeamManagementForm(User teamLeader)
        {
            InitializeComponent();
            this.teamLeader = teamLeader;
            InitData();
        }

        private void InitData()
        {
            teamWorkers = UserService.GetAllTeamUsers(teamLeader.UserId);
            listTeamWorkers.DataSource = teamWorkers;
            listTeamWorkers.DisplayMember = "UserName";

            otherWorkers = UserService.GetAllUsers().Where(worker => worker.TeamLeaderId != null && worker.TeamLeaderId != teamLeader.UserId).ToList();
            cmbOtherWorkers.Items.AddRange(otherWorkers.ToArray());
            cmbOtherWorkers.DisplayMember = "UserName";

            selectedWorkers = new List<User>();
            listSelectedWorkers.DisplayMember = "UserName";

            cmbOtherWorkers.SelectedIndex = -1;

        }

        private void cmbOtherWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = (sender as ComboBox).SelectedItem as User;

            if (selectedWorkers != null && selectedUser!=null)
            {
                selectedWorkers.Add(selectedUser);
                listSelectedWorkers.Items.Add(selectedUser);

                otherWorkers.Remove(selectedUser);
                cmbOtherWorkers.Items.Remove(selectedUser);
            }
        }

        private void listSelectedWorkers_DoubleClick(object sender, EventArgs e)
        {
            User selectedUser= (sender as ListBox).SelectedItem as User;

            selectedWorkers.Remove(selectedUser);
            listSelectedWorkers.Items.Remove(selectedUser);

            otherWorkers.Add(selectedUser);
            cmbOtherWorkers.Items.Add(selectedUser);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool edited = true;
            selectedWorkers.ForEach(worker =>
            {
                worker.TeamLeaderId = teamLeader.UserId;
               edited=edited&& UserService.EditUser(worker);
            });
            if (edited)
                Global.createDialog(this, "Team Management", "Saved Successfully!", false);
            else
                Global.createDialog(this, "Team Management", "Saving Failed!", false);

        }
    }
}
