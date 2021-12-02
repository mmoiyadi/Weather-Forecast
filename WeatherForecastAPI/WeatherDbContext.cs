using Microsoft.EntityFrameworkCore;
using System;

namespace WeatherForecastAPI
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var random = new Random();
            modelBuilder.Entity<WeatherForecast>().HasData(
                new WeatherForecast() { Id = 1, Date = DateTime.Now.AddDays(1), Summary = "Freezing", TemperatureC = random.Next(-20, 55) },
                new WeatherForecast() { Id = 2, Date = DateTime.Now.AddDays(2), Summary = "Bracing", TemperatureC = random.Next(-20, 55) },
                new WeatherForecast() { Id = 3, Date = DateTime.Now.AddDays(3), Summary = "Chilly", TemperatureC = random.Next(-20, 55) }

                );
        }
    }
}
