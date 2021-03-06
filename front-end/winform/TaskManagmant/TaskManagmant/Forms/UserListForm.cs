﻿using BOL;
using TaskManagmant.Help;
using TaskManagmant.Services;
using TaskManagmant.UserControls;
using System.Collections.Generic;
using System.Drawing;


namespace TaskManagmant.Forms
{
    public partial class UserListForm : BaseForm
    {

        private List<User> users;

        private bool isWorkerList;

        public UserListForm(bool isWorkerList)
        {
            InitializeComponent();
            this.isWorkerList = isWorkerList;
            InitForm();
        }

        public void InitForm()
        {
            InitUsers();
            InitUserControls();
        }

        private void InitUsers()
        {
            if (isWorkerList)
                users = UserService.GetAllUsers();
            else
                users = UserService.GetAllTeamLeaders();
        }

        private void InitUserControls()
        {
            Controls.Clear();
            int marginX = 25;
            int marginY = 20;
            int x = marginX;
            int y = marginY;
            for (int i = 0; users != null && i < users.Count; i++)
            {
                TmpUserControl tmpUserControl = new TmpUserControl(users[i], isWorkerList);
                tmpUserControl.Parent = this;
                tmpUserControl.Name = users[i].UserName;
                tmpUserControl.Location = new Point(x, y);

                if (Global.SIZE.Width - x < (tmpUserControl.Width + marginX)*2)
                {
                    y = y + tmpUserControl.Height + marginY;
                    x = marginX;
                }
                else
                {
                    x += tmpUserControl.Width + marginX;
                }
                Controls.Add(tmpUserControl);
            }
        }
    }
}
