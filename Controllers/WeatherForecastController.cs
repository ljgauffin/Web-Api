using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> listWatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (listWatherForecast ==null || !listWatherForecast.Any()){

            listWatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherForecast")]
    [Route("Get/weatherForecast2")]
    [Route("[action]")] //me deja WeatherForecast/get/
    public IEnumerable<WeatherForecast> Get()
    {
        return listWatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        listWatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        listWatherForecast.RemoveAt(index);
        return Ok();
    }
}
