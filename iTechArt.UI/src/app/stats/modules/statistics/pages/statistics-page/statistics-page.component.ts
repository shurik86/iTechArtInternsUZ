import { Component, ChangeDetectionStrategy, ViewChild, ChangeDetectorRef } from "@angular/core";
import { IgxLegendComponent, IgxDataChartComponent, IgxCategoryYAxisComponent, IgxNumericXAxisComponent, IgxCategoryHighlightLayerComponent, IgxBarSeriesComponent, IgxDataToolTipLayerComponent } from 'igniteui-angular-charts';
import { HighestGrossingMovies } from "./data";


@Component({
  selector: 'app-statistics-page',
  templateUrl: './statistics-page.component.html',
  styleUrls: ['./statistics-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class StatisticsPageComponent {
  public constructor(private _detector: ChangeDetectorRef) {
  }

  @ViewChild("legend", { static: true })
  private legend: IgxLegendComponent | undefined
  @ViewChild("chart", { static: true })
  private chart: IgxDataChartComponent | undefined
  @ViewChild("yAxis", { static: true })
  private yAxis: IgxCategoryYAxisComponent | undefined
  @ViewChild("xAxis", { static: true })
  private xAxis: IgxNumericXAxisComponent | undefined
  @ViewChild("categoryHighlightLayer", { static: true })
  private categoryHighlightLayer: IgxCategoryHighlightLayerComponent | undefined
  @ViewChild("barSeries1", { static: true })
  private barSeries1: IgxBarSeriesComponent | undefined
  @ViewChild("barSeries2", { static: true })
  private barSeries2: IgxBarSeriesComponent | undefined
  @ViewChild("tooltips", { static: true })
  private tooltips: IgxDataToolTipLayerComponent | undefined

   private _highestGrossingMovies: HighestGrossingMovies | undefined;
   public get highestGrossingMovies(): HighestGrossingMovies {
     if (this._highestGrossingMovies == null) {
       this._highestGrossingMovies = new HighestGrossingMovies();
     }
      return this._highestGrossingMovies;


   }

}
