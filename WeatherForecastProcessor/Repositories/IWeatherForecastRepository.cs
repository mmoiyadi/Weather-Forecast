using System;
using System.Threading.Tasks;

namespace WeatherForecastProcessor.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task SaveWeatherForecastInformation(DateTime date, 
                                            int temperatureInC, 
                                            string summary);
    }
}
