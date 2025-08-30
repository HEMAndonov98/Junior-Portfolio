import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherCard } from './weather-card';

describe('WeatherCard', () => {
  let component: WeatherCard;
  let fixture: ComponentFixture<WeatherCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeatherCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
