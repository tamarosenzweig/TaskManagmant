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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.workersGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblSelectedProject = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.workersGraph)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // workersGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.workersGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.workersGraph.Legends.Add(legend1);
            this.workersGraph.Location = new System.Drawing.Point(187, 161);
            this.workersGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workersGraph.Name = "workersGraph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Worker Hours";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Presence Hours";
            this.workersGraph.Series.Add(series1);
            this.workersGraph.Series.Add(series2);
            this.workersGraph.Size = new System.Drawing.Size(895, 389);
            this.workersGraph.TabIndex = 11;
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(187, 124);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(250, 29);
            this.cmbProjects.TabIndex = 12;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.CmbProjects_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTitle.Location = new System.Drawing.Point(397, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(406, 37);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Projects Hours vs Presence Hours";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(183, 91);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(503, 21);
            this.lblInstruction.TabIndex = 14;
            this.lblInstruction.Text = "to see status of specific project, please select a project from combo-box.";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProject.Location = new System.Drawing.Point(443, 127);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(68, 21);
            this.lblProject.TabIndex = 15;
            this.lblProject.Text = "Project:";
            // 
            // lblSelectedProject
            // 
            this.lblSelectedProject.AutoSize = true;
            this.lblSelectedProject.Location = new System.Drawing.Point(515, 127);
            this.lblSelectedProject.Name = "lblSelectedProject";
            this.lblSelectedProject.Size = new System.Drawing.Size(28, 21);
            this.lblSelectedProject.TabIndex = 16;
            this.lblSelectedProject.Text = "All";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.lblSelectedProject);
            this.pnlContainer.Controls.Add(this.workersGraph);
            this.pnlContainer.Controls.Add(this.lblProject);
            this.pnlContainer.Controls.Add(this.cmbProjects);
            this.pnlContainer.Controls.Add(this.lblInstruction);
            this.pnlContainer.Location = new System.Drawing.Point(32, 30);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1200, 560);
            this.pnlContainer.TabIndex = 17;
            // 
            // WorkersHoursStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 617);
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "WorkersHoursStatusForm";
            this.Text = "WorkersHoursStatusForm";
            ((System.ComponentModel.ISupportInitialize)(this.workersGraph)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart workersGraph;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblSelectedProject;
        private System.Windows.Forms.Panel pnlContainer;
    }
}