import { Injectable } from '@angular/core';

import { UnitsEnum } from '../enums/units.enum';
import { APIS } from '../apis/constants/apis';
import { ExtensionsEnum } from '../enums/extensions.enum';
import { environment } from '../../../environments/environment';
import { ApisImportEnum } from '../apis/enums/apis-import.enum';
import {
  ApisDownloadEnum,
  ApisExportEnum,
} from '../apis/enums/apis-export.enum';

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
    let currentImportApi: ApisImportEnum | undefined;

    this.defineUnitPath(unit);

    switch (extension) {
      case ExtensionsEnum.xml:
        currentImportApi = ApisImportEnum.xml;
        break;
      case ExtensionsEnum.xls:
        currentImportApi = ApisImportEnum.xls;
        break;
      case ExtensionsEnum.xlsx:
        currentImportApi = ApisImportEnum.xlsx;
        break;
      case ExtensionsEnum.csv:
        currentImportApi = ApisImportEnum.csv;
        break;
      default:
        return '';
    }

    return `${this._url}${this._unitPath}${currentImportApi}`;
  }

  public defineExportApiForCurrentUnit(unit: UnitsEnum | undefined): string {
    this.defineUnitPath(unit);
    return `${this._url}${this._unitPath}${ApisExportEnum.getAll}`;
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
  ): ApisDownloadEnum | undefined {
    switch (extension) {
      case ExtensionsEnum.xlsx:
        return ApisDownloadEnum.xlsx;
      case ExtensionsEnum.xml:
        return ApisDownloadEnum.xml;
      default:
        return undefined;
    }
  }

  private defineUnitPath(unit: UnitsEnum | undefined): void {
    switch (unit) {
      case UnitsEnum.airport:
        this._unitPath = APIS.airport.path;
        break;
      case UnitsEnum.grocery:
        this._unitPath = APIS.grocery.path;
        break;
      case UnitsEnum.police:
        this._unitPath = APIS.police.path;
        break;
      case UnitsEnum.pupils:
        this._unitPath = APIS.pupils.path;
        break;
      case UnitsEnum.medStaff:
        this._unitPath = APIS.medStaff.path;
        break;
      case UnitsEnum.students:
        this._unitPath = APIS.students.path;
        break;
      default:
        break;
    }
  }
}
