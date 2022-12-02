import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

import { StatsService } from '../../../stats.service';
import { UnitsTypes } from '../../types/units-types';
import { UnitsEnum } from '../../../../shared/enums/units.enum';
import { UnitCountDashboardInterface } from '../../../../shared/interfaces/unit-count-dashboard.interface';
import { environment } from '../../../../../environments/environment';
import { GraphsService } from '../../../modules/statistics/graphs.service';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent implements OnChanges, OnInit {
  @Input() public data: any[] | undefined;
  @Input() public columns: any[] | undefined;
  @Input() public unit: UnitsEnum | undefined;

  public page: number | undefined = 1;
  public itemsPerPage: number | string = 10;
  public dataOnPage: any = [];
  public unitCountsInfo: UnitCountDashboardInterface | undefined;
  public url = environment.apiUrl;
  public allUnitDataCount: number | undefined;
  public pageRows = new FormControl(this.itemsPerPage);
  public currentChosenColumn: any;
  public currentSortingMethod: any = 1;
  public searchInput = new FormControl('', Validators.required);
  public searchColumn = new FormControl('', Validators.required);
  public searchResultAmount: any;

  public constructor(
    private statsService: StatsService,
    private graphsService: GraphsService
  ) {}

  public ngOnInit(): void {
    this.currentChosenColumn = this.columns![0]!.field;
  }

  public ngOnChanges(): void {
    this.switchPage();
    this.getUnitCountsInfo(this.unit);
  }

  public getRowsAmountPerPage(): void {
    if (this.itemsPerPage != this.pageRows.value) {
      this.itemsPerPage = +this.pageRows.value!;
      this.page = 1;
      this.switchPage(
        this.page,
        this.itemsPerPage,
        this.currentChosenColumn,
        this.currentSortingMethod
      );
    }
  }

  public switchPage(
    pageNumber?: number,
    pageSize?: number | string,
    chosenColumn?: string | undefined,
    chosenSortingMethod?: string | undefined,
    searchColumn?: string,
    searchInput?: string
  ): void {
    this.page = pageNumber;
    this.dataOnPage = pageSize;

    if (chosenColumn) {
      this.currentChosenColumn = chosenColumn;
    }

    if (chosenSortingMethod) {
      this.currentSortingMethod = chosenSortingMethod;
    }

    this.statsService
      .getAllStatsByUnit(
        this.unit!,
        this.page,
        this.itemsPerPage,
        this.currentChosenColumn,
        this.currentSortingMethod,
        this.searchColumn.value!,
        this.searchInput.value!
      )
      .subscribe({
        next: (data: UnitsTypes) => (this.dataOnPage = this.data = data),
        error: () => alert("Couldn't load data."),
      });
  }

  public defineUnitCount(unit: UnitsEnum | undefined): number | undefined {
    switch (unit) {
      case UnitsEnum.pupils:
        return this.unitCountsInfo?.pupilCount;
      case UnitsEnum.airport:
        return this.unitCountsInfo?.airportCount;
      case UnitsEnum.police:
        return this.unitCountsInfo?.policeCount;
      case UnitsEnum.medStaff:
        return this.unitCountsInfo?.doctorCount;
      case UnitsEnum.grocery:
        return this.unitCountsInfo?.groceryCount;
      case UnitsEnum.students:
        return this.unitCountsInfo?.studentCount;
      default:
        return undefined;
    }
  }

  public getUnitCountsInfo(unit: UnitsEnum | undefined): void {
    this.graphsService
      .getStatsForDashboard()
      .subscribe((data: UnitCountDashboardInterface) => {
        this.unitCountsInfo = data;
        this.allUnitDataCount = this.defineUnitCount(unit);
      });
  }

  public chooseHeader(columnField: string): void {
    if (this.currentChosenColumn != columnField) {
      this.currentSortingMethod = 1;
      this.currentChosenColumn = columnField;
    } else {
      if (this.currentSortingMethod == 1) {
        this.currentSortingMethod = 2;
      } else {
        this.currentSortingMethod = 1;
      }
    }

    this.page = 1;

    this.switchPage(
      this.page,
      this.itemsPerPage,
      this.currentChosenColumn,
      this.currentSortingMethod
    );
  }

  public searchByValueInColumn(): void {
    const searchColumn = this.searchColumn.value;
    const searchInput = this.searchInput.value;

    this.statsService
      .getAllStatsByUnit(
        this.unit!,
        0,
        0,
        this.currentChosenColumn,
        this.currentSortingMethod,
        searchColumn!,
        searchInput!
      )
      .subscribe({
        next: (data: UnitsTypes) => {
          this.searchResultAmount = data.length;
          this.allUnitDataCount = Math.ceil(
            +this.searchResultAmount / +this.itemsPerPage
          );
          console.log(this.allUnitDataCount);
          this.switchPage(
            this.page,
            this.itemsPerPage,
            this.currentChosenColumn,
            this.currentSortingMethod,
            searchColumn!,
            searchInput!
          );
        },
      });
  }

  public cleanSearchForm(): void {
    this.searchInput.setValue('');
    this.searchColumn.setValue('');

    this.searchByValueInColumn();
  }
}
