using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Pronosticos = new[]
        {
            "Soleado", "Nublado", "Parcialmente nublado", "Lluvioso", "Ventoso", "Tormentoso"
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
                Fecha = DateTime.Now.AddDays(index),
                TemperaturaC = rng.Next(-20, 55),
                Pronostico = Pronosticos[rng.Next(Pronosticos.Length)]
            })
            .ToArray();
        }
    }
}
