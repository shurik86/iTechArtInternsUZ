import { Component, OnInit } from '@angular/core';

import { GraphsService } from '../../graphs.service';
import { graphFacultiesDefaultData } from './graph-faculties-default-data';

export interface IFaculties {
  economics: number;
  law: number;
  medicine: number;
  psychology: number;
  engineering: number;
  science: number;
}

@Component({
  selector: 'app-graph-faculties',
  templateUrl: './graph-faculties.component.html',
  styleUrls: ['./graph-faculties.component.scss'],
})
export class GraphFacultiesComponent implements OnInit {
  public graphData: IFaculties | undefined;
  public graphDataDefault = graphFacultiesDefaultData;
  public graphDataForView: any[] | undefined;
  public view: [number, number] = [800, 400];

  // options
  public gradient = true;
  public showLegend = true;
  public showLabels = true;
  public isDoughnut = false;
  public legendPosition: any = 'below';

  public colorScheme: any = {
    domain: ['#ffa1b5', '#86c7f3', '#bd4863', '#5896bf', '#8d52c4', '#cd7be8'],
  };

  public constructor(private graphsService: GraphsService) {}

  public ngOnInit(): void {
    this.getDataForGraphFaculties();
  }

  public getDataForGraphFaculties(): void {
    this.graphsService.getStatsForFaculties().subscribe((data: IFaculties) => {
      this.graphData = data;
      this.graphDataForView = [
        {
          name: 'Economics',
          value: this.graphData?.economics,
        },
        {
          name: 'Law',
          value: this.graphData?.law,
        },
        {
          name: 'Medicine',
          value: this.graphData?.medicine,
        },
        {
          name: 'Psychology',
          value: this.graphData?.psychology,
        },
        {
          name: 'Engineering',
          value: this.graphData?.engineering,
        },
        {
          name: 'Science',
          value: this.graphData?.science,
        },
      ];
    });
  }
}
