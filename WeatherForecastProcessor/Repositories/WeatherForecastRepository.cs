using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastProcessor.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IConfiguration _config;
        public WeatherForecastRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task SaveWeatherForecastInformation(DateTime date, int temperatureInC, string summary)
        {
            using (var connection = new NpgsqlConnection(_config.GetConnectionString("WeatherDatabase")))
            {
                connection.Open();
                string sql = $"INSERT INTO public.\"WeatherForecasts\" (\"Date\", \"TemperatureC\", \"Summary\") VALUES ('{date.ToString()}', '{temperatureInC.ToString()}', '{summary}')";
                await connection.ExecuteAsync(sql,
                    new { date, temperatureInC, summary });
                
            }
            //var sql = "INSERT INTO WeatherForecasts(Date, TemperatureC, Summary) VALUES (@date.ToString(), @temperatureInC.ToString(), @summary)";
            //await _db.ExecuteAsync(sql, new { date, temperatureInC, summary});
        }
    }
}
