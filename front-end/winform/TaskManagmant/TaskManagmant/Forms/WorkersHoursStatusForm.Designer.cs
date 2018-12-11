namespace TaskManagmant.Forms
{
    partial class WorkersHoursStatusForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.workersGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblSelectedProject = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workersGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // workersGraph
            // 
            chartArea2.Name = "ChartArea1";
            this.workersGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.workersGraph.Legends.Add(legend2);
            this.workersGraph.Location = new System.Drawing.Point(91, 166);
            this.workersGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workersGraph.Name = "workersGraph";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Worker Hours";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Presence Hours";
            this.workersGraph.Series.Add(series3);
            this.workersGraph.Series.Add(series4);
            this.workersGraph.Size = new System.Drawing.Size(752, 254);
            this.workersGraph.TabIndex = 11;
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(91, 122);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(250, 29);
            this.cmbProjects.TabIndex = 12;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTitle.Location = new System.Drawing.Point(272, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(406, 37);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Projects Hours vs Presence Hours";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(87, 88);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(503, 21);
            this.lblInstruction.TabIndex = 14;
            this.lblInstruction.Text = "to see status of specific project, please select a project from combo-box.";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProject.Location = new System.Drawing.Point(347, 125);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(68, 21);
            this.lblProject.TabIndex = 15;
            this.lblProject.Text = "Project:";
            // 
            // lblSelectedProject
            // 
            this.lblSelectedProject.AutoSize = true;
            this.lblSelectedProject.Location = new System.Drawing.Point(419, 125);
            this.lblSelectedProject.Name = "lblSelectedProject";
            this.lblSelectedProject.Size = new System.Drawing.Size(28, 21);
            this.lblSelectedProject.TabIndex = 16;
            this.lblSelectedProject.Text = "All";
            // 
            // WorkersHoursStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 411);
            this.Controls.Add(this.lblSelectedProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.workersGraph);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "WorkersHoursStatusForm";
            this.Text = "WorkersHoursStatusForm";
            ((System.ComponentModel.ISupportInitialize)(this.workersGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart workersGraph;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblSelectedProject;
    }
}