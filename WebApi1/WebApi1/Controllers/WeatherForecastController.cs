using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    // /WeatherForecast

    [HttpGet]
    public IEnumerable<WeatherForecast> GetWeather()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public WeatherForecast CreateWeather()
    {
        var vrijeme = new WeatherForecast();
        vrijeme.Date = DateTime.Now;
        vrijeme.TemperatureC = 45;
        vrijeme.Summary = "asdasd";
        return vrijeme;
    }
}
