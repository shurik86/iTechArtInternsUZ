import { Component, OnInit } from '@angular/core';
import { ChartConfiguration } from 'chart.js';
import { GraphsService } from '../../graphs.service';
import { barAgeDefaultData } from './graph-age-default-data';

@Component({
  selector: 'app-graph-age',
  templateUrl: './graph-age.component.html',
  styleUrls: ['./graph-age.component.scss'],
})
export class GraphAgeComponent implements OnInit {
  public graphAgeData: any;
  public barAgeDefaultData = barAgeDefaultData;
  public barGraphData: ChartConfiguration<'bar'>['data'] | undefined;
  public barGraphLegend = true;
  public barGraphPlugins = [];
  public barGraphOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: false,
  };

  public constructor(private statisticsForGraphsService: GraphsService) {}

  public ngOnInit(): void {
    this.getDataForGraphAge();
  }

  public getDataForGraphAge(): void {
    this.statisticsForGraphsService
      .getStatsForGraphSexAndAge()
      .subscribe((data: any) => {
        this.graphAgeData = data;
        console.log(this.graphAgeData);
        this.barGraphData = this.aggregateGraphAgeData();
      });
  }

  public aggregateGraphAgeData(): ChartConfiguration<'bar'>['data'] {
    const labels: string[] = [];
    const averageAgeMale: number[] = [];
    const averageAgeFemale: number[] = [];

    this.graphAgeData.forEach((element: any) => {
      labels.push(element.unit);
      averageAgeMale.push(element.averageAgeMale);
      averageAgeFemale.push(element.averageAgeFemale);
    });

    return {
      labels: labels,
      datasets: [
        {
          data: averageAgeMale,
          label: 'Average males age',
        },
        {
          data: averageAgeFemale,
          label: 'Average Females age',
        },
      ],
    };
  }
}
