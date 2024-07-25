using Hangfire;

using Microsoft.AspNetCore.Mvc;

namespace CustomerWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class HangfireJobController : ControllerBase
{
    private readonly ILogger<HangfireJobController> _logger;

    public HangfireJobController(ILogger<HangfireJobController> logger)
    {
        _logger = logger;
    }

    [HttpGet("runjob")]
    public void RunJob()
    {
        BackgroundJob.Enqueue(() => Console.WriteLine("My first handfire job!"));
    }
}