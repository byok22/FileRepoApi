using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public  class WeatherForecastController : ControllerBase, IActionResult
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    //private readonly CarsContext carsDb;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        throw new NotImplementedException();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
   /* [HttpGet]
    [Route("prueba")]
    public  async Task<IActionResult> prueba()
    {
        await Task.Delay(10);
       
        var carList = carsDb.Cars.Take(10).ToList();
        return Ok(carList);
        
      /*  await Task.Delay(10000);
        Bote ElBote = new Bote();
        ElBote.name = "Juan";
        ElBote.id = 12;
        return Ok(ElBote);
      //return BadRequest();
    }*/
    [HttpGet]
    [Route("prueba2")]
    public IEnumerable<WeatherForecast> prueba2()
    {
        return Enumerable.Range(2000000, 5000).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray().Take(5).ToArray();
    }
  
}
