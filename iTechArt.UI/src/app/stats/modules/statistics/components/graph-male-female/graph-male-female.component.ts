import { Component, OnInit } from '@angular/core';
import { ChartConfiguration } from 'chart.js';

import { GraphsService } from '../../graphs.service';
import { barGraphSexDefaultData } from "./graph-male-female-default-data";

@Component({
  selector: 'app-graph-male-female',
  templateUrl: './graph-male-female.component.html',
  styleUrls: ['./graph-male-female.component.scss'],
})
export class GraphMaleFemaleComponent implements OnInit {
  public graphSexAndAgeData: any;
  public barGraphSexDefaultData = barGraphSexDefaultData;
  public barGraphData: ChartConfiguration<'bar'>['data'] | undefined;
  public barGraphLegend = true;
  public barGraphPlugins = [];
  public barGraphOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: false,
  };

  public constructor(
    private statisticsForGraphsService: GraphsService
  ) {}

  public ngOnInit(): void {
    this.getDataForGraphSex();
  }

  public getDataForGraphSex(): void {
    this.statisticsForGraphsService
      .getStatsForGraphSexAndAge()
      .subscribe((data: any) => {
        this.graphSexAndAgeData = data;
        this.barGraphData = this.aggregateGraphSexData();
      });
  }

  public aggregateGraphSexData(): ChartConfiguration<'bar'>['data'] {
    const labels: string[] = [];
    const males: number[] = [];
    const females: number[] = [];

    this.graphSexAndAgeData.forEach((element: any) => {
      labels.push(element.unit);
      males.push(element.maleAmount);
      females.push(element.femaleAmount);
    });

    return {
      labels: labels,
      datasets: [
        {
          data: males,
          label: 'males',
        },
        {
          data: females,
          label: 'females',
        },
      ],
    };
  }
}
