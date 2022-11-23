import {
  Component,
  ChangeDetectionStrategy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration } from 'chart.js';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../../../environments/environment';

@Component({
  selector: 'app-statistics-page',
  templateUrl: './statistics-page.component.html',
  styleUrls: ['./statistics-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StatisticsPageComponent implements OnInit {
  @ViewChild(BaseChartDirective) private chart!: BaseChartDirective;
  public barChartLegend = true;
  public barChartPlugins = [];
  public url = environment.apiUrl;

  public barChartData: ChartConfiguration<'bar'>['data'] = {
    labels: ['Groceries', 'Pupils', 'Police', 'Students', 'Staffs'],
    datasets: [
      {
        data: [333, 247, 1059, 415, 5095],
        label: 'males',
      },
      {
        data: [307, 253, 1061, 445, 4905],
        label: 'females',
      },
    ],
  };

  public barChartOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: false,
  };

  public constructor(private http: HttpClient) {}

  public ngOnInit(): void {
    this.http.get<any>(`${this.url}get_graph`).subscribe((data: any) => {
      this.aggregateChartData(data);
    });
  }

  private aggregateChartData(data: any): void {
    let labels: any = [];
    let males: any = [];
    let females: any = [];

    data.forEach((element: any) => {
      labels.push(element.unit);
      males.push(element.maleAmount);
      females.push(element.femaleAmount);
    });
    this.barChartData = {
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

    // TODO delete before creating PR!!!
    console.log(this.chart);

    this.chart.data = this.barChartData;

    // TODO delete before creating PR!!!
    console.log(this.chart.data);
  }
}
