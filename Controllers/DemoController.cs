using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("api/")]
public class DemoController : ControllerBase
{

    private readonly ILogger<DemoController> _logger;

    public DemoController(ILogger<DemoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("greeting")]
    public String GetGreeting()
    {
        _logger.Log(LogLevel.Information, "/api/greeting Started");
        String result = "Hello World from Demo";
        _logger.Log(LogLevel.Information, "/api/greeting Finished");
        return result;
    }

}
