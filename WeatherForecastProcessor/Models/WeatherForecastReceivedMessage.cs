using System;

namespace WeatherForecastProcessor.Models
{
    class WeatherForecastReceivedMessage
    {
        public DateTime Date { get; set; }
        public int TemperatureInCelcius { get; set; }
        public string Summary { get; set; }
    }
}
