import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';
import { APIS_LOGIC_PATHS } from '../../../shared/apis/apis-logic-path';
import { UnitCountDashboardInterface } from '../../../shared/interfaces/unit-count-dashboard.interface';

@Injectable({
  providedIn: 'root',
})
export class GraphsService {
  private url = environment.apiUrl;

  public constructor(private http: HttpClient) {}

  // Get statistics for graphs from all units
  // - male on even unit,
  // - female on even unit,
  // - average male age on even unit,
  // - average male age on even unit.
  public getStatsForGraphSexAndAge(): any {
    return this.http.get<any>(
      `${this.url}${APIS_LOGIC_PATHS.graphs.sexAndAge}`
    );
  }

  // Get statistics by all units for dashboard page.
  public getStatsForDashboard(): any {
    return this.http.get<UnitCountDashboardInterface>(
      `${this.url}${APIS_LOGIC_PATHS.graphs.dashboard}`
    );
  }
}
