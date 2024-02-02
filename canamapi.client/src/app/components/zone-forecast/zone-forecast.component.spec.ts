import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ZoneForecastComponent } from './zone-forecast.component';

describe('ZoneForecastComponent', () => {
  let component: ZoneForecastComponent;
  let fixture: ComponentFixture<ZoneForecastComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ZoneForecastComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ZoneForecastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
