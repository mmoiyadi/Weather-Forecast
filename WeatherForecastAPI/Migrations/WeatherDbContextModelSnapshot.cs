﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WeatherForecastAPI;

namespace WeatherForecastAPI.Migrations
{
    [DbContext(typeof(WeatherDbContext))]
    partial class WeatherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WeatherForecastAPI.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2021, 12, 2, 15, 11, 35, 802, DateTimeKind.Local).AddTicks(8554),
                            Summary = "Freezing",
                            TemperatureC = 32
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2021, 12, 3, 15, 11, 35, 807, DateTimeKind.Local).AddTicks(1581),
                            Summary = "Bracing",
                            TemperatureC = 50
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2021, 12, 4, 15, 11, 35, 807, DateTimeKind.Local).AddTicks(1618),
                            Summary = "Chilly",
                            TemperatureC = 54
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
