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
            this.pnlContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGraph)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEmail
            // 
            this.BtnEmail.Location = new System.Drawing.Point(21, 131);
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
            this.PnlWorkerTaskList.Location = new System.Drawing.Point(237, 77);
            this.PnlWorkerTaskList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PnlWorkerTaskList.Name = "PnlWorkerTaskList";
            this.PnlWorkerTaskList.Size = new System.Drawing.Size(1066, 280);
            this.PnlWorkerTaskList.TabIndex = 7;
            // 
            // titleGraph
            // 
            this.titleGraph.AutoSize = true;
            this.titleGraph.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleGraph.Location = new System.Drawing.Point(578, 379);
            this.titleGraph.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleGraph.Name = "titleGraph";
            this.titleGraph.Size = new System.Drawing.Size(378, 32);
            this.titleGraph.TabIndex = 6;
            this.titleGraph.Text = "Projects Hours vs Presence Hours";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(0, 7);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(1535, 61);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "date and time";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // projectsGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.projectsGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.projectsGraph.Legends.Add(legend1);
            this.projectsGraph.Location = new System.Drawing.Point(237, 426);
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
            this.projectsGraph.Size = new System.Drawing.Size(1066, 386);
            this.projectsGraph.TabIndex = 10;
            this.projectsGraph.Text = "  ";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(21, 77);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(206, 37);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1584, 100);
            this.pnlHeader.TabIndex = 12;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.lblDateTime);
            this.pnlContainer.Controls.Add(this.titleGraph);
            this.pnlContainer.Controls.Add(this.btnLogout);
            this.pnlContainer.Controls.Add(this.PnlWorkerTaskList);
            this.pnlContainer.Controls.Add(this.projectsGraph);
            this.pnlContainer.Controls.Add(this.BtnEmail);
            this.pnlContainer.Location = new System.Drawing.Point(20, 99);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1540, 840);
            this.pnlContainer.TabIndex = 13;
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 961);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "WorkerForm";
            this.Text = "Worker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.projectsGraph)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnlContainer;
    }
}