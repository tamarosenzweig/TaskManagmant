namespace TaskManagmant.Forms
{
    partial class WorkerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BtnEmail = new System.Windows.Forms.Button();
            this.PnlWorkerTaskList = new System.Windows.Forms.Panel();
            this.lblPresence = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblNumHours = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblTitleGraph = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.projectsGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.PnlWorkerTaskList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGraph)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEmail
            // 
            this.BtnEmail.Location = new System.Drawing.Point(22, 60);
            this.BtnEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnEmail.Name = "BtnEmail";
            this.BtnEmail.Size = new System.Drawing.Size(206, 37);
            this.BtnEmail.TabIndex = 8;
            this.BtnEmail.Text = "Send Email";
            this.BtnEmail.UseVisualStyleBackColor = true;
            this.BtnEmail.Click += new System.EventHandler(this.BtnEmail_Click);
            // 
            // PnlWorkerTaskList
            // 
            this.PnlWorkerTaskList.AutoSize = true;
            this.PnlWorkerTaskList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlWorkerTaskList.Controls.Add(this.lblPresence);
            this.PnlWorkerTaskList.Controls.Add(this.lblTime);
            this.PnlWorkerTaskList.Controls.Add(this.lblNumHours);
            this.PnlWorkerTaskList.Controls.Add(this.lblProjectName);
            this.PnlWorkerTaskList.Location = new System.Drawing.Point(250, 160);
            this.PnlWorkerTaskList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PnlWorkerTaskList.Name = "PnlWorkerTaskList";
            this.PnlWorkerTaskList.Size = new System.Drawing.Size(721, 125);
            this.PnlWorkerTaskList.TabIndex = 7;
            // 
            // lblPresence
            // 
            this.lblPresence.AutoSize = true;
            this.lblPresence.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresence.Location = new System.Drawing.Point(274, 32);
            this.lblPresence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPresence.Name = "lblPresence";
            this.lblPresence.Size = new System.Drawing.Size(76, 21);
            this.lblPresence.TabIndex = 9;
            this.lblPresence.Text = "Presence";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(600, 30);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(52, 21);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Timer";
            // 
            // lblNumHours
            // 
            this.lblNumHours.AutoSize = true;
            this.lblNumHours.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumHours.Location = new System.Drawing.Point(160, 32);
            this.lblNumHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumHours.Name = "lblNumHours";
            this.lblNumHours.Size = new System.Drawing.Size(89, 21);
            this.lblNumHours.TabIndex = 6;
            this.lblNumHours.Text = "NumHours";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Location = new System.Drawing.Point(30, 32);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(105, 21);
            this.lblProjectName.TabIndex = 5;
            this.lblProjectName.Text = "ProjectName";
            // 
            // lblTitleGraph
            // 
            this.lblTitleGraph.AutoSize = true;
            this.lblTitleGraph.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleGraph.Location = new System.Drawing.Point(279, 290);
            this.lblTitleGraph.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleGraph.Name = "lblTitleGraph";
            this.lblTitleGraph.Size = new System.Drawing.Size(378, 32);
            this.lblTitleGraph.TabIndex = 6;
            this.lblTitleGraph.Text = "Projects Hours vs Presence Hours";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(0, 100);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(984, 60);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "date and time";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // projectsGraph
            // 
            this.projectsGraph.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.projectsGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.projectsGraph.Legends.Add(legend1);
            this.projectsGraph.Location = new System.Drawing.Point(207, 327);
            this.projectsGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectsGraph.Name = "projectsGraph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Project Hours";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Presence Hours";
            this.projectsGraph.Series.Add(series1);
            this.projectsGraph.Series.Add(series2);
            this.projectsGraph.Size = new System.Drawing.Size(559, 222);
            this.projectsGraph.TabIndex = 10;
            this.projectsGraph.Text = "  ";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(22, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(206, 37);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Maroon;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 100);
            this.pnlHeader.TabIndex = 12;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnLogout);
            this.pnlButtons.Controls.Add(this.BtnEmail);
            this.pnlButtons.Location = new System.Drawing.Point(0, 160);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(250, 125);
            this.pnlButtons.TabIndex = 12;
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblTitleGraph);
            this.Controls.Add(this.projectsGraph);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.PnlWorkerTaskList);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "WorkerForm";
            this.Text = "Worker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerForm_FormClosed);
            this.PnlWorkerTaskList.ResumeLayout(false);
            this.PnlWorkerTaskList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGraph)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEmail;
        private System.Windows.Forms.Panel PnlWorkerTaskList;
        private System.Windows.Forms.Label lblTitleGraph;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart projectsGraph;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblPresence;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblNumHours;
        private System.Windows.Forms.Label lblProjectName;
    }
}