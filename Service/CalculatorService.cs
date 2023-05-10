namespace DemoApi.Service;

public class CalculatorService
{
    public bool IsMathOperator(string op)
    {
        return op == "+" || op == "-" || op == "*" || op == "/" || op == "^";
    }

    public double CalculateResult(double leftOperand, double rightOperand, string op)
    {
        double result = 0;

        switch (op)
        {
            case "+":
                result = leftOperand + rightOperand;
                break;
            case "-":
                result = leftOperand - rightOperand;
                break;
            case "*":
                result = leftOperand * rightOperand;
                break;
            case "/":
                result = leftOperand / rightOperand;
                break;
            case "^":
                result = Math.Pow(leftOperand, rightOperand);
                break;
            default:
                result = 0;
                break;
        }

        return result;
    }
}
