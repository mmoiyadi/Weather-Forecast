# WeatherForecast
Weather Forecast App with Docker and .NET 5

There are three applications
- Weather Forecast API: This is a .NET 5 Web API with swagger UI support. There is a single endpoint to fetch the Weather Forecast Information from WeatherDb which is a Postgre SQL DB
- Weather Forecast Admin: This is a .NET 5 Web Application. This is for the use of administrators to enter the weather forecast information for a particular day via a form. Once the form is submitted, the weather forecast information is sent to a message queue (RabbitMQ). Currently no authentication is provided
- Weather Forecast Processor: This is a .NET 5 Worker process. It listens to the message from message queue (RabbitMQ) and then saves the information to the WeatherDb
