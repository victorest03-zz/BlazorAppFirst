using BlazorApp1.Data;
using BlazorApp1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.ViewModels
{
    
    public class FetchDataViewModel
    {
        private FetchDataModel[] _weatherForecasts;

        public void Init()
        {

        }

        public FetchDataModel[] WeatherForecasts
        {
            get => _weatherForecasts;
            set => _weatherForecasts = value;
        }

        public int TotalRow => WeatherForecasts?.Length ?? 0;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<FetchDataModel[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new FetchDataModel
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public async void CargarDatos()
        {
            WeatherForecasts = await GetForecastAsync(DateTime.Now);
        }
    }
}
