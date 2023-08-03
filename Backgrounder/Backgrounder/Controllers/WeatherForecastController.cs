using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Backgrounder.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IBackgroundJobClient _backgroundJobClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IBackgroundJobClient backgroundJobClient)
    {
        _logger = logger;
        _backgroundJobClient = backgroundJobClient;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _backgroundJobClient.Enqueue(() => CalledFromBackground()); 
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [ApiExplorerSettings(IgnoreApi=true)]
    public void CalledFromBackground()
    {
        var number1 = 1;
        var number2 = 2;

        var sum = number1 + number2;
        
        Console.WriteLine($"The sum of two numbers is {sum}");
    }
}