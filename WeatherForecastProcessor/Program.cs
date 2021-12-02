using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;
using WeatherForecastProcessor.Repositories;

namespace WeatherForecastProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IDbConnection>(d =>
                        new SqlConnection(hostContext.Configuration.GetConnectionString("WeatherDatabase")));
                    services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();
                    services.AddHostedService<Worker>();
                });
    }
}
