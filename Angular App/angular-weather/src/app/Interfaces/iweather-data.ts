export interface IWeatherData {
  location: {
    name: string; // City name
    country: string; // Country name
    localtime: string; // Local time of the city
  };
  current: {
    temp_c: number; // Current temperature in Celsius
    wind_kph: number; // Wind speed in kilometers per hour,
    humidity: number; // Humidity percentage
  };
  forecast: {
    forecastday: [
      {
        astro: {
          sunrise: string; // Sunrise time
          sunset: string; // Sunset time
        };
        date: string; // Date of the forecast
        day: {
          maxtemp_c: number; // Maximum temperature in Celsius
          mintemp_c: number; // Minimum temperature in Celsius
          avgtemp_c: number; // Average temperature in Celsius
          condition: {
            text: string; // Weather condition text
            icon: string; // URL to the weather condition icon
          };
        };
      }
    ];
  };
}
