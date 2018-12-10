﻿using BOL;
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
    public partial class UpdateHoursDialog : Form
    {
        User myWorker;
        double workerPresence;
        DepartmentHours departmentHours;

        public UpdateHoursDialog(User worker,DepartmentHours departmentHours)
        {
            InitializeComponent();
            myWorker = worker;
            this.departmentHours = departmentHours;
            InitData();
        }

        private void InitData()
        {
            workerPresence = Global.ToShortNumber(myWorker.PresenceHours.Where(presence => presence.EndHour != null).Sum(presence => Global.DateDiffInHours(presence.StartHour, (DateTime)presence.EndHour)));
            lblWorkerName.Text += myWorker.UserName;
            lblPresence.Text += workerPresence.ToString();
            numericHours.Value = myWorker.WorkerHours[0].NumHours;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int editedHours= Convert.ToInt32(numericHours.Value);
            if (editedHours < workerPresence)
            {
                MessageBox.Show("Worker hours can't be less than presence hours");
                numericHours.Value= myWorker.WorkerHours[0].NumHours;
                return;
            }
            int workersHoursSum = departmentHours.Department.Workers.Sum(worker => worker.WorkerHours[0].NumHours);
            //if workers hours sum greater than hours for this department
            if (workersHoursSum- myWorker.WorkerHours[0].NumHours+ editedHours > departmentHours.NumHours)
            {
                MessageBox.Show("Hours defined for workers are greater than the hours defined for this department");
                numericHours.Value = myWorker.WorkerHours[0].NumHours;
                return;
            }
            myWorker.WorkerHours[0].NumHours = editedHours;
            bool edited = WorkerHoursService.EditWorkersHours(myWorker.WorkerHours[0]);
            if (edited)
            {
                Global.createDialog(this, Text, "Edited successfully!!!", false);
                
                (Owner.ActiveMdiChild as WorkersHoursForm).UpdateWorkerHours(myWorker, departmentHours);
                Close();
            }
        }
    }
}
