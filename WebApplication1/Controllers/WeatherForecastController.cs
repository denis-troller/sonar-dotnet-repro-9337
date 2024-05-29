using cloudscribe.Web.Common.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers;

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

    [HttpPost("new")]
    public IActionResult PostValue([FromBody] InputModel model)
    {

        return Ok();
    }
}


public class InputModel
{
    [JsonProperty(Required = Required.Always)]
    public int Count { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "State or Province is required")]
    public long StateOrProvinceId { get; set; }

    public bool AgreementRequired { get; set; } = false; // if true then AgreeToTerms is required to be checked
    [EnforceTrue("AgreementRequired", ErrorMessage = "You must agree to the terms of use.")]
    public bool AgreeToTerms { get; set; } = false;


}

