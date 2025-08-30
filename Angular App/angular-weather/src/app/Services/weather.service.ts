import { Injectable } from '@angular/core';

import { IWeatherData } from '../Interfaces/iweather-data';
import { environment } from '../../enviorments/enviorment.dev';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  private weatherAPIURL = environment.apiUrl || '';

  async getWeatherDataByCity(city: string): Promise<IWeatherData | undefined> {
    const data = await fetch(`${this.weatherAPIURL}?city=${city}`);
    const result = await data.json();
    return result ?? undefined;
  }
}
