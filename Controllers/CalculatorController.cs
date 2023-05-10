using DemoApi.Model;
using DemoApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DemoApi.Controllers;

[ApiController]
[Route("cal/")]

public class CalculationApiController : ControllerBase
{
    private readonly ILogger<CalculationApiController> _logger;
    private readonly CalculatorService _calculatorService;

    public CalculationApiController(ILogger<CalculationApiController> logger, CalculatorService calculatorService)
    {
        _logger = logger;
        _calculatorService = calculatorService;
    }

    /**
     * POST cal as JSON
     * http://localhost:8080/cal/post
     *  {
     *     "op": "+",
     *     "left": 3,
     *     "right": 3
     *  }
     * @return
     */
    [HttpPost("post")]
    public IActionResult DoMath([FromBody] CalculateRequest request)
    {
        _logger.LogInformation("/cal/post Started");
        CalculateResponse response = new CalculateResponse();

        if (!IsValidCalculateRequest(request))
        {
            response.Request(request).Message("Invalid Request!").Build();
            return BadRequest(response);
        }

        if (!_calculatorService.IsMathOperator(request.Operator))
        {
            response.Request(request).Message("Invalid Operator! Please use one of [ + - * / ^ ].").Build();
            return BadRequest(response);
        }

        double result = _calculatorService.CalculateResult(request.LeftOperand, request.RightOperand, request.Operator);
        response.Request(request).Message("Success").Result(result).Build();

        _logger.LogInformation("/cal/post Ended");

        return Ok(response);
    }

    private bool IsValidCalculateRequest(CalculateRequest request)
    {
        return request != null &&
            request.Operator != null;
    }
}


