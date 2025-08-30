import { Component, inject } from '@angular/core';

// Interfaces and Services
import { IWeatherData } from '../../Interfaces/iweather-data';
import { WeatherService } from '../../Services/weather.service';

// Angular Material Modules
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-weather-card',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    CommonModule,
  ],
  templateUrl: './weather-card.html',
  styleUrl: './weather-card.css',
})
export class WeatherCard {
  currentWeather: IWeatherData | undefined;
  cityControl = new FormControl('');

  private weatherService = inject(WeatherService);

  async ngOnInit() {
    this.currentWeather = await this.weatherService.getWeatherDataByCity('New York');
  }

  async searchByCity() {
    this.currentWeather = await this.weatherService.getWeatherDataByCity(
      this.cityControl.value || 'New York'
    );
    this.cityControl.reset();
  }

  getTodayMinTemperature(): number {
    return this.currentWeather?.forecast?.forecastday[0].day.mintemp_c ?? 0;
  }

  getTodayMaxTemperature(): number {
    return this.currentWeather?.forecast?.forecastday[0].day.maxtemp_c ?? 0;
  }

  parseTimeOnDate(dateStr: string, timeStr: string): Date {
    const [time, modifier] = timeStr.split(' '); // "06:00 AM"
    let [hours, minutes] = time.split(':').map(Number);

    if (modifier === 'PM' && hours !== 12) hours += 12;
    if (modifier === 'AM' && hours === 12) hours = 0;

    const date = new Date(dateStr.replace(' ', 'T')); // "2025-08-26 21:18" → Date
    date.setHours(hours, minutes, 0, 0);
    return date;
  }

  getBackground(localtimeStr: string, sunriseStr: string, sunsetStr: string): string {
    const localtime = new Date(localtimeStr.replace(' ', 'T'));
    const datePart = localtimeStr.split(' ')[0]; // "2025-08-26"

    const sunrise = this.parseTimeOnDate(datePart, sunriseStr);
    const sunset = this.parseTimeOnDate(datePart, sunsetStr);

    if (localtime < sunrise) {
      return 'assets/morning-card-background.png';
    } else if (localtime >= sunrise && localtime < sunset) {
      return 'assets/day-card-background.png';
    } else {
      return 'assets/night-card-background.png';
    }
  }
}
