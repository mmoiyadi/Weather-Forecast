#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5432

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WeatherForecastAPI/WeatherForecastAPI.csproj", "WeatherForecastAPI/"]
RUN dotnet restore "WeatherForecastAPI/WeatherForecastAPI.csproj"
COPY . .
WORKDIR "/src/WeatherForecastAPI"
RUN dotnet build "WeatherForecastAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherForecastAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecastAPI.dll"]