import { Component } from '@angular/core';

export enum TabsEnum {
  MaleFemale = 'MaleFemale',
  Retired = 'Retired',
  Age = 'Age',
  Faculties = 'Faculties',
}

@Component({
  selector: 'app-statistics-page',
  templateUrl: './statistics-page.component.html',
  styleUrls: ['./statistics-page.component.scss'],
})
export class StatisticsPageComponent {
  public tabsEnum = TabsEnum;
  public currentTab?: TabsEnum = this.tabsEnum.MaleFemale;

  public switchTab(tab: TabsEnum): void {
    this.currentTab = tab;
  }
}
