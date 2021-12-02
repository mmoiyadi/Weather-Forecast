using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace WeatherForecastProcessor.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<WeatherForecastRepository> _logger;

        public WeatherForecastRepository(IConfiguration config, 
                                         ILogger<WeatherForecastRepository> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task SaveWeatherForecastInformation(DateTime date, 
                                                         int temperatureInC, 
                                                         string summary)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("WeatherDatabase"));
            connection.Open();
            string sql = $"INSERT INTO public.\"WeatherForecasts\" (\"Date\", \"TemperatureC\", \"Summary\")" +
                         $" VALUES ('{date.ToString()}', '{temperatureInC.ToString()}', '{summary}')";
            _logger.LogInformation($"Saving Weather Forecast Information to Weather Database. " +
                                   $"Date: {date.ToString()} " +
                                   $"Temperature in Celcius: {temperatureInC} " +
                                   $"Summary: {summary}");
            await connection.ExecuteAsync(sql, new { date, temperatureInC, summary });
            
        }
    }
}
