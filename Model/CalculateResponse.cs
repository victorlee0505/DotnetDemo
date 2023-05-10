namespace DemoApi.Model;
public class CalculateResponse
{
    public CalculateRequest? CalRequest { get; set; }
    public double CalResult { get; set; }
    public string? CalMessage { get; set; }

    public CalculateResponse(CalculateRequest? calRequest, double calResult, string? calMessage)
    {
        CalRequest = calRequest;
        CalResult = calResult;
        CalMessage = calMessage;
    }

    public CalculateResponse()
    {
    }

    public CalculateResponse Request(CalculateRequest request)
    {
        CalRequest = request;
        return this;
    }

    public CalculateResponse Result(double result)
    {
        CalResult = result;
        return this;
    }

    public CalculateResponse Message(string message)
    {
        CalMessage = message;
        return this;
    }

    public CalculateResponse Build()
    {
        return new CalculateResponse
        (
            CalRequest,
            CalResult,
            CalMessage
        );
    }

}

