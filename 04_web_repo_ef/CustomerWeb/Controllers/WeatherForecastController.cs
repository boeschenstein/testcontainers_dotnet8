using Customers;

using Microsoft.AspNetCore.Mvc;

namespace CustomerWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ICustomerService _customerService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        long newId = 1;
        _customerService.Create(new Customer { Id = newId, Name = "Patrik" });
        IEnumerable<Customer> customer = _customerService.GetCustomers();
        foreach (Customer customerItem in customer)
        {
            _logger.LogInformation($"Customer: {customerItem.Name}");
        }
        _customerService.Delete(newId);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}