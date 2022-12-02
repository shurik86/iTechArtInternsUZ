import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { GraphsService } from '../../graphs.service';
import { IGraphRetired } from '../../interfaces/graph-retired';

@Component({
  selector: 'app-graph-retired',
  templateUrl: './graph-retired.component.html',
  styleUrls: ['./graph-retired.component.scss'],
})
export class GraphRetiredComponent {
  public minYear = 1900;
  public currentYear = new Date().getFullYear();
  public graphData: IGraphRetired | undefined;

  public graphForm = new FormGroup({
    firstDate: new FormControl('', [
      Validators.required,
      Validators.min(this.minYear),
      Validators.max(this.currentYear),
    ]),
    secondDate: new FormControl('', [
      Validators.required,
      Validators.min(this.minYear),
      Validators.max(this.currentYear),
    ]),
  });

  public constructor(private graphsService: GraphsService) {}

  public submit(): void {
    const firstDate = this.graphForm.controls.firstDate.value;
    const secondDate = this.graphForm.controls.secondDate.value;

    if (firstDate! > secondDate!) {
      alert('First date should be less than second');
    } else {
      this.graphsService
        .getStatsForRetired(firstDate, secondDate)
        .subscribe((data: IGraphRetired) => {
          this.graphData = data;
          console.log(this.graphData);
        });
    }
  }
}
