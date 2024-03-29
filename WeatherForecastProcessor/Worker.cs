using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecastProcessor.Models;
using WeatherForecastProcessor.Repositories;

namespace WeatherForecastProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private string queueName = "weatherforecast.received";
        private EventingBasicConsumer _consumer;

        public Worker(IConfiguration config,
                      IWeatherForecastRepository weatherForecastRepository,
                      ILogger<Worker> logger)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
            var factory = new ConnectionFactory
            {
                HostName = config.GetValue<string>("RabbitMqHost")
            };
            try
            {
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                for (var i = 0; i < 5; i++)
                {
                    if (_connection != null)
                        continue;
                    Thread.Sleep(3000);
                    try { _connection = factory.CreateConnection(); } catch { }
                }
                if (_connection == null) throw;
            }

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += ProcessWeatherForecastReceived;
        }

        protected override  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _channel.BasicConsume(queue: queueName, autoAck: true, consumer: _consumer);
            }
            return Task.CompletedTask;
        }

        private async void ProcessWeatherForecastReceived(object sender, BasicDeliverEventArgs eventArgs)
        {
            var weatherForecastInfo = JsonSerializer.Deserialize<WeatherForecastReceivedMessage>(eventArgs.Body.ToArray());
            _logger.LogInformation($"Received weather forecast message from queue for processing. " +
                                    $"Date: {weatherForecastInfo.Date.ToString()} " +
                                    $"Temperature in Celsius: {weatherForecastInfo.TemperatureInCelcius} " +
                                    $"Summary: {weatherForecastInfo.Summary}");

            await _weatherForecastRepository.SaveWeatherForecastInformation(weatherForecastInfo.Date,
                                                        weatherForecastInfo.TemperatureInCelcius,
                                                        weatherForecastInfo.Summary);
            
        }
    }
}
