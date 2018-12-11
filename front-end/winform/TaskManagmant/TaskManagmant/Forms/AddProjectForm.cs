using BOL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskManagmant.Help;
using TaskManagmant.Help.Validators;

using TaskManagmant.Services;

namespace TaskManagmant.Forms
{
    public partial class AddProjectForm : BaseForm
    {
       
        private Dictionary<string, IValidator> Validators;

        public AddProjectForm()
        {
            InitializeComponent();
            pnlContainer.Location = new Point((Global.SIZE.Width - pnlContainer.Width) / 2, 20);
            InitData();
            InitControlsValidations();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal totalHours = pnlHours.Controls.OfType<NumericUpDown>().Sum(numericUpDown => numericUpDown.Value);
            lblTotalHours.Text = $"Total Hours: {totalHours}";
            if(totalHours==0)
                errorProvider.SetError(lblTotalHours, "total hours must be greater than 0");
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckStringValidation(sender);
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CheckDateValidation(sender);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            (Validators[(sender as TextBox).Name] as StringValidator).IsTouched = true;
            CheckStringValidation(sender);
        }

        private void DateTimePicker_Leave(object sender, EventArgs e)
        {
            (Validators[(sender as DateTimePicker).Name] as DateValidator).IsTouched = true;
            CheckDateValidation(sender);
        }

        private void CheckStringValidation(object sender)
        {
            TextBox textBox = sender as TextBox;
            StringValidator validator = Validators[textBox.Name] as StringValidator;
            string errorMessage = validator.GetValidationMessage(textBox.Text);
            if (validator.IsTouched == true)
            {
                errorProvider.SetError(textBox, errorMessage);
            }
            BtnEnable();
        }

        private void CheckDateValidation(object sender)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            DateValidator validator = Validators[dateTimePicker.Name] as DateValidator;
            string errorMessage = validator.GetValidationMessage(dateTimePicker.Value);
            if (validator.IsTouched == true)
            {
                errorProvider.SetError(dateTimePicker, errorMessage);
            }
            BtnEnable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Project project = new Project()
            {
                ProjectName = txtProjectName.Text,
                ManagerId = Global.USER.UserId,
                CustomerId = (int)cmbCustomer.SelectedValue,
                TeamLeaderId = (int)cmbTeamLeader.SelectedValue,
                StartDate = dtStartDate.Value,
                EndDate = dtEndDate.Value,
                TotalHours = int.Parse(lblTotalHours.Text.Split(':')[1]),
                DepartmentsHours = new List<DepartmentHours>()
            };
            int index = 0;
            pnlHours.Controls.OfType<NumericUpDown>().ToList().ForEach(numericUpDown =>
            {
                DepartmentHours departmentHours = new DepartmentHours() { NumHours = Convert.ToInt32(numericUpDown.Value), DepartmentId = ++index };
                project.DepartmentsHours.Add(departmentHours);
            });
            bool isCreated = ProjectService.AddProject(project);
            if (isCreated)
            {
                MessageBox.Show($"{project.ProjectName} added succesfully");
                Close();
            }
        }

        private void InitData()
        {
            cmbTeamLeader.DataSource = UserService.GetAllTeamLeaders();
            cmbTeamLeader.DisplayMember = "UserName";
            cmbTeamLeader.ValueMember = "UserId";
            cmbCustomer.DataSource = CustomerService.GetAllCustomers();
            cmbCustomer.DisplayMember = "CustomerName";
            cmbCustomer.ValueMember = "CustomerId";
            List<Department> departments = DepartmentService.GetAllDepartments();
            int y = 50;
            departments.ForEach(department =>
            {
                Label label = new Label();
                label.Name = $"lbl{department.DepartmentName}";
                label.Text = department.DepartmentName;
                label.Location = new Point(0, y);
                pnlHours.Controls.Add(label);

                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Name = $"num{department.DepartmentName}";
                numericUpDown.Size = new Size(300, 30);
                numericUpDown.Location = new Point(0, y + 25);
                numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
                y += 75;
                pnlHours.Controls.Add(numericUpDown);
            });
            lblTotalHours.Location = new Point(0, y);
            btnSave.Enabled = false;
        }

        private void InitControlsValidations()
        {
            Validators = new Dictionary<string, IValidator>
            {
                { txtProjectName.Name, new StringValidator("Project name",true, 2, 15, "^[a-zA-Z0-9]+$") },
                { dtStartDate.Name, new DateValidator("Start date",true) {IsValid=true } },
                { dtEndDate.Name, new DateValidator("End date", true,dtStartDate,"start date") {IsValid=true } }
            };
        }

        private void BtnEnable()
        {
            btnSave.Enabled = !Validators.Any(v =>
                    v.Value is StringValidator ?
                    (v.Value as StringValidator).IsValid == false :
                    (v.Value as DateValidator).IsValid == false);
        }
    }
}
