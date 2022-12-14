import { Component, Input, OnChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { StatsService } from '../../../stats.service';
import { UnitsTypes } from '../../types/units-types';
import { UnitsEnum } from '../../../../shared/enums/units.enum';
import { UnitCountDashboardInterface } from '../../../../shared/interfaces/unit-count-dashboard.interface';
import { APIS } from '../../../../shared/apis/constants/apis';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent implements OnChanges {
  @Input() public data: any[] | undefined;
  @Input() public columns: any[] | undefined;
  @Input() public unit: UnitsEnum | undefined;

  public page = 1;
  public itemsPerPage = 20;
  public dataOnPage: any = [];
  public unitCountsInfo: UnitCountDashboardInterface | undefined;
  public url = environment.apiUrl;
  public AllUnitDataCount: number | undefined

  public constructor(
    private statsService: StatsService,
    private http: HttpClient
  ) {}

  public ngOnChanges(): void {
    this.page = 1;
    this.switchPage(1);
    this.getUnitCountsInfo(this.unit);
    console.log(this.dataOnPage);
  }

  public switchPage(pageNo: any): void {
    const start = (pageNo - 1) * this.itemsPerPage;
    const end = pageNo * this.itemsPerPage;

    if (this.data == null) {
      console.log('Requested page change before data is received.');
      return;
    }

    this.statsService.getAllStatsByUnit(this.unit!, pageNo).subscribe({
      next: (data: UnitsTypes) => this.dataOnPage = this.data = data,
      error: () => alert("Couldn't load data."),
    });

    console.log(this.data)
    console.log(this.data)

    this.dataOnPage = this.data.slice(start, end);
  }

    public defineUnitCount(unit: UnitsEnum | undefined): number | undefined {
        switch (unit) {
          case UnitsEnum.pupils:
            return this.unitCountsInfo?.pupilCount
          case UnitsEnum.airport:
            return this.unitCountsInfo?.airportCount
          case UnitsEnum.police:
            return this.unitCountsInfo?.policeCount
          case UnitsEnum.medStaff:
            return this.unitCountsInfo?.doctorCount
          case UnitsEnum.grocery:
            return this.unitCountsInfo?.groceryCount
          case UnitsEnum.students:
            return this.unitCountsInfo?.studentCount
          default:
            return undefined
        }
    }

  public getUnitCountsInfo(unit: UnitsEnum | undefined): void {
    this.http
      .get<UnitCountDashboardInterface>(
        `${this.url}${APIS.dashboard.totalAmounts}`
      )
      .subscribe((data: UnitCountDashboardInterface) => {
        this.unitCountsInfo = data;
        this.AllUnitDataCount = this.defineUnitCount(unit);
        console.log(this.dataOnPage.length)
      });
  }
}
