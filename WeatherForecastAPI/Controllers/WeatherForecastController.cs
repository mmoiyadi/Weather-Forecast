using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherDbContext weatherDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                        WeatherDbContext weatherDbContext)
        {
            _logger = logger;
            this.weatherDbContext = weatherDbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherDbContext.WeatherForecasts.ToArray();
        }
    }
}
