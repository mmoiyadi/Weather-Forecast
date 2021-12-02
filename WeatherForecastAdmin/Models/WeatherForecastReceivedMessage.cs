using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastAdmin.Models
{
    public class WeatherForecastReceivedMessage
    {
        public DateTime Date { get; set; }
        public int TemperatureInCelcius { get; set; }
        public string Summary { get; set; }
    }
}
