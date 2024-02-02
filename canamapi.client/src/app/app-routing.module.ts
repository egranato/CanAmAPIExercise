import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchComponent } from './components/search/search.component';
import { StationForecastComponent } from './components/station-forecast/station-forecast.component';
import { ZoneForecastComponent } from './components/zone-forecast/zone-forecast.component';

const routes: Routes = [
  {
    path: '',
    component: SearchComponent,
  },
  {
    path: 'stationforecast',
    component: StationForecastComponent,
  },
  {
    path: 'zoneforecast',
    component: ZoneForecastComponent,
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: '',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
