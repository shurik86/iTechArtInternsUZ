import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ApiService } from '../shared/services/api.service';
import { UnitsEnum } from '../shared/enums/units.enum';
import { UnitsTypes } from './shared/types/units-types';
import { ExtensionsEnum } from '../shared/enums/extensions.enum';

@Injectable({
  providedIn: 'root',
})
export class StatsService {
  private _api: string | undefined;

  public constructor(
    private http: HttpClient,
    private apiService: ApiService
  ) {}

  public getAllStatsByUnit(unit: UnitsEnum, pageNumber = 1): any {
    this._api = this.apiService.defineExportApiForCurrentUnit(unit);
    return this.http.get<UnitsTypes>(`${this._api}${pageNumber}`);
  }

  public downloadFile(
    unit: UnitsEnum,
    extension: ExtensionsEnum
  ): Observable<Blob> {
    this._api = this.apiService.defineDownloadFileApiForCurrentUnit(
      unit,
      extension
    );
    return this.http.get(this._api, { responseType: 'blob' });
  }
}
