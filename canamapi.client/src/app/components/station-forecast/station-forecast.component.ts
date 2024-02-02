import { Component } from '@angular/core';
import { IForecast } from '../../models/forecast.model';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-station-forecast',
  templateUrl: './station-forecast.component.html',
  styleUrl: './station-forecast.component.css',
})
export class StationForecastComponent {
  public name: string = '';
  private latitude: number = 0;
  private longitude: number = 0;

  public tab: string = 'daily';

  public forecast: IForecast | null = null;
  public dailyForcast: Array<{ date: string; min: number; max: number }> = [];
  public hourlyForcast: Array<{ date: string; value: number }> = [];

  constructor(private http: HttpClient, private activeRoute: ActivatedRoute) {}

  ngOnInit(): void {
    const { name, latitude, longitude } = this.activeRoute.snapshot.queryParams;
    this.name = name;
    this.latitude = latitude;
    this.longitude = longitude;

    this.getDailyForecast();
  }

  setTab(tab: string): void {
    this.tab = tab;
  }

  getDailyForecast(): void {
    this.http
      .get<IForecast>(
        `/weatherforecast/getstationforecast?latitude=${this.latitude}&longitude=${this.longitude}`
      )
      .subscribe((result) => {
        result.properties.maxTemperature.values.forEach((day, i) => {
          this.dailyForcast.push({
            date: day.validTime.split('T')[0],
            min: this.convertToFahrenheit(
              result.properties.minTemperature.values[i].value
            ),
            max: this.convertToFahrenheit(day.value),
          });
        });

        result.properties.temperature.values.forEach((hour) => {
          this.hourlyForcast.push({
            date: hour.validTime.split('+')[0],
            value: this.convertToFahrenheit(hour.value),
          });
        });
      });
  }

  convertToFahrenheit(celsius: number): number {
    return (celsius * 9) / 5 + 32;
  }
}
