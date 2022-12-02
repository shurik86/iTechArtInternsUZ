import { Component } from '@angular/core';

@Component({
  selector: 'app-statistics-page',
  templateUrl: './statistics-page.component.html',
  styleUrls: ['./statistics-page.component.scss'],
})
export class StatisticsPageComponent {
  public currentTab?: string = 'MaleFemale';

  public switchTab(tab: string): void {
    this.currentTab = tab;
  }
}
