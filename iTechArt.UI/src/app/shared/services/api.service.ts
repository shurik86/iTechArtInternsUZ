import { Injectable } from '@angular/core';

import { UnitsEnum } from '../enums/units.enum';
import { ExtensionsEnum } from '../enums/extensions.enum';
import { environment } from '../../../environments/environment';
import { APIS_LOGIC_PATHS } from '../apis/apis-logic-path';
import { APIS_UNIT_PATHS } from '../apis/api-unit-paths';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private _url = environment.apiUrl;
  private _unitPath: string | undefined;

  public defineImportApiForCurrentUnit(
    unit: UnitsEnum | undefined,
    extension: string | undefined
  ): string {
    let currentImportApi: string | undefined;

    this.defineUnitPath(unit);

    switch (extension) {
      case ExtensionsEnum.xml:
        currentImportApi = APIS_LOGIC_PATHS.import.xml;
        break;
      case ExtensionsEnum.xls:
        currentImportApi = APIS_LOGIC_PATHS.import.xls;
        break;
      case ExtensionsEnum.xlsx:
        currentImportApi = APIS_LOGIC_PATHS.import.xlsx;
        break;
      case ExtensionsEnum.csv:
        currentImportApi = APIS_LOGIC_PATHS.import.csv;
        break;
      default:
        return '';
    }

    return `${this._url}${this._unitPath}${currentImportApi}`;
  }

  public defineExportApiForCurrentUnit(unit: UnitsEnum | undefined): string {
    this.defineUnitPath(unit);
    return `${this._url}${this._unitPath}${APIS_LOGIC_PATHS.export}`;
  }

  public defineDownloadFileApiForCurrentUnit(
    unit: UnitsEnum | undefined,
    extension: ExtensionsEnum | undefined
  ): string {
    this.defineUnitPath(unit);
    const extensionPath = this.defineDownloadApiByExtension(extension);
    return `${this._url}${this._unitPath}${extensionPath}`;
  }

  private defineDownloadApiByExtension(
    extension: ExtensionsEnum | undefined
  ): string | undefined {
    switch (extension) {
      case ExtensionsEnum.xlsx:
        return APIS_LOGIC_PATHS.download.xlsx;
      case ExtensionsEnum.xml:
        return APIS_LOGIC_PATHS.download.xml;
      case ExtensionsEnum.csv:
        return APIS_LOGIC_PATHS.download.csv;
      default:
        return undefined;
    }
  }

  private defineUnitPath(unit: UnitsEnum | undefined): void {
    switch (unit) {
      case UnitsEnum.airport:
        this._unitPath = APIS_UNIT_PATHS.airport;
        break;
      case UnitsEnum.grocery:
        this._unitPath = APIS_UNIT_PATHS.grocery;
        break;
      case UnitsEnum.police:
        this._unitPath = APIS_UNIT_PATHS.police;
        break;
      case UnitsEnum.pupils:
        this._unitPath = APIS_UNIT_PATHS.pupils;
        break;
      case UnitsEnum.medStaff:
        this._unitPath = APIS_UNIT_PATHS.medStaff;
        break;
      case UnitsEnum.students:
        this._unitPath = APIS_UNIT_PATHS.students;
        break;
      default:
        break;
    }
  }
}
