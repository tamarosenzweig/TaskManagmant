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
            this.titleGraph = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.projectsGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEmail
            // 
            this.BtnEmail.Location = new System.Drawing.Point(36, 225);
            this.BtnEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnEmail.Name = "BtnEmail";
            this.BtnEmail.Size = new System.Drawing.Size(112, 37);
            this.BtnEmail.TabIndex = 8;
            this.BtnEmail.Text = "Send Email";
            this.BtnEmail.UseVisualStyleBackColor = true;
            this.BtnEmail.Click += new System.EventHandler(this.BtnEmail_Click);
            // 
            // PnlWorkerTaskList
            // 
            this.PnlWorkerTaskList.AutoSize = true;
            this.PnlWorkerTaskList.Location = new System.Drawing.Point(190, 154);
            this.PnlWorkerTaskList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PnlWorkerTaskList.Name = "PnlWorkerTaskList";
            this.PnlWorkerTaskList.Size = new System.Drawing.Size(796, 131);
            this.PnlWorkerTaskList.TabIndex = 7;
            // 
            // titleGraph
            // 
            this.titleGraph.AutoSize = true;
            this.titleGraph.Location = new System.Drawing.Point(463, 317);
            this.titleGraph.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleGraph.Name = "titleGraph";
            this.titleGraph.Size = new System.Drawing.Size(242, 21);
            this.titleGraph.TabIndex = 6;
            this.titleGraph.Text = "Projects Hours vs Presence Hours";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(600, 114);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(105, 21);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "date and time";
            // 
            // projectsGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.projectsGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.projectsGraph.Legends.Add(legend1);
            this.projectsGraph.Location = new System.Drawing.Point(224, 360);
            this.projectsGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectsGraph.Name = "projectsGraph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Presence Hours";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Project Hours";
            this.projectsGraph.Series.Add(series1);
            this.projectsGraph.Series.Add(series2);
            this.projectsGraph.Size = new System.Drawing.Size(752, 254);
            this.projectsGraph.TabIndex = 10;
            this.projectsGraph.Text = "chart1";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(53, 170);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 37);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1263, 100);
            this.pnlHeader.TabIndex = 12;
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 749);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.projectsGraph);
            this.Controls.Add(this.BtnEmail);
            this.Controls.Add(this.PnlWorkerTaskList);
            this.Controls.Add(this.titleGraph);
            this.Controls.Add(this.lblDateTime);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "WorkerForm";
            this.Text = "UserForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.projectsGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEmail;
        private System.Windows.Forms.Panel PnlWorkerTaskList;
        private System.Windows.Forms.Label titleGraph;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart projectsGraph;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
    }
}