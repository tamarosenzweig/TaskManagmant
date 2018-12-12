﻿using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskManagmant.Help;
using TaskManagmant.Services;

namespace TaskManagmant.Forms
{
    public partial class TeamManagementForm : BaseForm
    {
        private User teamLeader;

        private List<User> teamWorkers;

        private List<User> otherWorkers;

        private List<User> selectedWorkers;

        public TeamManagementForm(User teamLeader)
        {
            InitializeComponent();
            this.teamLeader = teamLeader;

            pnlContainer.Location = new Point((ClientSize.Width - pnlContainer.Width) / 2, (ClientSize.Height - pnlContainer.Height) / 2);
            pnlContainer.Anchor = AnchorStyles.None;

            InitData();
        }

        private void cmbOtherWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = (sender as ComboBox).SelectedItem as User;

            if (checkWorkrToTeamValidator(selectedUser.UserId))
            {
                if (selectedWorkers != null && selectedUser != null)
                {
                    selectedWorkers.Add(selectedUser);
                    listSelectedWorkers.Items.Add(selectedUser);

                    otherWorkers.Remove(selectedUser);
                    cmbOtherWorkers.Items.Remove(selectedUser);
                }
            }

        }

        private void listSelectedWorkers_DoubleClick(object sender, EventArgs e)
        {
            User selectedUser = (sender as ListBox).SelectedItem as User;

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
                worker.Department = null;
                worker.Permissions = null;
                worker.TeamLeader = null;
                worker.TeamLeaderId = teamLeader.UserId;
                edited = edited && UserService.EditUser(this,worker);
            });
            if (edited)
                Global.CreateDialog(this, "Saved Successfully!", "Team Management");
            else
                Global.CreateDialog(this, "Saving Failed!", "Team Management");

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

        private bool checkWorkrToTeamValidator(int workerId)
        {
            int teamLeaderOfWorker = (int)otherWorkers.Find(worker => worker.UserId == workerId).TeamLeaderId;
            List<Project> projects = ProjectService.GetProjectsByTeamLeaderId(teamLeaderOfWorker);
            List<int> teamProjectIdList = (List<int>)projects.Select(project => project.ProjectId).ToList();
            bool hasUncomletedHours = WorkerHoursService.HasIncomletHours(workerId, teamProjectIdList);
            if (hasUncomletedHours)
            {
                string message = "Impossible to change the worker\'s team-leader if he has defined hours";
                Global.CreateDialog(this, message);
                return false;
            }
            return true;
        }
    }
}
