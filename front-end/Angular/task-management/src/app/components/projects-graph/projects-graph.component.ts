import { Component, OnInit } from '@angular/core';
import * as CanvasJS from '../../../assets/js/canvasjs.min';
import { PresenceHoursService, User } from '../../imports';
import { Global } from '../../shared/global';

@Component({
  selector: 'app-projects-graph',
  templateUrl: './projects-graph.component.html',
  styleUrls: ['./projects-graph.component.css']
})
export class ProjectsGraphComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  projectHours: { label: string, y: number }[];
  presenceHours: { label: string, y: number }[];

  //----------------CONSTRUCTOR------------------

  constructor(private presenceHoursService: PresenceHoursService) { }

  //----------------METHODS-------------------

  async ngOnInit() {
    await this.getPresenceStatusPerProjects();
    this.renderChart();
  }

  async getPresenceStatusPerProjects() {
    let workerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;

    let data = await this.presenceHoursService.getPresenceStatusPerProjects(workerId);

    // init projectHours
    this.projectHours = data.map(d => {
      return { label: d.projectName, y: d.projectHours };
    });
    
    // init presenceHours
    this.presenceHours = data.map(d => {
      return { label: d.projectName, y: d.presenceHours };
    });
  }
  renderChart() {
    let chart = new CanvasJS.Chart("chartContainer", {
      exportEnabled: true,
      animationEnabled: true,
      title: {
        text: "Projects Hours vs Presence Hours"
      },
      subtitles: [{
        text: "Click Legend to Hide or Unhide Data Series"
      }],
      axisX: {
        title: "Projects"
      },
      axisY: {
        title: "Projects Hours",
        titleFontColor: "#4F81BC",
        lineColor: "#4F81BC",
        labelFontColor: "#4F81BC",
        tickColor: "#4F81BC"
      },
      axisY2: {
        title: "Presence Hours",
        titleFontColor: "#C0504E",
        lineColor: "#C0504E",
        labelFontColor: "#C0504E",
        tickColor: "#C0504E"
      },
      toolTip: {
        shared: true
      },
      legend: {
        cursor: "pointer",
        itemclick: this.toggleDataSeries
      },
      data: [{
        type: "column",
        name: "Project Hours",
        showInLegend: true,
        yValueFormatString: "#,##0.# Units",
        dataPoints: this.projectHours
      },
      {
        type: "column",
        name: "Presence Hours",
        axisYType: "secondary",
        showInLegend: true,
        yValueFormatString: "#,##0.# Units",
        dataPoints: this.presenceHours
      }]
    });
    chart.render();
  }
  
  toggleDataSeries(e) {
    if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
      e.dataSeries.visible = false;
    } else {
      e.dataSeries.visible = true;
    }
    e.chart.render();
  }
}
