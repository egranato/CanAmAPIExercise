import { Component } from '@angular/core';
import { IWeatherArea } from '../../models/weather-area.model';
import { HttpClient } from '@angular/common/http';
import { IStation } from '../../models/station.model';
import { IZone } from '../../models/zone.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  public state: string = '';
  public stateValid: boolean = false;

  public stations: IStation[] = [];
  public zones: IZone[] = [];

  constructor(private http: HttpClient) {}

  validateState(): void {
    this.stateValid = this.state.length == 2 && /^[a-zA-Z]+$/.test(this.state);
  }

  getStationsAndZones(): void {
    if (this.stateValid) {
      this.http
        .get<IStation[]>(`/station?state=${this.state}`)
        .subscribe((stations) => {
          this.stations = stations;
        });

      this.http.get<IZone[]>(`/zone?state=${this.state}`).subscribe((zones) => {
        this.zones = zones;
      });
    }
  }
}
