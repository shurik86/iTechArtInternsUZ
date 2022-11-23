import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AirportModule } from './modules/airport/airport.module';
import { GroceryModule } from './modules/grocery/grocery.module';
import { MedStaffModule } from './modules/medStaff/med-staff.module';
import { PoliceModule } from './modules/police/police.module';
import { PupilsModule } from './modules/pupils/pupils.module';
import { StudentsModule } from './modules/students/students.module';
import { SharedStatsModule } from './shared/shared-stats.module';
import { StatisticsPageComponent } from './modules/statistics/pages/statistics-page/statistics-page.component';
import {
  IgxBarSeriesModule,
  IgxCategoryHighlightLayerModule,
  IgxCategoryYAxisModule,
  IgxDataChartCoreModule, IgxDataToolTipLayerModule,
  IgxLegendModule,
  IgxNumericXAxisModule
} from "igniteui-angular-charts";
import { NgChartsModule } from "ng2-charts";
import { GraphMaleFemaleComponent } from './modules/statistics/components/graph-male-female/graph-male-female.component';

@NgModule({
  imports: [
    CommonModule,
    AirportModule,
    GroceryModule,
    MedStaffModule,
    PoliceModule,
    PupilsModule,
    StudentsModule,
    SharedStatsModule,
    IgxLegendModule,
    IgxDataChartCoreModule,
    IgxCategoryYAxisModule,
    IgxNumericXAxisModule,
    IgxCategoryHighlightLayerModule,
    IgxBarSeriesModule,
    IgxDataToolTipLayerModule,
    NgChartsModule
  ],
  declarations: [StatisticsPageComponent, GraphMaleFemaleComponent],
})
export class StatsModule {}
