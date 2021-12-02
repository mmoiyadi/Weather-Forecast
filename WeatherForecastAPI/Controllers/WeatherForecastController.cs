using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherDbContext _weatherDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                        WeatherDbContext weatherDbContext)
        {
            _logger = logger;
            _weatherDbContext = weatherDbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Loading weather forecast information");
            return _weatherDbContext.WeatherForecasts.ToArray();
        }
    }
}
