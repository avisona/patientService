using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PatientServices.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> WeatherGet(string name)
        {
            string ret = $"Your name { name}, Today is {DateTime.Today:D}\n" +
                     "Today's hours of V2 leisure: " +
                     $"{await GetLeisureHours()}";
            return Ok(ret);
        }

        static async Task<int> GetLeisureHours()
        {
            // Task.FromResult is a placeholder for actual work that returns a string.
            var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());

            // The method then can process the result in some way.
            int leisureHours;
            if (today.First() == 'S')
                leisureHours = 16;
            else
                leisureHours = 5;

            return leisureHours;
        }
    }
}
