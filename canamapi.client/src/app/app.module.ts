import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchComponent } from './components/search/search.component';
import { StationForecastComponent } from './components/station-forecast/station-forecast.component';
import { ZoneForecastComponent } from './components/zone-forecast/zone-forecast.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    StationForecastComponent,
    ZoneForecastComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
