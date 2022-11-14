import { Component, Input, OnChanges } from "@angular/core";

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent implements OnChanges {
  @Input() public data: any[] | undefined;
  @Input() public columns: any[] | undefined;

  public page = 1;
  public itemsPerPage = 20;
  public dataOnPage: any = [];

  public ngOnChanges(): void {
    this.page = 1;
    this.switchPage(1);

    console.log(this.dataOnPage);
  }

  public switchPage(pageNo: any): void {
    const start = (pageNo - 1) * this.itemsPerPage;
    const end = pageNo * this.itemsPerPage;

    if (this.data == null) {
      console.log('Requested page change before data is received.');
      return;
    }

    this.dataOnPage = this.data.slice(start, end);
  }
}
