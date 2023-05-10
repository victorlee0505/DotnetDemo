using System.Text;
using DemoApi.Model;
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

    [HttpPost("greeting")]
    public async Task<string> PostGreeting()
    {
        _logger.Log(LogLevel.Information, "/api/greeting Started");
        String name;
        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        {  
            name = await reader.ReadToEndAsync();
        }
        String result = "Hello World to " + name;
        _logger.Log(LogLevel.Information, "/api/greeting Finished");
        return result;
    }

    [HttpPost("greeting/json2")]
    public GreetingResponse PostGreeting2([FromBody] GreetingRequest request)
    {
        _logger.Log(LogLevel.Information, "/api/greeting/json2 Started");
        String service = "/api/greeting/json2";
        String status = "Sucess";
        String statusCode = "200";
        String message = "Hello World to " + request.Name + ", You are " + request.Message;

        GreetingResponse res = new GreetingResponse
        {
            Service = service,
            Status = status,
            StatusCode = statusCode,
            Message = message
        };

        _logger.Log(LogLevel.Information, "/api/greeting/json2 Finished");
        return res;
    }
}
