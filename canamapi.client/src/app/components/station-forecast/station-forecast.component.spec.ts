import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationForecastComponent } from './station-forecast.component';

describe('StationForecastComponent', () => {
  let component: StationForecastComponent;
  let fixture: ComponentFixture<StationForecastComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StationForecastComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StationForecastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
