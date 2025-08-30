import { Routes } from '@angular/router';
import { WeatherCard } from './Components/weather-card/weather-card';

export const routes: Routes = [
  { path: '', component: WeatherCard },
  { path: '**', redirectTo: '' },
];
